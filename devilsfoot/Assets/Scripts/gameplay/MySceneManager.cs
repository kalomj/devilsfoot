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

    List<Prop> propList;
    List<PropConfig> pnList;

    void Awake()
    {
        KaloScriptReader ksr = new KaloScriptReader();
        ksr.OpenTextAsset(kaloScript);
        pnList = ksr.ReadProps();

        AssignPropConfig();

        Initialize();
    }

    protected virtual void Initialize()
    {
        Debug.Log("Empty scenemanager initialization.");
    }

    void Start()
    {
        if (playExposition)
        {
            PlayExposition(expositionProp, expositionPropState);
        }
    }

    void AssignPropConfig()
    {
        propList= new List<Prop>(FindObjectsOfType<Prop>());

        foreach (Prop prop in propList)
        {
            AssignPropConfig(prop);
        }
    }

    void AssignPropConfig(Prop prop)
    {
        foreach (PropConfig pc in pnList)
        {
            if (prop.name == pc.name)
            {
                prop.propConfig = pc;
                return;
            }
        }
        Debug.Log("No prop config entry for " + prop.name);
    }

    void PlayExposition(string pnName, string stateName)
    {
        endOfScript = false;
        expositionText = null;

        foreach (PropConfig pn in pnList)
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
