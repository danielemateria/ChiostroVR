using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotsManager : MonoBehaviour
{
    public bool hotspostsActive = true;
    public GameObject francescoCollider;
    public GameObject benvenutoCollider;
    public GameObject mappaCollider;
    public GameObject pozzoCollider;
    public GameObject porteCollider;
    public GameObject porteCollider1;
    private GameObject[] colliders = new GameObject[6];
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
        }
        hotspostsActive = false;
    }
}