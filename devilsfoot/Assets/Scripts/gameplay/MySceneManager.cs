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
    public GameObject FadePanel;
    public List<GameObject> Characters;
    public Navigator Navigator;
    public GameObject backButton;
    public Inventory inventory;
    public EscMenu escMenu;
    public GameObject clickOverlay;
    public NavigatorRule destination;
    public List<GameObject> choiceButtons;

    List<DelayText> expositionText;
    protected bool endOfScript = false;
    protected bool endOfScene = false;
    protected bool began = false;
    protected float fadeRate = 0.008f;
    protected bool ending = false;
    protected bool continueFlag = true;

    

    public List<Prop> propList;

    List<PropConfig> pcList;

    protected GameManager.Scene nextscene;

    void Awake()
    {
        KaloScriptReader ksr = new KaloScriptReader();
        ksr.OpenTextAsset(kaloScript);
        pcList = ksr.ReadProps();

        AssignPropConfig();

        Initialize();
        if(inventory != null)
        {
            inventory.gameObject.SetActive(true);
        }
        
    }

    protected virtual void Initialize()
    {
        ///Debug.Log("Empty scenemanager initialization.");
    }

    void Start()
    {
        if(clickOverlay != null)
        {
            //start with click initialized but not active
            clickOverlay.SetActive(true);
            clickOverlay.SetActive(false);
        }

        
        foreach (GameObject go in Characters)
        {
            go.SetActive(true);
            go.SetActive(false);
        }

        CheckReady();
    }

    public void setClickOverlay(bool state)
    {
        bool cur = clickOverlay.activeSelf;

        if(state != cur)
        {
            clickOverlay.SetActive(state);

            //reset cursor this frame, allow onmouseover events of other objects to set cursor if needed.
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }     
    }
    public void SetPropState(int choice)
    {
        //assign prop to state using number assigned to choice button
        //GetProp(prop).currentState = state;
    }

    public virtual void Begin()
    {
        began = true;
        continueFlag = false;
        endOfScript = false;
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

        exposition.text = "";

        StartCoroutine("UpdateExposition");
    }

    void Update()
    {
        if(Navigator.Transitioning || escMenu.Active)
        {
            setClickOverlay(true);
        }
        else
        {
            setClickOverlay(false);
        }

        if (!ending && endOfScene && Input.anyKeyDown)
        {
            ending = true;
            EndScene();
        }
        else if ((Input.GetMouseButtonDown(0) && Navigator == null) || (Input.GetMouseButtonDown(0) && !Navigator.Transitioning))
        {
            continueFlag = true;
        }
        else if (!ending)
        {
            OnUpdate();
        }
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
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GameManager.Instance.SwitchScene(GameManager.Scene.estate);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.SwitchScene(GameManager.Scene.start);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.SwitchScene(GameManager.Scene.prologue);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.SwitchScene(GameManager.Scene.estate);
        }
        else if (began && !endOfScript && Input.GetKeyDown(KeyCode.Escape))
        {
            displayText(expositionText[expositionText.Count - 1]);
            endOfScript = true;
        }
    }

    IEnumerator UpdateExposition()
    {
        bool last_NagivatorPlaySuppress= false;

        for (int j = 0; j < expositionText.Count; j++)
        {
            DelayText dt = expositionText[j];

            if (endOfScript)
            {
                break;
            }

            List<DelayText> choices = new List<DelayText>();
            while (dt.attributes.ContainsKey("choice"))
            {
                choices.Add(dt);
                dt = expositionText[j++];
            }

            if (choices.Count > 0)
            {
                for(int k = 0; k < choices.Count; k++)
                {
                    choiceButtons[k].GetComponentInChildren<Text>().text = choices[k].text;
                }
            }

            do
            {
                //pause typing when inventory opens
                if (inventory != null && inventory.gameObject.activeSelf)
                {
                    yield return new WaitForFixedUpdate();
                    continueFlag = false;
                    continue;
                }

                //pause typing when esc menu opens
                if (escMenu != null && escMenu.Active)
                {
                    yield return new WaitForFixedUpdate();
                    continueFlag = false;
                    continue;
                }

                //pause typing during navigator transitions
                if (Navigator != null && Navigator.PlaySuppress)
                {
                    last_NagivatorPlaySuppress = Navigator.PlaySuppress;
                    yield return new WaitForFixedUpdate();
                    continueFlag = false;
                    continue;
                }

                //automatically start playing when fade transistioning to dialog camera is complete
                if(last_NagivatorPlaySuppress && !Navigator.PlaySuppress)
                {
                    last_NagivatorPlaySuppress = false;
                    continueFlag = true;
                }

                yield return new WaitForFixedUpdate();
            }
            while (!continueFlag);

            continueFlag = false;

            if (Characters != null)
            {
                for (int i = 0; i < Characters.Count; i++)
                {
                    if (dt.speaker == Characters[i].name)
                    {
                        Characters[i].SetActive(true);
                    }
                    else
                    {
                        Characters[i].SetActive(false);
                    }
                }
            }

            do
            {
                //pause typing when inventory opens
                if(inventory != null && inventory.gameObject.activeSelf)
                {
                    yield return new WaitForFixedUpdate();
                    continueFlag = false;
                    continue;
                }

                //pause typing when esc menu opens
                if(escMenu != null && escMenu.Active)
                {
                    yield return new WaitForFixedUpdate();
                    continueFlag = false;
                    continue;
                }

                //pause typing during navigator transitions
                if(Navigator != null && Navigator.PlaySuppress)
                {
                    yield return new WaitForFixedUpdate();
                    continueFlag = false;
                    continue;
                }

                if (continueFlag)
                {
                    continueFlag = false;
                    dt.speedUp++;
                }
                displayText(dt);
                yield return new WaitForSeconds(dt.delayTime);
            }
            while (dt.charsRemaining > 0);

            yield return new WaitForFixedUpdate();
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

    public Prop GetProp(string name)
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

    public void GlobalFadeIn()
    {
        if(FadePanel != null)
        {
            StartCoroutine("fadeIn");
        }
    }

    IEnumerator fadeIn()
    {
        if (FadePanel == null)
        {
            yield break;
        }

        Image panel = FadePanel.GetComponentInChildren<Image>();

        while (panel.color.a >= fadeRate)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a - fadeRate);
            yield return new WaitForFixedUpdate();
        }
    }

    public void GlobalFadeOut()
    {
        if (FadePanel != null)
        {
            StartCoroutine("fadeOut");
        }
    }


    IEnumerator fadeOut()
    {
        if (FadePanel == null)
        {
            yield break;
        }

        Image panel = FadePanel.GetComponentInChildren<Image>();

        while (panel.color.a <= 1.0f - fadeRate)
        {
            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, panel.color.a + fadeRate*3);
            yield return new WaitForFixedUpdate();
        }
    }
}
