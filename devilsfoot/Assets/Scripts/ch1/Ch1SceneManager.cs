using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ch1SceneManager : MySceneManager {

    PreScene ps;
    Inventory inventory;
    

    protected override void Initialize()
    {
        expositionProp = "ch1";
        expositionPropState = "first_playthrough";
        nextscene = GameManager.Scene.start;
        if (GameObject.Find("Prescene") != null)
        {
            ps = GameObject.Find("Prescene").GetComponent<PreScene>();
        }

        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
            
    }

    public override void CheckReady()
    {
        //if prescene is not enabled, then start the scene. otherwise, start the prescene
        if (ps == null)
        {
            Begin();
        }
        else
        {
            ps.RunFadeIn(Begin);
        }
    }

    public override void Begin()
    {
        ps.gameObject.SetActive(false);
        base.Begin();
    }

    /// <summary>
    /// Run the main gameplay button checking here
    /// </summary>
    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (endOfScript && Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.P))
        {
            displayText(new DelayText("Scene Complete. Press any key."));
            ps.gameObject.SetActive(true);
            endOfScene = true;
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            inventory.Toggle();
        }
    }

    protected override void displayText(DelayText text)
    {
        base.displayText(text);

        if(text.add_item != null && text.add_item.Length != 0)
        {
            Prop p = GetProp(text.add_item);
            inventory.AddItem(p);
            inventory.Show();
        }
    }

    // fade out then switch scenes
    protected override void EndScene()
    {
        if(ps == null)
        {
            PostEndScene();
        }
        else
        {
            ps.RunFadeOut(PostEndScene);
        }
    }

    //callback that switches the scene
    private void PostEndScene()
    {
        //call base last. This switches to the next scene and doesn't return
        base.EndScene();
    }
}
