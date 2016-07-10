using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PropTextFade : MonoBehaviour {

    public float rate = .02f;
    Text text;
    Image image;

    private bool fadein = false;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
    }
	// FixedUpdate is called on regular intervals
	void FixedUpdate () {
        if (fadein && text.color.a < 1.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x + .005f, this.transform.position.y + .003f, this.transform.position.z);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + rate);
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + rate);
        }
        else if(fadein && text.color.a >=1.0f)
        {
            this.transform.position = new Vector3(this.transform.position.x + .003f, this.transform.position.y + .005f, this.transform.position.z);
            fadein = !fadein;
        }
        else if (!fadein && text.color.a > 0)
        {
            this.transform.position = new Vector3(this.transform.position.x + .002f, this.transform.position.y + .002f, this.transform.position.z);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - rate);
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a - rate);
        }
    }

    public void SetText(string msg)
    {
        fadein = true;
        text.text = msg;
    }
}
