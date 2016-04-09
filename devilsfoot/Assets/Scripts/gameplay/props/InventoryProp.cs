using UnityEngine;
using System.Collections;

public class InventoryProp : Prop {

    Inventory inventory;
    TextFader toolTip;
    bool playing = false;

    void Awake()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        toolTip = GameObject.Find("ToolTip").GetComponent<TextFader>();
    }

    protected override void Arrive()
    {
        base.Arrive();

        PlayText();
    }

    public void PlayText()
    {
        if (!playing)
        {
            playing = true;
            StartCoroutine("UpdateExposition");
        }
    }

    IEnumerator UpdateExposition()
    {
        foreach (DelayText dt in propConfig.textListFromState(currentState, "interact"))
        {
            displayText(dt);
            yield return new WaitForSeconds(dt.ms / 1000.0f);
        }
        playing = false;
    }

    private void displayText(DelayText text)
    {

        toolTip.SetText(text.text);

    }
}
