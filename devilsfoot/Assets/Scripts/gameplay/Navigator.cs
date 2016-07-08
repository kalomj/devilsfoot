using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Navigator : MonoBehaviour {

    public enum NavType { Go, Teleport, FadeTo };

    public List<Camera> Endpoints;
    public Camera MainCamera;
    public MySceneManager SceneManager;

    private int current;

    public bool UseRule(NavigatorRule nr)
    {
        //look up start and end camera numbers
        int start = 0;
        int end = 1;

        //rule fails if we aren't at the starting position
        //or if the gamestate is not accurate
        if(current != start || !nr.RulesSatisfied())
        {
            Debug.Log("Nav rule failed with start=" + start + ", current=" + current);
            return false;
        }

        switch(nr.TransitionType)
        {
            case NavType.Go:
                Go(end);
                break;
            case NavType.Teleport:
                Teleport(end);
                break;
            case NavType.FadeTo:
                FadeTo(end);
                break;
        }

        return true;
    }

    public void Go(int position)
    {
        //do nothing if already at the requested position
        if (atCurrent(position))
        {
            return;
        }

        current = position;
        //start camera zoom effect
        Transform endpos = Endpoints[position].transform;
        Sequence seq = DOTween.Sequence();
        seq.Append(MainCamera.transform.DOMove(endpos.position, 5f));
        seq.Join(MainCamera.transform.DORotate(endpos.rotation.eulerAngles, 5f));
    }

    public void Teleport(int position)
    {
        //do nothing if already at the requested position
        if(atCurrent(position))
        {
            return;
        }

        current = position;
        Transform endpos = Endpoints[position].transform;
        MainCamera.transform.position = new Vector3(endpos.position.x, endpos.position.y, endpos.position.z);
    }

    public void FadeTo(int position)
    {
        //do nothing if already at the requested position
        if (atCurrent(position))
        {
            return;
        }

        current = position;
        StartCoroutine("fadeTo");
    }

    IEnumerator fadeTo()
    {

        Transform endpos = Endpoints[current].transform;

        SceneManager.GlobalFadeOut();

        yield return new WaitForSeconds(3);

        MainCamera.transform.position = new Vector3(endpos.position.x, endpos.position.y, endpos.position.z);
        MainCamera.transform.rotation = new Quaternion(endpos.rotation.x, endpos.rotation.y, endpos.rotation.z, endpos.rotation.w);

        SceneManager.GlobalFadeIn();

    }

    //only move if we aren't at current alreay
    private bool atCurrent(int position)
    {
        return position == current;
    }
}
