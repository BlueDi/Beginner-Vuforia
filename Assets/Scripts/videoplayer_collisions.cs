using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoplayer_collisions : MonoBehaviour {
    public VideoPlayer videoPlayer;
    
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("bateu");
        if (gameObject.name == "PlayPauseCube")
        {
            PlayPause();
        } 
    }
    void OnTriggerStay(Collider other)
    {
        if (gameObject.name == "ForwardCube")
        {
            Forward5s();
        }
        else if (gameObject.name == "BackwardCube")
        { Backward5s(); }
        else if (gameObject.name == "IncreaseVolumeCube")
        {
            IncreaseVolume();
        }
        else if (gameObject.name == "DecreaseVolumeCube")
        {
            DecreaseVolume();
        }
    }
    
    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }

    public void Forward5s()
    {
        videoPlayer.time += 5;
    }

    public void Backward5s()
    {
        videoPlayer.time -= 5;
    }
    public void IncreaseVolume()
    {
        float av = videoPlayer.GetDirectAudioVolume(0);
        videoPlayer.SetDirectAudioVolume(0, av + 0.1F);
    }

    public void DecreaseVolume()
    {
        float av = videoPlayer.GetDirectAudioVolume(0);
        videoPlayer.SetDirectAudioVolume(0, av - 0.1F);
    }
}
