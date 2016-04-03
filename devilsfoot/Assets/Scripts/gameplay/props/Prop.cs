using UnityEngine;
using System.Collections.Generic;

public abstract class Prop : MonoBehaviour {

    public List<Prop> reachableProps = new List<Prop>();

    [HideInInspector]
    public Collider col;

    // Use this for initialization
    void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Arrive();
    }

    public virtual void Arrive()
    {

    }

    public virtual void Leave()
    {

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
