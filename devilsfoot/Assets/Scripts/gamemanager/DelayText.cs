using System.Collections.Generic;

public class DelayText {

    public string text
    {
        get; set;
    }

    public float ms
    {
        get; set;
    }

    public string speaker
    {
        get; set;
    }

    public string add_item
    {
        get; set;
    }

    public DelayText(string text)
    {
        this.text = text;
        this.ms = 0f;
        this.speaker = "";
    }

    public DelayText(string text, string ms)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = "";
    }

    public DelayText(string text, string ms, string speaker)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = speaker;
    }

    public DelayText(string text, string ms, string speaker, string add_item)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = speaker;
        this.add_item = add_item;
    }
}
