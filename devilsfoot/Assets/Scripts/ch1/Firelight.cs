using UnityEngine;
using System.Collections;

public class Firelight : MonoBehaviour {

    public float rate = 0.1f;
    public float min = 4.5f;
    public float max = 5.5f;

    public Light pointLight;
    bool inc;



    void Start()
    {
        inc = true;
        pointLight = GetComponent<Light>();
        pointLight.intensity = min;
    }

	void FixedUpdate()
    {
        if(inc && pointLight.intensity < max)
        {
            pointLight.intensity += rate;
        }
        else if(inc && pointLight.intensity >= max)
        {
            pointLight.intensity -= rate;
            inc = false;
        }
        else if(!inc && pointLight.intensity > min)
        {
            pointLight.intensity -= rate;
        }
        else
        {
            pointLight.intensity += rate;
            inc = true;
        }
    }
}
