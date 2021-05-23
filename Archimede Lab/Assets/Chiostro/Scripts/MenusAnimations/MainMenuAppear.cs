using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAppear : MonoBehaviour
{
    public Canvas menu;

    private void Start()
    {
        menu.transform.localScale = Vector3.zero;
    }
    public void Open()
    {
        menu.transform.LeanScale(Vector3.one, 0.5f);
    }

    public void Close()
    {
        menu.transform.LeanScale(Vector3.zero, 0.8f).setEaseInBack();
    }
}