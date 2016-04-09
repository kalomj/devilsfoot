using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

    List<InventoryProp> inv;
    TextFader toolTip;
    GameObject Item1;
    GameObject Item2;
    GameObject Item3;
    GameObject Item4;

    public void Awake()
    {
        inv = new List<InventoryProp>();
        Item1 = GameObject.Find("Item1");
        Item2 = GameObject.Find("Item2");
        Item3 = GameObject.Find("Item3");
        Item4 = GameObject.Find("Item4");
        toolTip = GameObject.Find("ToolTip").GetComponent<TextFader>();
    }

    public void Start()
    {

        gameObject.SetActive(false);
    }

    void Update()
    {
    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void AddItem(InventoryProp prop)
    {
        inv.Add(prop);
        Item1.GetComponent<ButtonTest>().AddItem(prop);
        prop.currentState = "collected";
        toolTip.SetText(prop.name + " added to inventory.");
    }
    
    public void RemoveItem(InventoryProp prop)
    {
        for(int i = 0; i < inv.Count; i ++)
        {
            InventoryProp p = inv[i];
            if(prop.name == p.name)
            {
                inv.Remove(p);
                prop.currentState = "owned";
                Item1.GetComponent<ButtonTest>().RemoveItem(prop);
                toolTip.SetText(prop.name + " removed from inventory.");
                break;
            }
        }
    }

    public InventoryProp GetItem()
    {
        return inv[0];
    }

    public bool Contains(InventoryProp item)
    {
        foreach(InventoryProp p in inv)
        {
            if(p.name == item.name)
            {
                return true;
            }
        }
        return false;
    }
}
