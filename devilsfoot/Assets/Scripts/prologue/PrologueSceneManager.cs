using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class PrologueSceneManager : MySceneManager {

    PreScene ps;
    GameObject myCam;

    protected override void Initialize()
    {
        expositionProp = "prologue";
        expositionPropState = "first_playthrough";
        nextscene = GameManager.Scene.estate;
        if (GameObject.Find("Prescene") != null)
        {
            ps = GameObject.Find("Prescene").GetComponent<PreScene>();
        }
        if (GameObject.Find("Main Camera") != null)
        {
           myCam = GameObject.Find("Main Camera");
        }
    }

    public override void CheckReady()
    {
        //if prescene is not enabled, then start the scene. otherwise, start the prescene
        if (ps == null)
        {
           StartZoom(0);
           Begin();
        }
        else
        {
            StartZoom(8);
            ps.RunFadeIn(Begin);
        }
    }

    private void StartZoom(float delay)
    {
        //start camera zoom effect
        Transform endpos = GameObject.Find("EndPos").transform;
        Sequence seq = DOTween.Sequence();
        seq.SetDelay(delay);
        seq.Append(myCam.transform.DOMove(endpos.position, 15f));
        seq.Join(myCam.transform.DORotate(endpos.rotation.eulerAngles, 15f));
    }

    public override void Begin()
    {
        GameObject.Find("TutorialTextFlash").GetComponent<TextFader>().FadeOut();
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
