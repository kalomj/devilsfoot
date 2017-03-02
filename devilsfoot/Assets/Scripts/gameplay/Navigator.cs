using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Navigator : MonoBehaviour {

    public enum NavType { Go, Teleport, FadeTo };

    public List<Camera> Endpoints;
    public Camera MainCamera;
    public MySceneManager SceneManager;
    public InteractiveProp PositionProp;

    private int _current;

    private int current
    {
        get
        {
            return _current;
        }
        set
        {
            _current = value;
            PositionProp.currentState = _current.ToString();
        }
    }
    private bool transitioning = false;
    public bool Transitioning
    {
        get
        {
            return transitioning;
        }
    }
    private bool transitionsDisabled = false;
    public bool TransitionsDisabled
    {
        get
        {
            return transitionsDisabled;
        }
        set
        {
            transitionsDisabled = value;
        }
    }

    private bool playSuppress = false;
    public bool PlaySuppress
    {
        get
        {
            return playSuppress;
        }
    }

    private void SetTransition()
    {
        transitioning = true;
    }

    private void ClearTransition()
    {
        transitioning = false;
    }

    public bool TestRule(NavigatorRule nr)
    {

        //look up start and end camera numbers
        int start = lookupCamera(nr.StartCam);
        int end = lookupCamera(nr.EndCam);

        //rule fails if we aren't at the starting position
        //or if the gamestate is not accurate
        if (current != start || !nr.RulesSatisfied() || transitioning)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public bool UseRule(NavigatorRule nr)
    {
        //look up start and end camera numbers
        int start = lookupCamera(nr.StartCam);
        int end = lookupCamera(nr.EndCam);

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

    private int lookupCamera(Camera cam)
    {
        for(int i = 0; i < Endpoints.Count; i++)
        {
            //check if they reference the same game object
            if(cam == Endpoints[i])
            {
                return i;
            }
        }
        throw new System.Exception("Camera not found, it should be assigned to the Navigator");
    }

    public void Go(int position)
    {
        //do nothing if already at the requested position or transitioning
        if (atCurrent(position) || transitioning || transitionsDisabled)
        {
            return;
        }

        SetTransition();

        current = position;
        //start camera zoom effect
        Transform endpos = Endpoints[position].transform;
        Sequence seq = DOTween.Sequence();
        seq.Append(MainCamera.transform.DOMove(endpos.position, 1f));
        seq.Join(MainCamera.transform.DORotate(endpos.rotation.eulerAngles, 1f));
        seq.AppendCallback(ClearTransition);
    }

    public void Teleport(int position)
    {
        //do nothing if already at the requested position or transitioning
        if (atCurrent(position) || transitioning || transitionsDisabled)
        {
            return;
        }

        current = position;
        Transform endpos = Endpoints[position].transform;
        MainCamera.transform.position = new Vector3(endpos.position.x, endpos.position.y, endpos.position.z);
        MainCamera.transform.rotation = new Quaternion(endpos.rotation.x, endpos.rotation.y, endpos.rotation.z, endpos.rotation.w);
    }

    public void FadeTo(int position)
    {
        //do nothing if already at the requested position or transitioning
        if (atCurrent(position) || transitioning || transitionsDisabled)
        {
            return;
        }

        SetTransition();
        playSuppress = true;

        current = position;
        StartCoroutine("fadeTo");
    }

    IEnumerator fadeTo()
    {
        Transform endpos = Endpoints[current].transform;

        SceneManager.GlobalFadeOut();

        yield return new WaitForSeconds(2);

        MainCamera.transform.position = new Vector3(endpos.position.x, endpos.position.y, endpos.position.z);
        MainCamera.transform.rotation = new Quaternion(endpos.rotation.x, endpos.rotation.y, endpos.rotation.z, endpos.rotation.w);

        SceneManager.GlobalFadeIn();
        playSuppress = false;
        
        yield return new WaitForSeconds(3);

        ClearTransition();

    }

    //only move if we aren't at current alreay
    private bool atCurrent(int position)
    {
        return position == current;
    }
}
