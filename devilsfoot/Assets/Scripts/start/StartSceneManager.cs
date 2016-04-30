using UnityEngine;
using System.Collections;

public class StartSceneManager : MySceneManager {

    PreScene ps;
    public AudioSource startPiano;
    public AudioSource fireAudio;

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
            Begin();
        }
        else
        {
            fireAudio.Play();
            ps.RunFadeIn(Begin);
        }

    }

    public override void Begin()
    {
        exposition.GetComponent<TextFadeIn>().FadeIn();
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
            //fade out the "press start" message for immediate feedback
            exposition.GetComponent<TextFader>().FadeOut();
            StartCoroutine("MusicPause");
        }
    }

    IEnumerator MusicPause()
    {
        startPiano.Play();
        yield return new WaitForSeconds(8);
        ps.RunFadeOut(PostEndScene);
    }

    //callback that switches the scene
    private void PostEndScene()
    {
        //call base last. This switches to the next scene and doesn't return
        base.EndScene();
    }
}
