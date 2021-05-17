using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas menuPrincipale;
    public Canvas menuAudio;
    public Canvas menuVideo;
    public Canvas menuOptions;
    void Start()
    {
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

            if (menuPrincipale.enabled)
            {
                menuPrincipale.enabled = false;
            }
            else
            {
                menuPrincipale.enabled = true;
            }
        }
    }

    public void openCloseAudioMenu()
    {
        if (!menuAudio.enabled)
        {
            menuPrincipale.enabled = false;
            menuAudio.enabled = true;
        }
        else
        {
            menuPrincipale.enabled = true;
            menuAudio.enabled = false;
        }
    }

    public void openCloseVideoMenu()
    {
        if (!menuVideo.enabled)
        {
            menuPrincipale.enabled = false;
            menuVideo.enabled = true;
        }
        else
        {
            menuPrincipale.enabled = true;
            menuVideo.enabled = false;
        }
    }

    public void openCloseOptionsMenu()
    {
        if (!menuOptions.enabled)
        {
            menuOptions.enabled = true;
            menuPrincipale.enabled = false;
        }
        else
        {
            menuPrincipale.enabled = true;
            menuOptions.enabled = false;
        }
    }
}