using UnityEngine;
using System.Collections;

public class LanternProp : InteractiveProp {

    Light myLight;
    Inventory inventory;
    public InventoryProp contains;
    public MySceneManager msm;

    protected override void Initialize()
    {
        base.Initialize();
        myLight = GetComponentInChildren<Light>();
        myLight.enabled = false;
        afterTextEvent += SwapState;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        msm = GameObject.Find("Ch1SceneManager").GetComponent<MySceneManager>(); ;
    }

    protected override void Arrive()
    {
        checkPrerequisite();
        base.Arrive();
    }

    //this override lets an object trigger item collection during playback
    protected override void displayText(DelayText text)
    {
        base.displayText(text);

        if (text.add_item != null && text.add_item.Length != 0)
        {
            InventoryProp p = msm.GetProp(text.add_item) as InventoryProp;
            inventory.AddItem(p);
            inventory.Show();
        }
    }

    void checkPrerequisite()
    {
        if (currentState == "cantlight" && inventory.Contains(contains))
        {
            currentState = "canlight";
        }
        else if(currentState == "canlight" && !inventory.Contains(contains))
        {
            currentState = "cantlight";
        }
    }

    void SwapState()
    {
        if(currentState == "lit")
        {
            currentState = "canlight";
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
