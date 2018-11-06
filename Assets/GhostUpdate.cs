using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostUpdate : MonoBehaviour {

    public Text console;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 myPos = transform.position;

        console.text = "X: " + myPos.x + ",Y: " + myPos.y + ", Z:" + myPos.z;

    }
}
