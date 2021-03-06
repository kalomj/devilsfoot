﻿using UnityEngine;
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
    //track current texture and only swap if different.
    private Texture2D cursorCurrentTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void OnMouseEnter()
    {
        setCursorState();
    }


    private void setCursorState()
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
            if (navigator.TestRule(nr) && !navigator.TransitionsDisabled)
            {
                navigable = true;
            }
        }

        if (navigable)
        {
            if(cursorCurrentTexture != cursorNavTexture)
            {
                cursorCurrentTexture = cursorNavTexture;
                Cursor.SetCursor(cursorNavTexture, hotSpot, cursorMode);
            }
        }
        else
        {
            if(cursorCurrentTexture != cursorInspectTexture)
            {
                cursorCurrentTexture = cursorInspectTexture;
                Cursor.SetCursor(cursorInspectTexture, hotSpot, cursorMode);
            }
        }
    }

    void OnMouseOver()
    {
        setCursorState();
    }

    void OnMouseExit()
    {
        if (cursorCurrentTexture != null)
        {
            cursorCurrentTexture = null;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
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

        bool stateChanged = false;
        //update the state first based on the props StateRules
        foreach (StateRule sr in stateRuleList)
        {
            if (sr.RulesSatisfied())
            {
                if (currentState != sr.targetState)
                {
                    stateChanged = true;

                    sr.PlayStateChangeAudio();

                    currentState = sr.targetState;
                    if (sr.targetSprite != null)
                    {
                        this.GetComponent<SpriteRenderer>().sprite = sr.targetSprite;
                    }
                    playing = false;

                    break;
                }
            }
        }

        if(!stateChanged)
        {
            //when clicked, 
            //if there wasn't a state change,
            //check all navigation rules
            //use the first check that passes
            //if navigation happens, don't play normal inspection text
            foreach (NavigatorRule nr in navigatorRuleList)
            {
                if (navigator.UseRule(nr))
                {
                    return;
                }
            }

        }

        //Play thought bubble text for the prop's current state
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

            //break out of loop if player is going quickly and starts to navigate before the exposition is complete
            if(navigator != null && navigator.Transitioning)
            {
                break;
            }
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
