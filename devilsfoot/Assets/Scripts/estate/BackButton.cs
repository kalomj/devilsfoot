using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class BackButton : MonoBehaviour, IPointerClickHandler
{

    public Camera ClaraCam;

    public void OnPointerClick(PointerEventData eventData)
    {
        ClaraCam.enabled = !ClaraCam.enabled;
    }
}
