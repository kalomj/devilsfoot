using UnityEngine;
using System.Collections;

public class LightShow : MonoBehaviour
{

    public Light red;
    public Light orange;
    public Light yellow;
    public Light white;

    public LinearSeqGen lsg = new LinearSeqGen(3.3f, 2.0f, 4.0f, 0.05f, true);

    // Update is called once per frame
    void FixedUpdate()
    {
        float f = lsg.getNext();
        yellow.intensity = f;
        yellow.intensity = f;
        orange.intensity = f;
        white.intensity = f;
    }
}
