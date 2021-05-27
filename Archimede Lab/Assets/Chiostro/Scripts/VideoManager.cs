using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject TV;
    [SerializeField] private GameObject screen;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoPlayer videoPlayerPresentazione;
    [SerializeField] private VideoPlayer videoPlayerAereo;
    [SerializeField] private MeshRenderer meshScreen;
    [SerializeField] private MeshRenderer meshBack;
    private bool playing;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private Canvas commands;
    [SerializeField] private bool inPausa = false;
    [SerializeField] private Button playPauseButton;
    [SerializeField] private Sprite play, pause;
    [SerializeField] private Slider sliderVolume;

    void Start()
    {
        commands.enabled = false;
        meshBack.enabled = false;
        meshScreen = screen.GetComponent<MeshRenderer>();
        meshScreen.enabled = false;
        playing = false;
    }

    void Update()
    {
        if (!videoPlayer.isPlaying && playing && !inPausa)
        {
            commands.enabled = false;
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
            commands.enabled = false;
            meshBack.enabled = false;
            meshScreen.enabled = false;
            videoPlayer.Stop();
            playing = false;
        }
        else if (!meshScreen.enabled)
        {
            commands.enabled = true;
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
            commands.enabled = true;
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

    public void PlayPause()
    {
        if (!inPausa)
        {
            inPausa = true;
            playPauseButton.image.sprite = play;
            videoPlayer.Pause();
        }
        else
        {
            inPausa = false;
            playPauseButton.image.sprite = pause;
            videoPlayer.Play();
        }
    }

    public void Disattiva()
    {
        if (meshScreen.enabled)
        {
            commands.enabled = false;
            meshBack.enabled = false;
            meshScreen.enabled = false;
            playing = false;
            inPausa = false;
            videoPlayer.Stop();
            audioManager.BackgroundResume();
        }
    }

    public void VolumeVideo()
    {
        if(videoPlayer.clip == videoPlayerPresentazione.clip)
        {
            videoPlayer.SetDirectAudioVolume(videoPlayerPresentazione.audioTrackCount, sliderVolume.value);
        }
        else if(videoPlayer.clip == videoPlayerAereo)
        {
            videoPlayer.SetDirectAudioVolume(videoPlayerAereo.audioTrackCount, sliderVolume.value);
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