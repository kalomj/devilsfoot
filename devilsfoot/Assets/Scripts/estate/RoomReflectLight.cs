using UnityEngine;
using System.Collections;

public class RoomReflectLight : MonoBehaviour
{

    public Light room;

    void Awake()
    {
        room = GetComponent<Light>();
    }

    public LinearSeqGen lsg = new LinearSeqGen(1f, 0.5f, 1.2f, 0.01f, true);

    // Update is called once per frame
    void FixedUpdate()
    {
        float f = lsg.getNext();
        room.intensity = f;
    }
}
