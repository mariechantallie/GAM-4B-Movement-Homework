using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour{
[SerializeField] TrapEvent onTrapTriggered;
    void OnTriggerEnter(Collider other)
    {
        var data = new TrapData()
        {
            TriggeredPosition =transform.position
        };
        onTrapTriggered.TrapTriggered(data);

    }

     void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
         Gizmos.DrawCube(transform.position,transform.localScale);


    }
}
