using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

    public float rate = 0.1f;
    public float min = -10.0f;
    public float max = 10.0f;
    public bool move = true;

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
        Vector3 rot = cam.transform.rotation.eulerAngles;
        if (inc && position.z < max)
        {
            cam.transform.localPosition = new Vector3(position.x, position.y, position.z + rate);
            cam.transform.Rotate(Vector3.right*rate*3);
        }
        else if (inc && position.z >= max)
        {
            cam.transform.localPosition = new Vector3(position.x, position.y, position.z - rate);
            cam.transform.Rotate(Vector3.left * rate * 3);
            inc = false;
        }
        else if (!inc && position.z > min)
        {
            cam.transform.localPosition = new Vector3(position.x, position.y, position.z - rate);
            cam.transform.Rotate(Vector3.left * rate * 3);
        }
        else
        {
            cam.transform.localPosition = new Vector3(position.x, position.y, position.z + rate);
            cam.transform.Rotate(Vector3.right * rate * 3);
            inc = true;
        }
    }
}
