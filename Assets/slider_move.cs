using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slider_move : MonoBehaviour {
    public Slider sli;

    // Use this for initialization
    void Start () {
        Slider sl = sli.GetComponent<Slider>();
        sl.onValueChanged.AddListener(RotateMyObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RotateMyObject(float value)
    {
        float sliderValue = value;
        transform.rotation = Quaternion.Euler(0, 0, sliderValue * 360 + 90);
    }

}
