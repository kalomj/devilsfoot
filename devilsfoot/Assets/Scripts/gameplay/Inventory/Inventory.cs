using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

    List<Prop> inv;
    TextFader toolTip;
    Text Item1;
    Text Item2;
    Text Item3;
    Text Item4;

    public void Awake()
    {
        inv = new List<Prop>();
        Item1 = GameObject.Find("Item1").GetComponentInChildren<Text>();
        Item2 = GameObject.Find("Item2").GetComponentInChildren<Text>();
        Item3 = GameObject.Find("Item3").GetComponentInChildren<Text>();
        Item4 = GameObject.Find("Item4").GetComponentInChildren<Text>();
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

    public void AddItem(Prop prop)
    {
        inv.Add(prop);
        Item1.text = prop.name;
        prop.currentState = "collected";
        toolTip.SetText(prop.name + " added to inventory.");
    }
    
    public void RemoveItem(Prop prop)
    {
        for(int i = 0; i < inv.Count; i ++)
        {
            Prop p = inv[i];
            if(prop.name == p.name)
            {
                inv.Remove(p);
                prop.currentState = "owned";
                Item1.text = "Empty";
                toolTip.SetText(prop.name + " removed from inventory.");
                break;
            }
        }
    }

    public Prop GetItem()
    {
        return inv[0];
    }

    public bool Contains(Prop item)
    {
        foreach(Prop p in inv)
        {
            if(p.name == item.name)
            {
                return true;
            }
        }
        return false;
    }
}
