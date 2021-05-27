using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas menuPrincipale;
    public Canvas menuAudio;
    public Canvas menuVideo;
    public Canvas menuOptions;

    bool principale, audiom, video, options;
    void Start()
    {
        principale = false;
        audiom = false;
        video = false;
        options = false;
        menuPrincipale.enabled = false;
        menuAudio.enabled = false;
        menuVideo.enabled = false;
        menuOptions.enabled = false;
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Touch.Two))
        {
            if (menuAudio.enabled)
                menuAudio.enabled = false;
            if (menuVideo.enabled)
                menuVideo.enabled = false;
            if (menuOptions.enabled)
                menuOptions.enabled = false;


            if (principale)
            {
                principale = false;
                menuPrincipale.enabled = false;
            }
            else
            {
                principale = true;
                menuPrincipale.enabled = true;
            }
        }
    }

    public void OpenCloseAudioMenu()
    {
        if (!audiom)
        {
            audiom = true;
            menuPrincipale.enabled = false;
            menuAudio.enabled = true;
        }
        else
        {
            audiom = false;
            menuPrincipale.enabled = true;
            menuAudio.enabled = false;
        }
    }

    public void OpenCloseVideoMenu()
    {
        if (!video)
        {
            video = true;
            menuPrincipale.enabled = false;
            menuVideo.enabled = true;
        }
        else
        {
            video = false;
            menuPrincipale.enabled = true;
            menuVideo.enabled = false;
        }
    }

    public void OpenCloseOptionsMenu()
    {
        if (!options)
        {
            options = true;
            menuOptions.enabled = true;
            menuPrincipale.enabled = false;
        }
        else
        {
            options = false;
            menuPrincipale.enabled = true;
            menuOptions.enabled = false;
        }
    }
}