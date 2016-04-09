using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFader : MonoBehaviour {

    public float rate = .004f;
    Text text;
    bool reset = false;

    void Start()
    {
        text = GetComponent<Text>();
    }

    public void FadeOut()
    {
        StartCoroutine("Fade");
    }

    public void Reset()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
    }

    IEnumerator Fade()
    {
        Reset();
        while (text.color.a > 0)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - rate);
            yield return new WaitForFixedUpdate();
        }
    }

    public void SetText(string msg)
    {
        text.text = msg;
        FadeOut();
    }
}
