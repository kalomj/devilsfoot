using System.Collections.Generic;

public class DelayText {

    public int charsRemaining
    {
        get; set;
    }
    public bool typeEffect = false;
    public int speedUp { get; set; }

    public float delayTime { get; set; }

    private string _text;
    public string text
    {
        get
        {
            if(typeEffect)
            {
                this.charsRemaining--;
                this.charsRemaining = this.charsRemaining - speedUp*10;
                if(this.charsRemaining < 0)
                {
                    this.charsRemaining = 0;
                }
                this.speedUp = 0;
                if (_text.Substring(_text.Length - this.charsRemaining) == ".")
                {
                    delayTime = 0.2f;
                }
                else
                {
                    delayTime = 0.1f;
                }

                return _text.Substring(0, _text.Length - this.charsRemaining);
            }
            else
            {
                this.charsRemaining = 0;
                return _text;
            }  
        }
        set
        {
            this.speedUp = 0;
            this._text = value;
            this.charsRemaining = _text.Length;
        }
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

    public string remove_item
    {
        get; set;
    }

    public DelayText(string text)
    {
        this.text = text;
        this.ms = 0f;
        this.speaker = "";
        this.charsRemaining = text.Length;
    }

    public DelayText(string text, string ms)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = "";
        this.charsRemaining = text.Length;
    }

    public DelayText(string text, string ms, string speaker)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = speaker;
        this.charsRemaining = text.Length;
    }

    public DelayText(string text, string ms, string speaker, string add_item)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = speaker;
        this.add_item = add_item;
        this.charsRemaining = text.Length;
    }
}
