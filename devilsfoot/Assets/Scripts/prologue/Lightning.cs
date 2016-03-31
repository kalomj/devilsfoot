using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

    public float rate = 0.1f;
    public float min = -10.0f;
    public float max = 10.0f;
    public bool move = true;

    [HideInInspector]
    public Light pointLight;
    bool inc;




    void Start()
    {
        inc = true;
        pointLight = GetComponent<Light>();
    }

    void FixedUpdate()
    {
        if(!move)
        {
            return;
        }

        Vector3 position = pointLight.transform.localPosition;
        if (inc && pointLight.transform.position.x < max)
        {
            pointLight.transform.localPosition = new Vector3(position.x + rate, position.y,position.z);
        }
        else if (inc && pointLight.transform.position.x >= max)
        {
            pointLight.transform.localPosition = new Vector3(position.x - rate, position.y, position.z);
            inc = false;
        }
        else if (!inc && pointLight.transform.position.x > min)
        {
            pointLight.transform.localPosition = new Vector3(position.x - rate, position.y, position.z);
        }
        else
        {
            pointLight.transform.localPosition = new Vector3(position.x + rate, position.y, position.z);
            inc = true;
        }
    }
}
