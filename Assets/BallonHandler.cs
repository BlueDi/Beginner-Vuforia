using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonHandler : MonoBehaviour {

    public BallonImageHandler bhandler;
    public AudioSource ballonAudio;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name.Contains("Bolt"))
        {
            bhandler.PopBallon(1);
            gameObject.SetActive(false);
            ballonAudio.Play(0);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Bolt"))
        {
            bhandler.PopBallon(1);
            gameObject.SetActive(false);
            ballonAudio.Play(0);
        }
    }
}
