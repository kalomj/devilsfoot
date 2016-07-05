using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Navigator : MonoBehaviour {

    public List<Camera> Endpoints;
    public Camera MainCamera;
    public MySceneManager SceneManager;

    private int _position;

    public void Go(int position)
    {
        //start camera zoom effect
        Transform endpos = Endpoints[position].transform;
        Sequence seq = DOTween.Sequence();
        seq.Append(MainCamera.transform.DOMove(endpos.position, 15f));
        seq.Join(MainCamera.transform.DORotate(endpos.rotation.eulerAngles, 15f));
    }

    public void Teleport(int position)
    {
        Transform endpos = Endpoints[position].transform;
        MainCamera.transform.position = new Vector3(endpos.position.x, endpos.position.y, endpos.position.z);
    }

    public void FadeTo(int position)
    {
        _position = position;
        StartCoroutine("fadeTo");
    }

    IEnumerator fadeTo()
    {

        Transform endpos = Endpoints[_position].transform;

        SceneManager.GlobalFadeOut();

        yield return new WaitForSeconds(3);

        MainCamera.transform.position = new Vector3(endpos.position.x, endpos.position.y, endpos.position.z);
        MainCamera.transform.rotation = new Quaternion(endpos.rotation.x, endpos.rotation.y, endpos.rotation.z, endpos.rotation.w);

        SceneManager.GlobalFadeIn();

    }
}
