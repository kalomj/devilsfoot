using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NavigatorRule : MonoBehaviour {

    public Camera StartCam;
    public Camera EndCam;


    //This is what you need to show in the inspector.
    public Navigator.NavType TransitionType;
    public List<PropRule> PropRuleList;

    public GameObject expositionProp;
    public string expositionPropState;
    public NavigatorRule expositionDestination;

    //check rule list for all applicable prop states
    public bool RulesSatisfied()
    {
        bool answer = true;
        foreach(PropRule pr in PropRuleList)
        {
            answer = answer && pr.RuleSatisfied();
        }

        return answer;
    }
}
