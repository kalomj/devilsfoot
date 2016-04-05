using UnityEngine;

public class StartSceneManager : MySceneManager {

    protected override void Initialize()
    {
        expositionProp = "start";
        expositionPropState = "topmenu";
        nextscene = GameManager.Scene.prologue;
    }

    protected override void Begin()
    {
        //if prescene is not enabled, then start the scene. otherwise, prescene will start the scene
        if (GameObject.Find("Prescene") == null)
        {
            base.Begin();
        }

    }

    public override void Ready()
    {
        base.Begin();
    }
}
