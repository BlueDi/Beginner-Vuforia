using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackPosition : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = transform.position;

        text.text = "X: " + pos.x + ", Y: " + pos.y + ", Z: " + pos.z;
    }
}
