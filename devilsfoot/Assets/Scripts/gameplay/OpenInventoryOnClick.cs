using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventoryOnClick : MonoBehaviour {

    Inventory inventory;
    Collider2D col;

    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        col = this.GetComponent<Collider2D>();
    }

	// Update is called once per frame
	void OnMouseDown() {
        inventory.Toggle();
	}

}
