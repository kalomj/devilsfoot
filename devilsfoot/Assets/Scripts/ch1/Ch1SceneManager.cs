using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ch1SceneManager : MySceneManager {

    PreScene ps;

    protected override void Initialize()
    {
        expositionProp = "ch1";
        expositionPropState = "first_playthrough";
        nextscene = GameManager.Scene.start;
        if(GameObject.Find("Prescene") != null)
        {
            ps = GameObject.Find("Prescene").GetComponent<PreScene>();
        }
    }

    public override void CheckReady()
    {
        //if prescene is not enabled, then start the scene. otherwise, start the prescene
        if (ps == null)
        {
            base.Begin();
        }
        else
        {
            ps.RunFadeIn(Begin);
        }
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (endOfScript && Input.GetKeyUp(KeyCode.Q))
        {
            displayText(new DelayText("Scene Complete. Press any key.","1"));
            endOfScene = true;
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
