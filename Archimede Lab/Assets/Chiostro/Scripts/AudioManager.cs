using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject backgroundAudio;
    public GameObject buttonAffreschi;
    public GameObject buttonArchitettura;
    public GameObject buttonCostruzione;
    public GameObject buttonComplesso;
    public GameObject buttonPozzo;
    public GameObject buttonTerritorio;
    public GameObject buttonUtilizzo;

    private AudioSource sourceBackground;
    private AudioSource audioAffreschi;
    private AudioSource audioArchitettura;
    private AudioSource audioCostruzione;
    private AudioSource audioComplesso;
    private AudioSource audioPozzo;
    private AudioSource audioTerritorio;
    private AudioSource audioUtilizzo;

    public AudioSource audioPrincipale;

    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
        sourceBackground = backgroundAudio.GetComponent<AudioSource>();
        audioAffreschi = buttonAffreschi.GetComponent<AudioSource>();
        audioArchitettura = buttonArchitettura.GetComponent<AudioSource>();
        audioComplesso = buttonComplesso.GetComponent<AudioSource>();
        audioPozzo = buttonPozzo.GetComponent<AudioSource>();
        audioTerritorio = buttonTerritorio.GetComponent<AudioSource>();
        audioUtilizzo = buttonUtilizzo.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioPrincipale.isPlaying && isPressed)
        {
            sourceBackground.enabled = true;
            sourceBackground.Play();
            isPressed = false;
        }
    }

    public void Play(int buttonIndex)
    {
        if (!audioPrincipale.isPlaying)
        {
            switchIndex(buttonIndex);
            isPressed = true;
            audioPrincipale.Play();
        }
        else
        {
            switchIndex(buttonIndex);
            isPressed = false;
            audioPrincipale.Stop();
            sourceBackground.enabled = true;
            sourceBackground.Play();
        }
    }

    void switchIndex(int buttonIndex)
    {
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
}
