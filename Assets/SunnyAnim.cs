using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunnyAnim : MonoBehaviour {

    const int degreesPerSecond = -10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float degress = (float) degreesPerSecond * Time.deltaTime;

        gameObject.transform.rotation *= Quaternion.Euler(0, 0, degress);
    }
}
