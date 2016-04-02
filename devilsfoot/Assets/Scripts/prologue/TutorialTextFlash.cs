using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialTextFlash : MonoBehaviour {

    public float rate = .005f;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
	// FixedUpdate is called on regular intervals
	void Update () {
        if (text.color.a > 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - rate);
        }
	}
}
