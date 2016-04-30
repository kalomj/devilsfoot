using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EstateSceneManager : MySceneManager {

    PreScene ps;
    Inventory inventory;
    public CameraSway cam;
    public Camera ClaraCam;

    protected override void Initialize()
    {
        expositionProp = "estate";
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
            cam.StartZoom(0);
            Begin();
        }
        else
        {
            cam.StartZoom(8);
            ps.RunFadeIn(Begin);
        }
    }

    public override void Begin()
    {
        if(ps != null)
        {
            ps.gameObject.SetActive(false);
        }
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
            if (ps != null)
            {
                ps.gameObject.SetActive(true);
            }
            endOfScene = true;
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            inventory.Toggle();
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            GlobalFadeOut();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            GlobalFadeIn();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ClaraCam.enabled = !ClaraCam.enabled;
        }
    }

    //override display text incase there is an add_item side effect to the exposition
    protected override void displayText(DelayText text)
    {
        base.displayText(text);

        if(text.add_item != null && text.add_item.Length != 0)
        {
            InventoryProp p = GetProp(text.add_item) as InventoryProp;
            inventory.AddItem(p);
            //inventory.Show();
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
