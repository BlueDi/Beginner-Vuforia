using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMeteoHandler : MonoBehaviour {

    public HandleMeteoComponents meteoComponents;
    public Text console;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        console.text = "click";
        meteoComponents.NextMeteo();
    }
}
