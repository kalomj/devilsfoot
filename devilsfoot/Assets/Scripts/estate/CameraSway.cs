using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraSway : MonoBehaviour {

    Camera main;

    void Awake()
    {
        main = GetComponent<Camera>();
    }

    public void StartZoom(float delay)
    {
        //start camera zoom effect
        Transform endpos = GameObject.Find("EndPos").transform;
        Sequence seq = DOTween.Sequence();
        seq.SetDelay(delay);
        seq.Append(main.transform.DOMove(endpos.position, 15f));
        seq.Join(main.transform.DORotate(endpos.rotation.eulerAngles, 15f));
        seq.SetLoops(-1, LoopType.Yoyo);
    }
}
