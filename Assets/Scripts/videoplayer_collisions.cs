using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoplayer_collisions : MonoBehaviour {
    public VideoPlayer videoPlayer;
    void onTriggerEnter(Collider other)
    {
        Debug.Log(other, this);
    }
    void onTriggerStay(Collider other)
    {

    }

    void onTriggerExit(Collider other)
    {

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
