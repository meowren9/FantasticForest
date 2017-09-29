using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Eye : MonoBehaviour, IFocusable
{
    public Jaguar jaguar;
    Renderer rend;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
    }

    bool analysing = false;
    float timmer = 0;
    public float need;

    void Update()
    {
        if (analysing)
        {
            timmer += Time.deltaTime;
            if (timmer >= need)
            {
                Succeed();
            }
        }

    }

    void StartAnalyse()
    {
        analysing = true;
        timmer = 0f;
        //texture change
        rend.material.color = Color.yellow;
        //sound change
        Debug.Log("Don't blink young man");
    }

    void StopAnalyse()
    {
        analysing = false;
        timmer = 0f;
        //texture change
        rend.material.color = Color.white;
        //sound change
        Debug.Log("where are you looking at");

    }

    void Succeed()
    {
        analysing = false;
        timmer = 0f;

        //change texture
        rend.material.color = Color.blue;
        //sound
        jaguar.Win();

    }

    public void OnFocusEnter()
    {
        StartAnalyse();
    }

    public void OnFocusExit()
    {
        StopAnalyse();

    }
}
