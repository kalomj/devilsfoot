using UnityEngine;
using System.Collections;

public abstract class Prop : MonoBehaviour {

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
}
