using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] gameObjects;

    public bool isActiveOnStart = false;

    private float delay = 2.0f;

    void Start() 
    {
        SetObjects();
    }

    public void Toggle()
    {
        isActiveOnStart = !isActiveOnStart;
        SetObjects();
    }

    public void SetObjects()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(isActiveOnStart);
        }
    }
}
