﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// This script runs the prescene prefab
/// 
/// This supports fade in of title text configured in the inspector
/// 
/// </summary>
public class PreScene : MonoBehaviour {
    public float rate = 0.005f;
    Image scenepanel;
    Image titlepanel;
    GameObject titlefade;
    GameObject scenefade;
    bool starting = false;
    bool ending = false;

    public delegate void FinishedCallBack();
    //keep one callback at a time. always remove the existing callback before adding
    //a new callback
    FinishedCallBack currentCallBack;
    event FinishedCallBack Finished;

    void Awake()
    {
        scenefade = GameObject.Find("scenefade");
        scenepanel = scenefade.GetComponentInChildren<Image>();
        titlefade = GameObject.Find("titlefade");
        titlepanel = titlefade.GetComponentInChildren<Image>();
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            FinishItNow();
        }
    }

    //Run takes a callback which is invoked after the prescene fadein script is complete
    public void RunFadeIn(FinishedCallBack callback)
    {
        Finished -= currentCallBack;
        currentCallBack = callback;
        Finished += callback;
        starting = true;
        StartCoroutine("FadeIn");
    }

    public void RunFadeOut(FinishedCallBack callback)
    {
        Finished -= currentCallBack;
        currentCallBack = callback;
        Finished += callback;
        ending = true;
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        //enable title panel
        titlefade.SetActive(true);
        //fade it in
        while (titlepanel.color.a >= rate)  //use the step value for compare instead of zero to prevent negatives
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

        FinishItNow();
    }

    IEnumerator FadeOut()
    {
        //fade out main scene
        while (scenepanel.color.a <= 1.0f)
        {
            scenepanel.color = new Color(scenepanel.color.r, scenepanel.color.g, scenepanel.color.b, scenepanel.color.a + rate);
            yield return new WaitForFixedUpdate();
        }

        FinishItNow();

    }

    void FinishItNow()
    {
        if (starting)
        {
            titlefade.SetActive(false);
            titlepanel.color = new Color(titlepanel.color.r, titlepanel.color.g, titlepanel.color.b, 1.0f);
            scenepanel.color = new Color(scenepanel.color.r, scenepanel.color.g, scenepanel.color.b, 0.0f);
            starting = false;
            Finished();
        }  
        else if(ending)
        {
            titlefade.SetActive(false);
            scenepanel.color = new Color(scenepanel.color.r, scenepanel.color.g, scenepanel.color.b, 1.0f);
            ending = false;
            Finished();
        } 
    }
}
