using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowAxe : MonoBehaviour
{
    public Rigidbody axeRigidBody;
    public Transform curve_point;
    private Transform mainCameraTransform;
    public float throForce = 50;

    private bool isReturning;
    private Vector3 oldPos;
    private float time = 0.0f;

    void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowAxeInit();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReturnAxe();
        }

        if (isReturning)
        {
            if (time < 1.0f)
            {
               //    axeRigidBody.position = getBQCPoint(time,oldPos,curve_point.position,tar)
                time += Time.deltaTime;
            }
        }
    }

    private void ThrowAxeInit()
    {
        axeRigidBody.transform.parent = null;
        axeRigidBody.isKinematic = false;
        axeRigidBody.AddForce(mainCameraTransform.TransformDirection(Vector3.forward) * throForce,ForceMode.Impulse);
        axeRigidBody.AddTorque(axeRigidBody.transform.TransformDirection(Vector3.right) * 100, ForceMode.Impulse);
    }

    private void ReturnAxe()
    {
        oldPos = axeRigidBody.position;
        isReturning = true;
        //axeRigidBody.position += transform.position - axeRigidBody.position;
        axeRigidBody.velocity = Vector3.zero;
        axeRigidBody.isKinematic = true;
    }

    Vector3 getBQCPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        // "t" is always between 0 and 1, so "u" is other side of t
        // If "t" is 1, then "u" is 0
        float u = 1 - t;
        // "t" square
        float tt = t * t;
        // "u" square
        float uu = u * u;
        // this is the formula in one line
        // (u^2 * p0) + (2 * u * t * p1) + (t^2 * p2)
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }

}
