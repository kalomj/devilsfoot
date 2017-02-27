using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class UINavTarget : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Navigator navigator;
    public List<NavigatorRule> navigatorRuleList;

    public Texture2D cursorInspectTexture;
    public Texture2D cursorNavTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void OnPointerClick(PointerEventData eventData)
    {
        //when clicked, check all navigation rules
        //use the first check that passes
        foreach (NavigatorRule nr in navigatorRuleList)
        {
            if (navigator.UseRule(nr))
            {
                break;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        bool navigable = false;
        foreach (NavigatorRule nr in navigatorRuleList)
        {
            if (navigator.TestRule(nr))
            {
                navigable = true;
            }
        }

        if (navigable)
        {
            Cursor.SetCursor(cursorNavTexture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(cursorInspectTexture, hotSpot, cursorMode);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
