using UnityEngine;
using System.Collections;

public class LanternProp : InteractiveProp {

    Light myLight;

    protected override void Initialize()
    {
        base.Initialize();
        myLight = GetComponentInChildren<Light>();
        myLight.enabled = false;
        afterTextEvent += SwapState;
    }

    protected override void Arrive()
    {
        base.Arrive();
    }

    void SwapState()
    {
        if(currentState == "lit")
        {
            currentState = "unlit";
            myLight.enabled = false;
        }
        else
        {
            currentState = "lit";
            myLight.enabled = true;
        }
    }
}
