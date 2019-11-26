using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotater : MonoBehaviour
{
    public float rotationRate = 1;
    public float OTGrate = 0.8f;
    public float limit = 30.0f;
    private float direction = 0.0f;

    public bool enableForward = false;
    private float directionForward = 0.0f;

    //Vector3 eulerAngle;
    Quaternion rotation;
    
    private void Start()
    {
        //eulerAngle = new Vector3(0, 0, 0);
        rotation = Quaternion.identity;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) { direction += rotationRate; }
        if (Input.GetKey(KeyCode.D)) { direction -= rotationRate; }
        else { direction *= OTGrate; }

        if (enableForward)
        {
            if (Input.GetKey(KeyCode.W)) { directionForward += rotationRate; }
            else { directionForward *= OTGrate; }

            if (directionForward > limit) { directionForward = limit; }
            else if (directionForward < -limit) { directionForward = -limit; }
        }
        
        if (direction > limit) { direction = limit; }
        else if (direction < -limit) { direction = -limit; }

        transform.localRotation = Quaternion.Euler(directionForward, 0, direction);
    }

}
