using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class largeTreeDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "mountains")
        {
            Debug.Log(collision.gameObject.tag);

            Destroy(collision.gameObject);

        }
    }
}
