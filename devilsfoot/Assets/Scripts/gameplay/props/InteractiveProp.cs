using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractiveProp : Prop {

    public Text PropText;
    protected delegate void afterText();
    protected event afterText afterTextEvent;

    bool playing = false;

    protected override void Initialize()
    {
        currentState = propConfig.DefaultState;
    }

    protected override void Arrive()
    {
        base.Arrive();

        PlayText();
    }

    private void PlayText()
    {
        PropText.GetComponent<RectTransform>().position = new Vector3(Input.mousePosition.x+200,Input.mousePosition.y+25);

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
        afterTextEvent();
    }

    private void displayText(DelayText text)
    {

        PropText.GetComponent<PropTextFade>().SetText(text.text);

    }

}
