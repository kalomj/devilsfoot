using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public float rate = 0.1f;
    public float min = -10.0f;
    public float max = 10.0f;
    public bool move = false;
    public float drop_rate = 0f;
    public float tilt_rate = -3.0f;

    [HideInInspector]
    public Camera cam;
    bool inc;




    void Start()
    {
        inc = true;
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (!move)
        {
            return;
        }

        Vector3 position = cam.transform.localPosition;
        if (inc && position.z < max)
        {
            cam.transform.localPosition = new Vector3(position.x, position.y - drop_rate, position.z + rate);
            cam.transform.Rotate(Vector3.right*rate*tilt_rate);
        }
        else if (inc && position.z >= max)
        {
            //cam.transform.localPosition = new Vector3(position.x, position.y + drop_rate, position.z - rate);
            //cam.transform.Rotate(Vector3.left * rate * tilt_rate);
            //inc = false;
        }
        else if (!inc && position.z > min)
        {
            //cam.transform.localPosition = new Vector3(position.x, position.y + drop_rate, position.z - rate);
            //cam.transform.Rotate(Vector3.left * rate * tilt_rate);
        }
        else
        {
            cam.transform.localPosition = new Vector3(position.x, position.y - drop_rate, position.z + rate);
            cam.transform.Rotate(Vector3.right * rate * tilt_rate);
            inc = true;
        }
    }
}
