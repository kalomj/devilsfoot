using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Base class for managing scenes. All scenes should have a scenemanager derived from 
/// this class. 
/// 
/// Base class provides support for setting up props with their xml configuration
/// as well as playing exposition text on scene start
/// 
/// Derived class should set the next scene property as well as initial exposition prop/state for the scene
/// 
/// Base class will not automatically end a scene.
/// the derived class should set endOfScene flag when it is finished.
/// 
/// Awake is called automatically. The base class handles common Awake routines.
/// Awake calls Initialize. Initialize can be overridden in child classes
/// Start is then called automatically. The base class handles common Strt routines.
/// Start calls CheckReady. CheckReady can be overridden in child classes.
/// CheckReady calls Begin. Begin can be overridden in child classes.
/// 
/// Typical flow is to allow the base class to control the scene start. It calls in this order: 
/// Awake->Initialize->Start->CheckReady->Begin
/// 
/// If a scene includes a prescene, the derived scenemanager should override CheckReady to delay Begin
/// The derived class can then choose when to call Begin
/// 
/// </summary>
public class MySceneManager : MonoBehaviour {

    public Text exposition;
    public TextAsset kaloScript;
    public string expositionProp;
    public string expositionPropState;
    public bool playExposition = true;
    public Text speakerNameText;

    List<DelayText> expositionText;
    protected bool endOfScript = false;
    protected bool endOfScene = false;
    protected bool began = false;

    protected List<Prop> propList;

    List<PropConfig> pcList;

    protected GameManager.Scene nextscene;

    void Awake()
    {
        KaloScriptReader ksr = new KaloScriptReader();
        ksr.OpenTextAsset(kaloScript);
        pcList = ksr.ReadProps();

        AssignPropConfig();

        Initialize();
    }

    protected virtual void Initialize()
    {
        Debug.Log("Empty scenemanager initialization.");
    }

    void Start()
    {
        CheckReady();
    }

    public virtual void Begin()
    {
        began = true;
        if (playExposition)
        {
            PlayExposition(expositionProp, expositionPropState);
        }
    }

    // Base class assumes we are always ready. Conditions can be added in child classes.
    public virtual void CheckReady()
    {
        Begin();
    }

    // Loop and assign prop config to all props in the scene
    void AssignPropConfig()
    {
        propList= new List<Prop>(FindObjectsOfType<Prop>());

        foreach (Prop prop in propList)
        {
            AssignPropConfig(prop);
        }
    }

    // Assign propconfig to the given prop
    void AssignPropConfig(Prop prop)
    {
        foreach (PropConfig pc in pcList)
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

        foreach (PropConfig pc in pcList)
        {
            if (pc.name == pnName)
            {
                expositionText = pc.textListFromState(stateName);
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
        if (endOfScene && Input.anyKeyDown)
        {
            EndScene();
        }

        OnUpdate();
    }

    //This function switches the scene
    //EndScene behavior can be overridden in derived classes
    //For example, to provide a fade out before the SwitchScene
    protected virtual void EndScene()
    {
        GameManager.Instance.SwitchScene(nextscene);
    }


    // endOfScene must be set true by the derived class to allow the scene to end.
    protected virtual void OnUpdate()
    {
        if (began && !endOfScript && Input.GetKeyDown(KeyCode.Escape))
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

    protected virtual void displayText(DelayText text)
    {
        exposition.text = text.text;

        if(speakerNameText != null)
        {
            speakerNameText.text = text.speaker;
        }
    }

    protected Prop GetProp(string name)
    {
        foreach(Prop prop in propList)
        {
            if (prop.name == name)
            {
                return prop;
            }
        }
        throw new System.Exception("Prop name " + name + " not found");
    }
}
