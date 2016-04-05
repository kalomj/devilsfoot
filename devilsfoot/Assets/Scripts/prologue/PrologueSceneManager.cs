using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PrologueSceneManager : MySceneManager {

    protected override void Initialize()
    {
        expositionProp = "prologue";
        expositionPropState = "first_playthrough";
        nextscene = GameManager.Scene.ch1;
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
