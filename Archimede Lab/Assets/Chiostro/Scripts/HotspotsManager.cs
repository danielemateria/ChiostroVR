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
    public GameObject moriCollider;
    public GameObject santiCollider;

    public bool buttonsActive = true;
    public GameObject buttonAffreschi, buttonArchitettura, buttonComplesso, buttonCostruzione, buttonPozzo, buttonTerritorio, buttonUtilizzo;
    public MeshRenderer francescoCube, mappaCube, pozzoCube, porteCube, agataCube, moriCube, santiCube;

    private GameObject[] colliders = new GameObject[9];
    private GameObject[] buttons = new GameObject[7];
    private MeshRenderer[] cubes = new MeshRenderer[7];

    public Canvas istruzioni;
    public OVRPlayerController player;

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
        colliders[7] = moriCollider;
        colliders[8] = santiCollider;

        buttons[0] = buttonAffreschi;
        buttons[1] = buttonArchitettura;
        buttons[2] = buttonComplesso;
        buttons[3] = buttonCostruzione;
        buttons[4] = buttonPozzo;
        buttons[5] = buttonTerritorio;
        buttons[6] = buttonUtilizzo;

        cubes[0] = francescoCube;
        cubes[1] = mappaCube;
        cubes[2] = pozzoCube;
        cubes[3] = porteCube;
        cubes[4] = agataCube;
        cubes[5] = moriCube;
        cubes[6] = santiCube;
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
            colliders[i].SetActive(true);

        for(int i = 0; i < cubes.Length; i++)
            cubes[i].enabled = true;

        hotspostsActive = true;
    }
    void Disable()
    {
        for(int i = 0; i < colliders.Length; i++)
        {
            colliders[i].SetActive(false);
            colliders[i].GetComponent<TurnBack>().hotspot.enabled = false;
        }

        for(int i = 0; i < cubes.Length; i++)
            cubes[i].enabled = false;

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