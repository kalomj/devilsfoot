using UnityEngine;
using System.Collections;

public class PropRule : MonoBehaviour {

    public Prop prop;
    public string state;

    public bool RuleSatisfied()
    {
        return prop.currentState == state;
    }
}
