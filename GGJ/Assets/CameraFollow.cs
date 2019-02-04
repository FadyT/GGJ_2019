using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    // smooth rotation 45 degree
    public Transform target;
    public Vector3 offsetPos;
    public float moveSpeed = 5;
    public float turnSpeed = 10;
    public float smoothSpeed = 0.5f;

    Quaternion targetRotation;
    Vector3 targetPos;
    bool smoothRotating = false;

    private void LateUpdate()
    {
        MoveWithTarget();
        LookAtTaget();

        if (Input.GetKeyDown(KeyCode.G) && !smoothRotating)
        {
            StartCoroutine("RotateAroundTarget", 45);
        }

        if (Input.GetKeyDown(KeyCode.H) && !smoothRotating)
        {
            StartCoroutine("RotateAroundTarget", -45);
        }
        //Debug.Log(smoothRotating);
    }

    void MoveWithTarget()
    {
        targetPos = target.position + offsetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

    }

    void LookAtTaget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    IEnumerator RotateAroundTarget(float angle)
    {
        Vector3 vel = Vector3.zero;
        Vector3 targetOffsetPos = Quaternion.Euler(0, angle, 0) * offsetPos;
        float distance = Vector3.Distance(offsetPos, targetOffsetPos);

        smoothRotating = true;

        while (distance > 0.1f)
        {
            offsetPos = Vector3.SmoothDamp(offsetPos, targetOffsetPos, ref vel, smoothSpeed);
            distance = Vector3.Distance(offsetPos, targetOffsetPos);
            Debug.Log(distance);
            yield return null;
        }

        smoothRotating = false;
        offsetPos = targetOffsetPos;
    }
}