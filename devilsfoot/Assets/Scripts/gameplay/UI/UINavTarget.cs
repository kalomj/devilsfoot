using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class UINavTarget : MonoBehaviour, IPointerClickHandler
{
    public Navigator navigator;
    public List<NavigatorRule> navigatorRuleList;

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
}
