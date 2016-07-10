using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// This class checks all contained rules and stores the target state to use if the rules are satisfied
/// </summary>
public class StateRule : MonoBehaviour {

    //This is what you need to show in the inspector.
    public List<PropRule> PropRuleList;
    public string targetState;
    public Sprite targetSprite;

    //check rule list for all applicable prop states
    public bool RulesSatisfied()
    {
        bool answer = true;
        foreach (PropRule pr in PropRuleList)
        {
            answer = answer && pr.RuleSatisfied();
        }

        return answer;
    }
}
