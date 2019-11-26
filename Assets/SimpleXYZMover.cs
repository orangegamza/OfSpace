using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleXYZMover : MonoBehaviour
{
    public KeyCode forwardKey;
    public KeyCode backKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    
    public float speed;
    
    private void GetMove()
    {
        if (Input.GetKey(forwardKey))
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, speed), ForceMode.Impulse);
        else if (Input.GetKey(backKey))
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -speed), ForceMode.Impulse);
        else
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

        if (Input.GetKey(leftKey))
            gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0, -speed, 0), ForceMode.Impulse);
        if (Input.GetKey(rightKey))
            gameObject.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0, speed, 0), ForceMode.Impulse);
        else
            gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        GetMove();
    }
    
}
