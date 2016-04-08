using UnityEngine;

public class StartSceneManager : MySceneManager {

    PreScene ps;

    protected override void Initialize()
    {
        expositionProp = "start";
        expositionPropState = "topmenu";
        nextscene = GameManager.Scene.prologue;
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
            ps.RunFadeIn(base.Begin);
        }

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
