using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PrologueSceneManager : MySceneManager {

    PreScene ps;

    protected override void Initialize()
    {
        expositionProp = "prologue";
        expositionPropState = "first_playthrough";
        nextscene = GameManager.Scene.ch1;
        if (GameObject.Find("Prescene") != null)
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

    public override void Begin()
    {
        //start the camera zoom effect
        GameObject.Find("Main Camera").GetComponent<CameraZoom>().move = true;

        //start the scene exposition
        base.Begin();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (endOfScript)
        {
            endOfScene = true;
        }
    }

    // fade out then switch scenes
    protected override void EndScene()
    {
        if (ps == null)
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
