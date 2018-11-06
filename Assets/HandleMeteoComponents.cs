using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMeteoComponents : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextMeteo()
    {
        Transform childList = gameObject.transform;
       

        for(int i = 0; i < childList.childCount; i++)
        {
            if (childList.GetChild(i).gameObject.activeInHierarchy && i >= childList.childCount - 1)
            {
                childList.GetChild(i).gameObject.SetActive(false);
                childList.GetChild(1).gameObject.SetActive(true);
                break;
            }
            else if (childList.GetChild(i).gameObject.activeInHierarchy && i > 0)
            {
                childList.GetChild(i).gameObject.SetActive(false);
                childList.GetChild(i + 1).gameObject.SetActive(true);
                break;
            }
        }
    }
}
