using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InteractiveProp : Prop {

    private Canvas PropTextCopy;
    public Canvas PropText;
    protected delegate void afterText();
    protected event afterText afterTextEvent;
    public Navigator navigator;
    public List<NavigatorRule> navigatorRuleList;
    public List<StateRule> stateRuleList;
    public string ReachableFrom;
    public InteractiveProp PositionProp;

    public Texture2D cursorInspectTexture;
    public Texture2D cursorNavTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void OnMouseEnter()
    {
        //if the positionprop is defined, this is only reachable from one location. If we aren't at that location, then we haven't arrived.
        if (PositionProp != null)
        {
            if (PositionProp.currentState != ReachableFrom)
            {
                return;
            }
        }

        bool navigable = false;
        foreach (NavigatorRule nr in navigatorRuleList)
        {
            if (navigator.TestRule(nr))
            {
                navigable = true;
            }
        }

        if(navigable)
        {
            Cursor.SetCursor(cursorNavTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(cursorInspectTexture, hotSpot, cursorMode);
        }
        
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    protected bool playing = false;

    protected override void Initialize()
    {
        PropTextCopy = Instantiate(PropText);
        currentState = propConfig.DefaultState;
    }

    protected override void Arrive()
    {
        //if the positionprop is defined, this is only reachable from one location. If we aren't at that location, then we haven't arrived.
        if(PositionProp != null)
        {
            if (PositionProp.currentState != ReachableFrom)
            {
                return;
            }
        }
        base.Arrive();

        //update the state first based on the props StateRules
        foreach (StateRule sr in stateRuleList)
        {
            if (sr.RulesSatisfied())
            {
                currentState = sr.targetState;
                if(sr.targetSprite != null)
                {
                    this.GetComponent<SpriteRenderer>().sprite = sr.targetSprite;
                }
                playing = false;
                break;
            }
        }

        //when clicked, check all navigation rules
        //use the first check that passes
        //if navigation happens, don't play normal inspection text
        foreach (NavigatorRule nr in navigatorRuleList)
        {
            if (navigator.UseRule(nr))
            {
                return;
            }
        }

        //Play thought bubble text for the props current state
        PlayText();


        
    }

    private void PlayText()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //RaycastHit hit;
        //Physics.Raycast(ray, out hit);
        

        if (!playing)
        {
            playing = true;
            //PropTextCopy.GetComponentInChildren<Image>().gameObject.GetComponent<RectTransform>().position = new Vector3(hit.point.x,hit.point.y, 0);

            //Get position of text flag container so we can reposition it
            RectTransform rt = PropTextCopy.GetComponentInChildren<Image>().gameObject.GetComponent<RectTransform>();

           rt.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y+(rt.rect.height/2), Input.mousePosition.z);
            StartCoroutine("UpdateExposition");
        }
    }

    IEnumerator UpdateExposition()
    {
        foreach (DelayText dt in propConfig.textListFromState(currentState,"interact"))
        {
            displayText(dt);
            yield return new WaitForSeconds(dt.ms / 1000.0f);
        }
        playing = false;
        if (afterTextEvent != null)
        {
            afterTextEvent();
        }
    }

    protected virtual void displayText(DelayText text)
    {
        PropTextCopy.GetComponent<PropTextFade>().SetText(text.text);
    }

}
