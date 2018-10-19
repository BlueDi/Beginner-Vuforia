using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_light : MonoBehaviour {
    public Button btn;

	// Use this for initialization
	void Start () {
        Button bt = btn.GetComponent<Button>();

        bt.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }
}
