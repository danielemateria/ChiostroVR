using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotspotsManager : MonoBehaviour
{
    public bool hotspostsActive = true;
    public GameObject francescoCollider;
    public GameObject benvenutoCollider;
    public GameObject mappaCollider;
    public GameObject pozzoCollider;
    public GameObject porteCollider;
    public GameObject porteCollider1;
    public GameObject agataCollider;

    public bool buttonsActive = true;
    public GameObject buttonAffreschi, buttonArchitettura, buttonComplesso, buttonCostruzione, buttonPozzo, buttonTerritorio, buttonUtilizzo;

    private GameObject[] colliders = new GameObject[7];
    private GameObject[] buttons = new GameObject[7];
    public Canvas istruzioni;
    public OVRPlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        benvenutoCollider.SetActive(false);
        colliders[0] = francescoCollider;
        colliders[1] = benvenutoCollider;
        colliders[2] = mappaCollider;
        colliders[3] = pozzoCollider;
        colliders[4] = porteCollider;
        colliders[5] = porteCollider1;
        colliders[6] = agataCollider;

        buttons[0] = buttonAffreschi;
        buttons[1] = buttonArchitettura;
        buttons[2] = buttonComplesso;
        buttons[3] = buttonCostruzione;
        buttons[4] = buttonPozzo;
        buttons[5] = buttonTerritorio;
        buttons[6] = buttonUtilizzo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Inizia()
    {
        benvenutoCollider.SetActive(true);
        istruzioni.enabled = false;
    }

    public void AbleDisable()
    {
        if (hotspostsActive)
            Disable();
        else
            Able();
    }

    void Able()
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].SetActive(true);
        }
        hotspostsActive = true;
    }
    void Disable()
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].SetActive(false);
            colliders[i].GetComponent<TurnBack>().hotspot.enabled = false;
        }
        hotspostsActive = false;
    }

    public void AbleDisableButtons()
    {
        if (buttonsActive)
        {
            DisableButtons();
        }
        else
        {
            AbleButtons();
        }
    }

    void AbleButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
        buttonsActive = true;
    }

    void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(false);
        }
        buttonsActive = false;
    }
}