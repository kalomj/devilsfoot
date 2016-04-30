using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextFadeIn : MonoBehaviour {

    public float rate = .02f;
    Text text;

    private bool fadein = true;

    void Start()
    {
        text = GetComponent<Text>();
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0.0f);
    }

    public void FadeIn()
    {
        StartCoroutine("FadeMeIn");
    }

    IEnumerator FadeMeIn()
    {
        while (fadein && text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + rate);
            yield return new WaitForFixedUpdate();
        }
    }
}
