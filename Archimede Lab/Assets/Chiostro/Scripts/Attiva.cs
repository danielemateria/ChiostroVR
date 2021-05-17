using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Attiva : MonoBehaviour
{
    private AudioManager audioManager;
    public GameObject TV;
    public GameObject screen;
    public VideoPlayer videoPlayer;
    public MeshRenderer meshScreen;
    bool playing;

    // Start is called before the first frame update
    void Start()
    {
        meshScreen = screen.GetComponent<MeshRenderer>();
        meshScreen.enabled = false;
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!videoPlayer.isPlaying && playing)
        {
            meshScreen.enabled = false;
            playing = false;
        }
    }

    public void AttivaDisattiva()
    {
        AudioSource sourceBackground = audioManager.backgroundAudio.GetComponent<AudioSource>();
        audioManager.audioPrincipale.clip = sourceBackground.clip;
        if (meshScreen.enabled)
        {
            meshScreen.enabled = false;
            videoPlayer.Stop();
            playing = false;
            sourceBackground.Play();
        }
        else if(!meshScreen.enabled)
        {
            meshScreen.enabled = true;
            videoPlayer.Play();
            playing = true;
            sourceBackground.Stop();
        }
    }

    public void Disattiva()
    {
        if (meshScreen.enabled)
        {
            meshScreen.enabled = false;
            videoPlayer.Pause();
            playing = false;
        }
    }
}
