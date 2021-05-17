using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas menuPrincipale;
    public Canvas menuAudio;
    public Canvas menuVideo;
    public Canvas menuOptions;
    public GameObject panel;

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
                OpenPanelMenu();
            }
        }
    }

    public void OpenPanelMenu()
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
    }

    public void OpenCloseAudioMenu()
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

    public void OpenCloseVideoMenu()
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

    public void OpenCloseOptionsMenu()
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