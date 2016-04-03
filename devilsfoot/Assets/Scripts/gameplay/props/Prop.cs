using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// Prop is an abstract class for all game elements drawn to the screen
/// 
/// Contains base class functions to configure object from XML on Start
/// 
/// Also contains simple common logic for click recognition
/// </summary>
public abstract class Prop : MonoBehaviour {

    public List<Prop> reachableProps = new List<Prop>();

    public string currentState;

    [HideInInspector]
    public PropConfig propConfig;


    protected Collider col;

    void Awake()
    {
        if(GetComponent<Collider>() != null)
        {
            col = GetComponent<Collider>();
            col.enabled = false;
        }
    }

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        Debug.Log(gameObject.name);
    }

    void OnMouseDown()
    {
        Arrive();
    }

    protected virtual void Arrive()
    {
        SetReachablesProps(true);
    }

    protected virtual void Leave()
    {
        SetReachablesProps(false);
    }



    public void SetReachablesProps(bool set)
    {
        foreach (Prop prop in reachableProps)
        {
            if (prop.col != null)
            {
                /*if (prop.GetComponent<Prerequisite>() != null && node.GetComponent<Prerequisite>().nodeAccess)
                {
                    if (node.GetComponent<Prerequisite>().Complete)
                    {
                        node.col.enabled = set;
                    }
                }
                else*/
                {
                    prop.col.enabled = set;
                }

            }
        }
    }
}
