using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PropTextFade : MonoBehaviour {

    public float rate = .02f;
    Text text;
    Image image;
    RectTransform rt;

    float moveConst1 = .25f;
    float moveConst2 = .1f;
    float moveConst3 = .05f;

    private bool fadein = false;

    void Start()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponentInChildren<Image>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);

        //Get position of text flag container so we can reposition it
        rt = this.GetComponentInChildren<Image>().gameObject.GetComponent<RectTransform>();
    }
	// FixedUpdate is called on regular intervals
	void FixedUpdate () {
        if (fadein && text.color.a < 1.0f)
        {
            rt.position = new Vector3(rt.position.x + moveConst1, rt.position.y + moveConst2, rt.position.z);
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + rate);
            image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + rate);
        }
        else if(fadein && text.color.a >=1.0f)
        {
            rt.position = new Vector3(rt.position.x + moveConst2, rt.position.y + moveConst1, rt.position.z);
            fadein = !fadein;
        }
        else if (!fadein && text.color.a > 0)
        {
            rt.position = new Vector3(rt.position.x + moveConst3, rt.position.y + moveConst3, rt.position.z);
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
