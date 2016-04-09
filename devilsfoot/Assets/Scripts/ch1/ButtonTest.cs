using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonTest : MonoBehaviour {

    Button button;
    GameObject go;

    void Awake()
    {
        go = GameObject.Find("match");
        button = GetComponent<Button>();
        button.onClick.AddListener(go.GetComponent<InventoryProp>().PlayText);

    }


	
}
