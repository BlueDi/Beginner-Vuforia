﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Xml;
using System.Timers;

public class MeteoUpdate : MonoBehaviour {

    public Text diffConsole;
    public Transform sagira;
    public Text collisionConsole;
    public Text gpsConsole;

    private bool updating = false;

    private float latitude = 10000;
    private float longitude = 10000;

	// Use this for initialization
	void Start () {
        StartCoroutine(GetGPSCoordinates());
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 myPos = transform.position;
        Vector3 sagiraPos = sagira.transform.position;

        float diff = Vector3.Distance(myPos, sagiraPos);

        if(!updating && diff <= 0.1)
        {
            StartCoroutine(GetWeather());
        }

        diffConsole.text = diff + "";
        gpsConsole.text = "Lat: " + latitude + ", Lon: " + longitude;
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
        updating = true;
        collisionConsole.text = "Getting Weather...";

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

                XmlNode weatherXML = doc.SelectSingleNode("/current/weather/@number");
               
                string desiredValue = "null";
                if (weatherXML != null)
                    desiredValue = weatherXML.InnerText;

                collisionConsole.text = "Weather value: " + desiredValue;


            }
        }

        System.Timers.Timer timer = new System.Timers.Timer(5000);
        timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
        timer.Enabled = true;
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
         updating = false;
    }
}

