using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PreScene : MonoBehaviour {
    float rate = 0.005f;
    Image scenepanel;
    Image titlepanel;
    GameObject titlefade;
    GameObject scenefade;
    MySceneManager sceneManager;
    // Use this for initialization
    void Start () {
        scenefade = GameObject.Find("scenefade");
        scenepanel = scenefade.GetComponentInChildren<Image>();
        titlefade = GameObject.Find("titlefade");
        titlepanel = titlefade.GetComponentInChildren<Image>();
        sceneManager = GetComponentInParent<MySceneManager>();
        StartCoroutine("FadeIn");
	}

    IEnumerator FadeIn()
    {
        //enable title panel
        titlefade.SetActive(true);
        //fade it in
        while (titlepanel.color.a >= rate)
        {
            titlepanel.color = new Color(titlepanel.color.r, titlepanel.color.g, titlepanel.color.b, titlepanel.color.a - rate);
            yield return new WaitForFixedUpdate();
        }

        //fade it out
        while (titlepanel.color.a <= (1.0f - rate))
        {
            titlepanel.color = new Color(titlepanel.color.r, titlepanel.color.g, titlepanel.color.b, titlepanel.color.a + rate);
            yield return new WaitForFixedUpdate();
        }
        //disable it
        titlefade.SetActive(false);
        //fade in main scene
        while (scenepanel.color.a >= rate)
        {
            scenepanel.color = new Color(scenepanel.color.r, scenepanel.color.g, scenepanel.color.b, scenepanel.color.a - rate);
            yield return new WaitForFixedUpdate();
        }
        //start the scene
        sceneManager.Ready();
    }
}
