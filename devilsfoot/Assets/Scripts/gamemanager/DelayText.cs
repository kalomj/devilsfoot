﻿using System.Collections.Generic;

public class DelayText {

    public int charsRemaining
    {
        get; set;
    }
    public bool typeEffect = false;
    public int speedUp { get; set; }

    public float delayTime { get; set; }

    public Dictionary<string, string> attributes = new Dictionary<string, string>();

    private string _text;
    public string text
    {
        get
        {
            if(typeEffect)
            {
                this.charsRemaining--;
                if(this.charsRemaining < 0 || this.speedUp > 0)
                {
                    this.charsRemaining = 0;
                    this.speedUp = 0;
                }


                string curChar = string.Empty;

                if (_text.Length > 0)
                {
                    curChar = _text.Substring(_text.Length - this.charsRemaining - 1, 1);
                }

                if (curChar == "." || curChar == "," || curChar == ";" || curChar == "?" || curChar == "!")
                {
                    delayTime = 0.25f;
                }
                else if (curChar == "|")
                {
                    delayTime = 0.1f;
                    return "";
                }
                else if (curChar == " ")
                {
                    delayTime = 0.1f;
                }
                else
                {
                    delayTime = delayTime * 0.9f;
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
        this.delayTime = 0.1f;
    }

    public DelayText(string text, string ms)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = "";
        this.charsRemaining = text.Length;
        this.delayTime = 0.1f;
    }

    public DelayText(string text, string ms, string speaker)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = speaker;
        this.charsRemaining = text.Length;
        this.delayTime = 0.1f;
    }

    public DelayText(string text, string ms, string speaker, string add_item)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = speaker;
        this.add_item = add_item;
        this.charsRemaining = text.Length;
        this.delayTime = 0.1f;
    }

    public DelayText(string text, string ms, string speaker, string add_item, Dictionary<string,string> attributes)
    {
        this.text = text;
        this.ms = float.Parse(ms);
        this.speaker = speaker;
        this.add_item = add_item;
        this.charsRemaining = text.Length;
        this.attributes = attributes;
        this.delayTime = 0.1f;
    }
}
