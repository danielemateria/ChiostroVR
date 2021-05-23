using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Canvas commands;
    public bool inPausa = false;
    public Button playPauseButton;
    public Sprite play, pause;

    // Start is called before the first frame update
    void Start()
    {
        commands.enabled = false;
        meshBack.enabled = false;
        meshScreen = screen.GetComponent<MeshRenderer>();
        meshScreen.enabled = false;
        playing = false;
    }

    // Update is called once per frame
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

    private IEnumerator PlayVideoInThisURL(string _url)
    {
        videoPlayer.source = UnityEngine.Video.VideoSource.Url;
        videoPlayer.url = _url;
        videoPlayer.Prepare();

        while (videoPlayer.isPrepared == false)
        {
            yield return null;
        }
        videoPlayer.Play();
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
            //PlayVideoInThisURL(videoPlayer.url);
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