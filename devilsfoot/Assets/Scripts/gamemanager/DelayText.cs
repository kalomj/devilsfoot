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
}
