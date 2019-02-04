using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float velocity = 5;
    public float turnSpeed = 10;
    public float height = 0.5f; // height of chracter
    public float heightPadding = 0.05f; // to avoid sinking in ground , for train should have higher valu
    public LayerMask ground;
    public float maxGroundAngle = 120; // should be increased on very roughf terrains
    public bool debug;

    private Vector2 input;
    private float angle;
    private float groundAngle;
    private Quaternion targetRotation;
    private Transform camera;

    Vector3 forward;
    RaycastHit hitInfo;
    bool grounded;

    void Start()
    {
        camera = Camera.main.transform;
    }

    private void Update()
    {
        GetInput();
        CalculateDirection();

        CalculateForward();
        CalculateGroundAngle();
        CheckGround();
        ApplyGravity();
        DrawDebugLines();

        if (Mathf.Abs(input.x) < 0.5f && Mathf.Abs(input.y) < 0.5f)
        {
            return;
        }

        
        Rotate();
        Move();
    }

    void GetInput()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += camera.eulerAngles.y;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move()
    {
        if (groundAngle >= maxGroundAngle)
        {
            return;
        }
        transform.position += forward * velocity * Time.deltaTime;
    }

    //n
    
    void CalculateForward()
    {
        if (!grounded)
        {
            forward = transform.forward;
            return;
        }
        forward = Vector3.Cross(hitInfo.normal, -transform.right);
    }

    void CalculateGroundAngle()
    {
        if (!grounded)
        {
            groundAngle = 90;
            return;
        }

        groundAngle = Vector3.Angle(hitInfo.normal, transform.forward);
    }

    void CheckGround()
    {                                                           // hide heightPadding
        if (Physics.Raycast(transform.position, -Vector3.up, out hitInfo, height + heightPadding, ground)) 
        {
            if (Vector3.Distance(transform.position,hitInfo.point) < height) // player stuck in the ground
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.up * height, 5 * Time.deltaTime);
            }
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void ApplyGravity()
    {
        if (!grounded)
        {
            transform.position += Physics.gravity * Time.deltaTime;
        }
    }

    void DrawDebugLines()
    {
        if (!debug)
        {
            return;
        }

        Debug.DrawLine(transform.position, transform.position + forward * height * 2, Color.blue);
        Debug.DrawLine(transform.position, transform.position - Vector3.up * height, Color.green);

    }
}
