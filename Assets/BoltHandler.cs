using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltHandler : MonoBehaviour
{
    Vector3 initialPos;


    // Use this for initialization
    void Start ()
    {
        Destroy(gameObject, 5.0F);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name != "SagiraObject")
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name != "SagiraObject")
        {
            Destroy(gameObject);
        }
    }
}
