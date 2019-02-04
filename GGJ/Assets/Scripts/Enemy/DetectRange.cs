using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRange : MonoBehaviour
{


    EnemyTest me;
    private void Start()
    {

        gameObject.GetComponent<EnemyTest>().enabled = true;
        me = GetComponentInParent<EnemyTest>();
    }
    private void OnTriggerEnter(Collider other)
    {

        
        Debug.Log(other.tag);
        if (other.tag=="P")
        {
            EnemyTest script;
            //gameObject.GetComponent<EnemyTest>().enabled = true;
            //script = GetComponent<EnemyTest>(); //name of the script
//            UnityStandardAssets.Characters.ThirdPerson.Manager.playerEnabled = 1;
            //script.enabled = true; //this turns on the script
         //   me.state = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
       // if (other.name == "P")
        //{
            //me.player = null;
           // me.state = 0;
  //          UnityStandardAssets.Characters.ThirdPerson.Manager.playerEnabled = 1;
        //}

    }
}
