﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] gameObjects;

    public KeyCode action;

    private Animator animator;

    private Switch switchInRange;

    public bool isActiveOnStart = false;

    private float delay = 2.0f;

    void Update()
    {
             if (Input.GetKeyDown(action) && switchInRange != null)
        {
            switchInRange.Toggle();
            animator.SetBool("isOn", true);
        }
        else 
        {
            animator.SetBool("isOn", false);
        }
    }

    void Start() 
    {
        animator = GetComponent<Animator>();
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
