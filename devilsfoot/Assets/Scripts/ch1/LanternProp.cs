using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class LanternProp : InteractiveProp {

    Light myLight;
    Inventory inventory;
    public InventoryProp match;
    public GameObject darkness;
    public GlobalFog gf;


    protected override void Initialize()
    {
        base.Initialize();
        myLight = GetComponentInChildren<Light>();
        myLight.enabled = false;
        //afterTextEvent += SwapState;
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
        
        //if the positionprop is defined, this is only reachable from one location. If we aren't at that location, then we haven't arrived.
        if (PositionProp != null)
        {
            if (PositionProp.currentState != ReachableFrom)
            {
                return;
            }
        }

        
        //check the prerequisite and swap states assuming we aren't talking already
        if (!playing)
        {
            checkPrerequisite();
            base.Arrive();
            SwapState();
        }
        
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
            //darkness.SetActive(true);
        }
        else if(currentState == "canlight")
        {
            currentState = "lit";
            myLight.enabled = true;
            StartCoroutine("FadeOutSmoke");
            //darkness.SetActive(false);
        }
    }

    IEnumerator FadeOutSmoke()
    {
        float rate = .005f;
        float fog_rate = 0.5f;
        Material m = darkness.GetComponent<Renderer>().material;
        //fade it out
        while (darkness.GetComponent<Renderer>().material.color.a >= (0.0f + rate))
        {
            m.color = new Color(m.color.r, m.color.g, m.color.b, m.color.a - rate);
            if(gf.heightDensity >=fog_rate)
            {
                gf.heightDensity = gf.heightDensity - fog_rate;
            }
            
            yield return new WaitForFixedUpdate();
        }
    }
    
}
