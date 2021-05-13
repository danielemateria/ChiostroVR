using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Attiva : MonoBehaviour
{
    public GameObject TV;
    public GameObject screen;
    public VideoPlayer videoPlayer;
    public MeshRenderer meshScreen;
    public GameObject backgroundAudio;
    private AudioSource backgroundSource;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSource = backgroundAudio.GetComponent<AudioSource>();
        meshScreen = screen.GetComponent<MeshRenderer>();
        meshScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!videoPlayer.isPlaying)
        {
            meshScreen.enabled = false;
            backgroundSource.Play();
        }
    }

    public void AttivaDisattiva()
    {
        if (meshScreen.enabled)
        {
            meshScreen.enabled = false;
            videoPlayer.Pause();
        }
        else if(!meshScreen.enabled)
        {
            meshScreen.enabled = true;
            videoPlayer.Play();
        }
    }

    public void Disattiva()
    {
        if (meshScreen.enabled)
        {
            meshScreen.enabled = false;
            videoPlayer.Pause();
        }
    }
}
