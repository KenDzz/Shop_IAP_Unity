using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WatchAds : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject panel;
    public bool m_setActive = false;
    // Start is called before the first frame update
    void Start()
    {
        this.m_setActive = false ;
    }

    public void startAds()
    {
        videoPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.frame > 2 && !videoPlayer.isPlaying)
        {
            Debug.Log("Video Play Done!");
            if (!m_setActive)
            {
                panel.SetActive(false);
                this.m_setActive = true;
            }
        }
    }
}
