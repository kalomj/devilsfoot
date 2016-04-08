using UnityEngine;
using System.Collections;
using System;


/// <summary>
/// returns an iterator that returns a sequence of numbers
/// 
/// Supports linear sequence rotating between min and max
/// 
/// Intend to support more complex waveforms in the future
/// </summary>
/// <typeparam name="T"></typeparam>
public class NumberGen<T> : IEnumerable {
    T number;

    public NumberGen(T startvalue, T min, T max, T rate)
    {
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }


}
