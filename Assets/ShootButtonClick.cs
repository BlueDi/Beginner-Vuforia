using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButtonClick : MonoBehaviour {

    public GameObject sagira;
    public MeshRenderer sagiraRenderer;
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
        if(cooldownTime <= 0.0F && sagiraRenderer.enabled)
        {
            Transform sagiraTransform = sagira.GetComponent<Transform>();
            Vector3 pos = sagiraTransform.position;
            Quaternion rot = sagiraTransform.rotation;
            rot *= Quaternion.Euler(0, 0, 90);

            GameObject bullet = Instantiate(bolt, pos, rot);
            bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().useGravity = false;
            bullet.GetComponent<Rigidbody>().velocity = -sagiraTransform.right * 1F;

            sagira.GetComponent<AudioSource>().Play(0);

            cooldownTime = COOLDOWN;
        }
    }
}
