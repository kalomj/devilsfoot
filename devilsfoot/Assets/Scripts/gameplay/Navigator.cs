using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Navigator : MonoBehaviour {

    public List<Camera> Endpoints;
    public Camera MainCamera;

    public void Go(int position)
    {
        //start camera zoom effect
        Transform endpos = Endpoints[position].transform;
        Sequence seq = DOTween.Sequence();
        seq.Append(MainCamera.transform.DOMove(endpos.position, 15f));
        seq.Join(MainCamera.transform.DORotate(endpos.rotation.eulerAngles, 15f));
    }
}
