using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTree : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "tree")
        {
            Debug.Log(collision.gameObject.tag);

            Destroy(collision.gameObject);

        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "tree")
        {
            Debug.Log(other.gameObject.tag);

            Destroy(other.gameObject);

        }
    }
}
