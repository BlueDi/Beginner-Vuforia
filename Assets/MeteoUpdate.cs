using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Xml;
using TMPro;
using System;
using System.Text;

public class MeteoUpdate : MonoBehaviour {

    public Transform sagira;
    public TextMeshPro frontMesh;
    public TextMeshPro backMesh;

    public GameObject sunnyObj;
    public GameObject sunnyAndCloudObj;
    public GameObject cloudyObj;
    public GameObject drizzleObj;
    public GameObject rainObj;
    public GameObject snowObj;
    public GameObject fogObj;
    public GameObject thunderObj;
    public GameObject moonbObj;
    public GameObject moonAndCloudObj;

    private bool updating = false;
    private float cooldown = 0.0F;

    private float latitude = 10000;
    private float longitude = 10000;

	// Use this for initialization
	void Start () {
        StartCoroutine(GetGPSCoordinates());
	}
	
	// Update is called once per frame
	void Update ()
    {
        cooldown -= Time.deltaTime;

        Vector3 myPos = transform.position;
        Vector3 sagiraPos = sagira.transform.position;

        float diff = Vector3.Distance(myPos, sagiraPos);

        if(!updating && diff <= 0.15 && cooldown <= 0)
        {
            updating = true;
            cooldown = 5;
            StartCoroutine(GetWeather());
        }
	}

    IEnumerator GetGPSCoordinates()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //TODO show toast
            yield break;
        }
        else
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
        }

        // Stop service if there is no need to query location updates continuously
        Input.location.Stop();
    }

    IEnumerator GetWeather()
    { 
        //Reset
        frontMesh.SetText("...");
        backMesh.SetText("...");

        sunnyObj.SetActive(false);
        sunnyAndCloudObj.SetActive(false);
        cloudyObj.SetActive(false);
        drizzleObj.SetActive(false);
        rainObj.SetActive(false);
        snowObj.SetActive(false);
        fogObj.SetActive(false);
        thunderObj.SetActive(false);
        moonAndCloudObj.SetActive(false);
        moonbObj.SetActive(false);


        if (latitude == 10000 || longitude == 10000)
        {
            //TODO show toast
        }
        else
        {
            //http://api.openweathermap.org/data/2.5/weather?lat=40.6408027&lon=-7.9320585999999995&APPID=94cafbe1fc21fa1339fe0624a9d57eed&units=metric

            string url = "http://api.openweathermap.org/data/2.5/weather?lat=" +
                latitude + "&lon=" +
                longitude + "&APPID=94cafbe1fc21fa1339fe0624a9d57eed&units=metric&mode=xml";

            UnityWebRequest www = UnityWebRequest.Get(url);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                //TODO show toast
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(www.downloadHandler.text);

                XmlNode weatherIDXml = doc.SelectSingleNode("/current/weather/@number");
                XmlNode weatherTempXml = doc.SelectSingleNode("/current/temperature/@value");
                XmlNode timeRiseXml = doc.SelectSingleNode("/current/city/sun/@rise");
                XmlNode timeSetXml = doc.SelectSingleNode("/current/city/sun/@set");

                DateTimeOffset sunRise = DateTimeOffset.Parse(timeRiseXml.InnerText);
                DateTimeOffset sunSet = DateTimeOffset.Parse(timeSetXml.InnerText);


                string weatherId = "null";
                if (weatherIDXml != null)
                {
                    weatherId = weatherIDXml.InnerText;

                    int weatherIdnum = Int32.Parse(weatherId);


                    if (weatherIdnum >= 200 && weatherIdnum <= 232)
                        thunderObj.SetActive(true);
                    else if (weatherIdnum >= 300 && weatherIdnum <= 321)
                        drizzleObj.SetActive(true);
                    else if (weatherIdnum >= 500 && weatherIdnum <= 531)
                        rainObj.SetActive(true);
                    else if (weatherIdnum >= 600 && weatherIdnum <= 622)
                        snowObj.SetActive(true);
                    else if (weatherIdnum >= 700 && weatherIdnum <= 781)
                        fogObj.SetActive(true);
                    else if (weatherIdnum == 800 && DateTime.Now >= sunRise && DateTime.Now < sunSet)
                        sunnyObj.SetActive(true);
                    else if (weatherIdnum == 800 && (DateTime.Now < sunRise || DateTime.Now >= sunSet))
                        moonbObj.SetActive(true);
                    else if (weatherIdnum >= 801 && weatherIdnum <= 802 && DateTime.Now >= sunRise && DateTime.Now < sunSet)
                        sunnyAndCloudObj.SetActive(true);
                    else if (weatherIdnum >= 801 && weatherIdnum <= 802 && (DateTime.Now < sunRise || DateTime.Now >= sunSet))
                        moonAndCloudObj.SetActive(true);
                    else if (weatherIdnum == 803 || weatherIdnum == 804)
                        cloudyObj.SetActive(true);
                }

                string weatherTemp = "null";
                if(weatherTempXml != null)
                {
                    weatherTemp = weatherTempXml.InnerText;
                    frontMesh.SetText(weatherTemp + "ºC");
                    backMesh.SetText(weatherTemp + "ºC");
                }

            }
        }

        updating = false;
    }

}


