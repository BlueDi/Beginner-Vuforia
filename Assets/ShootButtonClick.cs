using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButtonClick : MonoBehaviour {

    public GameObject sagira;
    public Button btn;
    public GameObject bolt;




    const float COOLDOWN = 0.5F;

    float cooldownTime = 0.0F;

    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    void Update()
    {
        cooldownTime -= Time.deltaTime;
    }

    void OnClick()
    {
        if(cooldownTime <= 0.0F)
        {
            //
            // TODO shoot
            //

            Transform sagiraTransform = sagira.GetComponent<Transform>();
            GameObject bullet = Instantiate(bolt, sagiraTransform.position, sagiraTransform.rotation);
            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(0,-0.1F,0);


            cooldownTime = COOLDOWN;
        }
    }
}
