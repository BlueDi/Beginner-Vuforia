using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class start_video : MonoBehaviour {
    public Button btn;
    public VideoPlayer videoPlayer;

	void Start () {
        videoPlayer = GetComponent<VideoPlayer>();

        btn.onClick.AddListener(PlayPause);
    }
	
	void Update () {}

    public void PlayPause() {
        if (videoPlayer.isPlaying) {
            videoPlayer.Pause();
        } else {
            videoPlayer.Play();
        }
    }

    public void Forward5s() {
        videoPlayer.time += 5;
    }

    public void Backward5s() {
        videoPlayer.time -= 5;
    }
}
