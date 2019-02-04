using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showBridge : MonoBehaviour
{
    public GameObject bridge;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag( "b"))
        {
            bridge.SetActive(true);
        }
    }
}
