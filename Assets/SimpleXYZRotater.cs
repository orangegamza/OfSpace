using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleXYZRotater : MonoBehaviour
{
    class Direction
    {
        private float rotationSpeed;
        private float resetSpeed = 0.8f;
        private float current = 0.0f;
        private float limit;

        public KeyCode plusKey;
        public KeyCode minusKey;

        public Direction(KeyCode plus, KeyCode minus, float s = 8.0f, float l = 30.0f)
        {
            plusKey = plus;
            minusKey = minus;
            rotationSpeed = s;
            limit = l;
        }

        public float GetRotation()
        {
            if (Input.GetKey(plusKey))  current += rotationSpeed;
            if (Input.GetKey(minusKey)) current -= rotationSpeed;
            else { current *= resetSpeed; }

            if (current > limit) { current = limit; }
            else if (current < -limit) { current = -limit; }

            if (current <= 0.01f && current >= -0.01f) { current = 0.0f; }

            Debug.Log(current);

            return current;

        }
    }
    

    [Header("Which Direction to Rotate?")]
    [SerializeField] private bool enablePointUD = false;
    [SerializeField] private bool enablePointLR = false;
    [SerializeField] private bool enableRotateLR = false;

    [Header("KeyCode to Use")]
    public KeyCode pointU;
    public KeyCode pointD;
    public KeyCode pointL;
    public KeyCode pointR;
    public KeyCode rotateL;
    public KeyCode rotateR;

    private float dirPointUD = 0.0f;
    private float dirPointLR = 0.0f;
    private float dirRotateLR = 0.0f;

    Direction PointUD;
    Direction PointLR;
    Direction RotateLR;

    private void Start()
    {
        PointUD = new Direction(pointU, pointD);
        PointLR = new Direction(pointR, pointL, 5, 90);    // 우리가 생각하는 것과 반대방향으로 움직임
        RotateLR = new Direction(rotateL, rotateR);
    }
    
    private void FixedUpdate()
    {
        dirPointUD = (enablePointUD ? PointUD.GetRotation() : 0.0f);
        dirPointLR = (enablePointLR ? PointLR.GetRotation() : 0.0f);
        dirRotateLR = (enableRotateLR ? RotateLR.GetRotation() : 0.0f);

        transform.localRotation = Quaternion.Euler(dirPointUD, dirPointLR, dirRotateLR);
    }
}
