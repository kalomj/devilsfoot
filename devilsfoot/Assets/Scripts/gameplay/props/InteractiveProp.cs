using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractiveProp : Prop {

    public Text PropTextCopy;
    public Text PropText;
    protected delegate void afterText();
    protected event afterText afterTextEvent;
    GameObject ui;

    bool playing = false;

    protected override void Initialize()
    {
        PropTextCopy = Instantiate(PropText);
        PropTextCopy.gameObject.transform.SetParent(GameObject.Find("ui").transform,false);
        currentState = propConfig.DefaultState;
    }

    protected override void Arrive()
    {
        base.Arrive();

        PlayText();
    }

    private void PlayText()
    {
        PropTextCopy.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x+200,Input.mousePosition.y+25);

        if (!playing)
        {
            playing = true;
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

    private void displayText(DelayText text)
    {

        PropTextCopy.GetComponent<PropTextFade>().SetText(text.text);

    }

}
