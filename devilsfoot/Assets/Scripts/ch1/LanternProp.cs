using UnityEngine;
using System.Collections;

public class LanternProp : InteractiveProp {

    Light myLight;
    Inventory inventory;
    public Prop contains;

    protected override void Initialize()
    {
        base.Initialize();
        myLight = GetComponentInChildren<Light>();
        myLight.enabled = false;
        afterTextEvent += SwapState;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    protected override void Arrive()
    {
        checkPrerequisite();
        base.Arrive();
    }

    void checkPrerequisite()
    {
        if (currentState == "cantlight" && inventory.Contains(contains))
        {
            currentState = "canlight";
        }
    }

    void SwapState()
    {
        if(currentState == "lit")
        {
            currentState = "canlight";
            inventory.AddItem(contains);
            myLight.enabled = false;
        }
        else if(currentState == "canlight")
        {
            currentState = "lit";
            inventory.RemoveItem(contains);
            myLight.enabled = true;
        }
    }
}
