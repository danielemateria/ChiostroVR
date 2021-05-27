using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PozzoAppear : MonoBehaviour
{
    private Vector3 pos = new Vector3(-24.45f, -0.24f, -22.94f);
    private Vector3 pos2 = new Vector3(-24.45f, -3f, -22.94f);
    
    public void Open()
    {
        transform.LeanMove(pos, 0.8f);
    }

    public void Close()
    {
        transform.LeanMove(pos2, 0.8f);
    }
}