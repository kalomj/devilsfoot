using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitMouseCursor : MonoBehaviour {

    public Texture2D cursorWaitTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
	
	void OnMouseOver () {
        Cursor.SetCursor(cursorWaitTexture, hotSpot, cursorMode);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }
}
