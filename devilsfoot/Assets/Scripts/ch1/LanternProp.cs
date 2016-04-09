using UnityEngine;
using System.Collections;

public class LanternProp : InteractiveProp {

    Light myLight;
    Inventory inventory;
    public InventoryProp match;


    protected override void Initialize()
    {
        base.Initialize();
        myLight = GetComponentInChildren<Light>();
        myLight.enabled = false;
        afterTextEvent += SwapState;
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        
    }

    //this override lets a prop trigger inventory item collection or removal
    //during playback of interactive prop text
    protected override void displayText(DelayText text)
    {
        base.displayText(text);

        if (text.add_item != null && text.add_item.Length != 0)
        {
            InventoryProp p = msm.GetProp(text.add_item) as InventoryProp;
            inventory.AddItem(p);
            inventory.Show();
        }

        if (text.remove_item != null && text.remove_item.Length != 0)
        {
            InventoryProp p = msm.GetProp(text.remove_item) as InventoryProp;
            inventory.RemoveItem(p);
        }
    }

    protected override void Arrive()
    {
        //check the prerequisite and swap states assuming we aren't talking already
        if(!playing)
        {
            checkPrerequisite();
        }
        base.Arrive();
    }

    void checkPrerequisite()
    {
        if (currentState == "cantlight" && inventory.Contains(match))
        {
            currentState = "canlight";
        }
        else if(currentState == "canlight" && !inventory.Contains(match))
        {
            currentState = "cantlight";
        }
    }

    void SwapState()
    {
        if (currentState == "lit")
        {
            currentState = "canlight";
            myLight.enabled = false;
        }
        else if(currentState == "canlight")
        {
            currentState = "lit";
            myLight.enabled = true;
        }
    }
}
