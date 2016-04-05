using UnityEngine;
using System.Collections.Generic;
using System;


/// <summary>
/// returns an iterator that returns a sequence of numbers
/// 
/// Supports linear sequence rotating between min and max
/// 
/// Intend to support more complex waveforms in the future
/// </summary>
public class LinearSeqGen {
    float cur;
    float min;
    float max;
    float rate;
    bool inc;
    bool startinc;
    float startnum;

    public LinearSeqGen(float startnum, float min, float max, float rate, bool increasing)
    {
        this.cur = startnum;
        this.startnum = startnum;
        this.min = min;
        this.max = max;
        this.rate = rate;
        this.inc = increasing;
        this.startinc = increasing;
    }

    public float getNext()
    {
        if (inc && (cur < max))
        {
            cur += rate;
        }
        else if (cur >= max)
        {
            cur = max - rate;
            inc = false;
        }
        else if (cur <= min)
        {
            cur = min + rate;
            inc = true;
        }
        else if (!inc && cur > min)
        {
            cur -= rate;
        }
        return cur;
    }

    public IEnumerable<float> Next(int total)
    {
        //return the first one
        if(total > 0)
        {
            yield return cur;
        }
        //interate through the rest
        for (int i = 1; i < total; i++)
        {
            yield return getNext();
        }
    }

    //iterate forever
    public IEnumerable<float> Next()
    {
        //return the first one
        yield return cur;

        //interate through the rest
        while(true)
        {
            yield return getNext();
        }
    }

    public void Reset()
    {
        this.cur = startnum;
        this.startinc = inc;
    }
}
