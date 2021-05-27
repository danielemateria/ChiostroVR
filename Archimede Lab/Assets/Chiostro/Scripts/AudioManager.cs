using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public GameObject buttonAffreschi;
    public GameObject buttonArchitettura;
    public GameObject buttonCostruzione;
    public GameObject buttonComplesso;
    public GameObject buttonPozzo;
    public GameObject buttonTerritorio;
    public GameObject buttonUtilizzo;

    private AudioSource audioAffreschi;
    private AudioSource audioArchitettura;
    private AudioSource audioCostruzione;
    private AudioSource audioComplesso;
    private AudioSource audioPozzo;
    private AudioSource audioTerritorio;
    private AudioSource audioUtilizzo;

    public AudioClip backgroundClip;

    public AudioSource audioPrincipale;
    public Slider sliderVolume;

    private bool isPressed;
    void Start()
    {
        isPressed = false;
        audioPrincipale.clip = backgroundClip;
        audioAffreschi = buttonAffreschi.GetComponent<AudioSource>();
        audioArchitettura = buttonArchitettura.GetComponent<AudioSource>();
        audioComplesso = buttonComplesso.GetComponent<AudioSource>();
        audioCostruzione = buttonCostruzione.GetComponent<AudioSource>();
        audioPozzo = buttonPozzo.GetComponent<AudioSource>();
        audioTerritorio = buttonTerritorio.GetComponent<AudioSource>();
        audioUtilizzo = buttonUtilizzo.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioPrincipale.isPlaying && isPressed)
        {
            audioPrincipale.volume = (float)0.2;
            audioPrincipale.clip = backgroundClip;
            audioPrincipale.Play();
            isPressed = false;
        }
    }

    public void Play(int buttonIndex)
    {
        if (!audioPrincipale.isPlaying)
        {
            SwitchIndex(buttonIndex);
            isPressed = true;
            audioPrincipale.Play();
        }
        else
        {
            SwitchIndex(buttonIndex);
            isPressed = false;
            audioPrincipale.Stop();
            audioPrincipale.volume = (float)0.2;
            audioPrincipale.clip = backgroundClip;
            audioPrincipale.Play();
        }
    }

    public void Pressed()
    {
        if (!isPressed)
        {
            Stop();
        }
        else
        {
            Resume();
        }
    }

    public void Stop()
    {
        audioPrincipale.Stop();
        isPressed = true;
    }

    public void Resume()
    {
        audioPrincipale.Play();
        isPressed = false;
    }
    public void BackgroundStop()
    {
        audioPrincipale.Stop();
    }

    public void BackgroundResume()
    {
        if (audioPrincipale.clip != backgroundClip)
        {
            audioPrincipale.clip = backgroundClip;
        }
        audioPrincipale.Play();
    }

    void SwitchIndex(int buttonIndex)
    {
        audioPrincipale.volume = (float)0.5;
        switch (buttonIndex)
        {
            case 1:
                audioPrincipale.clip = audioAffreschi.clip;
                break;

            case 2:
                audioPrincipale.clip = audioArchitettura.clip;
                break;

            case 3:
                audioPrincipale.clip = audioComplesso.clip;
                break;

            case 4:
                audioPrincipale.clip = audioCostruzione.clip;
                break;

            case 5:
                audioPrincipale.clip = audioPozzo.clip;
                break;

            case 6:
                audioPrincipale.clip = audioTerritorio.clip;
                break;

            case 7:
                audioPrincipale.clip = audioUtilizzo.clip;
                break;
        }
    }

    public void SetVolume()
    {
        audioPrincipale.volume = sliderVolume.value;
    }
}