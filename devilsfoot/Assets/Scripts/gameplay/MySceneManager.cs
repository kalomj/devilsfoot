using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MySceneManager : MonoBehaviour {

    public Text exposition;
    public TextAsset kaloScript;
    public string expositionProp;
    public string expositionPropState;
    public bool playExposition = true;
    public Text speakerNameText;

    List<DelayText> expositionText;
    bool endOfScript = false;

    void Start()
    {
        if(playExposition)
        {
            PlayExposition(expositionProp, expositionPropState);
        }
    }

    protected virtual void PlayExposition(string pnName, string stateName)
    {
        endOfScript = false;
        expositionText = null;

        KaloScriptReader ksr = new KaloScriptReader();
        ksr.OpenTextAsset(kaloScript);
        List<PropNode> pnList = ksr.ReadProps();

        foreach (PropNode pn in pnList)
        {
            if (pn.name == pnName)
            {
                expositionText = pn.textListFromState(stateName);
                break;
            }
        }

        if (expositionText == null)
        {
            throw new System.Exception("Exposition Text Is Not Assigned");
        }

        StartCoroutine("UpdateExposition");
    }

    void Update()
    {
        if (Input.anyKeyDown && endOfScript)
        {
            GameManager.Instance.SwitchScene(GameManager.Scene.ch1);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {

            displayText(expositionText[expositionText.Count - 1]);
            endOfScript = true;
        }
    }

    IEnumerator UpdateExposition()
    {
        foreach (DelayText dt in expositionText)
        {
            if(endOfScript)
            {
                break;
            }

            displayText(dt);
            yield return new WaitForSeconds(dt.ms / 1000.0f);
        }

        endOfScript = true;
    }

    private void displayText(DelayText text)
    {
        exposition.text = text.text;

        if(speakerNameText != null)
        {
            speakerNameText.text = text.speaker;
        }
    }
}
