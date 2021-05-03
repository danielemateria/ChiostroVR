using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Attiva : MonoBehaviour
{
    public GameObject TV;
    public GameObject screen;
    public VideoPlayer videoPlayer;
    public MeshRenderer meshTV;
    public MeshRenderer meshScreen;
    public GameObject backgroundAudio;
    private AudioSource backgroundSource;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSource = backgroundAudio.GetComponent<AudioSource>();
        meshTV = TV.GetComponent<MeshRenderer>();
        meshTV.enabled = false;
        meshScreen = screen.GetComponent<MeshRenderer>();
        meshScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(meshTV.enabled && !videoPlayer.isPlaying)
        {
            meshTV.enabled = false;
            backgroundSource.Play();
        }
    }

    public void AttivaDisattiva()
    {
        if (meshTV.enabled)
        {
            meshTV.enabled = false;
            meshScreen.enabled = false;
            videoPlayer.Pause();
        }
        else
        {
            meshTV.enabled = true;
            meshScreen.enabled = true;
            videoPlayer.Play();
        }
    }

    public void Disattiva()
    {
        if (meshTV.enabled)
        {
            meshTV.enabled = false;
            meshScreen.enabled = false;
            videoPlayer.Pause();
        }
    }
}
