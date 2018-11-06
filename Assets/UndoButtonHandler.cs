using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UndoButtonHandler : MonoBehaviour {

    public Button btn;
    public BallonImageHandler handler;

	// Use this for initialization
	void Start () {
        btn.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        handler.Undo();
    }
}
