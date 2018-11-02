using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class start_video : MonoBehaviour {
    public Button btn;
    public VideoPlayer videoPlayer;

	// Use this for initialization
	void Start () {
        videoPlayer = GetComponent<VideoPlayer>();

        btn.onClick.AddListener(PlayPause);
    }
	
	// Update is called once per frame
	void Update () {}

    public void PlayPause(){
        if (videoPlayer.isPlaying) {
            videoPlayer.Pause();
        } else {
            videoPlayer.Play();
        }
    }
}
