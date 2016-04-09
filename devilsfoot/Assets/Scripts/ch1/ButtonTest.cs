using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ButtonTest : MonoBehaviour {

    Button button;

    void Awake()
    {
        button = GetComponent<Button>();
    }

    public void AddItem(InventoryProp prop)
    {
        button.onClick.RemoveAllListeners();
        button.GetComponentInChildren<Text>().text = prop.name;
        button.onClick.AddListener(prop.PlayText);
    }

    public void RemoveItem(InventoryProp prop)
    {
        button.onClick.RemoveListener(prop.PlayText);
        button.GetComponentInChildren<Text>().text = "Empty";
    }
	
}
