using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollisionCube : MonoBehaviour {

    public Text console;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        console.text = "collided";

        if (col.gameObject.name == "SagiraObject")
        {
            //UPDATE
        }
    }
}
