using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject TV;
    public GameObject screen;
    public VideoPlayer videoPlayer;
    public VideoPlayer videoPlayerPresentazione;
    public VideoPlayer videoPlayerAereo;
    public MeshRenderer meshScreen;
    public MeshRenderer meshBack;
    bool playing;
    public MenuManager menuManager;

    // Start is called before the first frame update
    void Start()
    {
        meshBack.enabled = false;
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.Prepare();
        meshScreen = screen.GetComponent<MeshRenderer>();
        meshScreen.enabled = false;
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!videoPlayer.isPlaying && playing)
        {
            meshBack.enabled = false;
            meshScreen.enabled = false;
            playing = false;
            audioManager.BackgroundResume();
        }
    }
    public void AttivaDisattiva()
    {
        if (meshScreen.enabled)
        {
            meshBack.enabled = false;
            meshScreen.enabled = false;
            videoPlayer.Stop();
            playing = false;
        }
        else if (!meshScreen.enabled)
        {
            meshBack.enabled = true;
            meshScreen.enabled = true;
            videoPlayer.Play();
            playing = true;
        }
    }

    public void PlaySelectedVideo(int index)
    {
        if (!meshScreen.enabled)
        {
            SwitchIndex(index);
            meshBack.enabled = true;
            meshScreen.enabled = true;
            playing = true;
            if (videoPlayer.isPlaying)
            {
                menuManager.OpenCloseVideoMenu();
                menuManager.menuPrincipale.enabled = false;
            }
            videoPlayer.Play();
        }
    }

    public void Disattiva()
    {
        if (meshScreen.enabled)
        {
            meshBack.enabled = false;
            meshScreen.enabled = false;
            playing = false;
            videoPlayer.Pause();
        }
    }

    private void SwitchIndex(int index) {
        switch (index)
        {
            case 1:
                videoPlayer.clip = videoPlayerPresentazione.clip;
                break;

            case 2:
                videoPlayer.clip = videoPlayerAereo.clip;
                break;
        }
    }
}