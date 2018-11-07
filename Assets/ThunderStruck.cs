using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStruck : MonoBehaviour {

    public Light ligth1;
    public Light ligth2;

    float cooldown = 0.0F;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        cooldown -= Time.deltaTime;

        if (ligth1.intensity == 100)
            ligth1.intensity = 1;

        if (ligth2.intensity == 100)
            ligth2.intensity = 1;

        if(cooldown <= 0)
        {
            ligth1.intensity = 100;
            ligth2.intensity = 100;
            cooldown = 3.0F;
        }
    }
}
