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
                //menuPrincipale.GetComponent<MainMenuAppear>().Close();
                principale = false;
                menuPrincipale.enabled = false;
            }
            else
            {
                principale = true;
                //menuPrincipale.GetComponent<MainMenuAppear>().Open();
                menuPrincipale.enabled = true;
                //OpenPanelMenu();
            }
        }
    }
    /*public void OpenPanelMenu()
    {
        if(panel != null)
        {
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");
                animator.SetBool("open", !isOpen);
            }
        }
    }*/

    public void OpenCloseAudioMenu()
    {
        if (!audiom)
        {
            audiom = true;
            menuPrincipale.enabled = false;
            menuAudio.enabled = true;
            //menuAudio.GetComponent<MainMenuAppear>().Open();
        }
        else
        {
            audiom = false;
            menuPrincipale.enabled = true;
            menuAudio.enabled = false;
            //menuAudio.GetComponent<MainMenuAppear>().Close();
        }
    }

    public void OpenCloseVideoMenu()
    {
        if (!video)
        {
            video = true;
            menuPrincipale.enabled = false;
            menuVideo.enabled = true;
            //menuVideo.GetComponent<MainMenuAppear>().Open();
        }
        else
        {
            video = false;
            menuPrincipale.enabled = true;
            menuVideo.enabled = false;
            //menuVideo.GetComponent<MainMenuAppear>().Close();
        }
    }

    public void OpenCloseOptionsMenu()
    {
        if (!options)
        {
            options = true;
            menuOptions.enabled = true;
            menuPrincipale.enabled = false;
            //menuOptions.GetComponent<MainMenuAppear>().Open();
        }
        else
        {
            options = false;
            menuPrincipale.enabled = true;
            menuOptions.enabled = false;
            //menuOptions.GetComponent<MainMenuAppear>().Close();
        }
    }
}