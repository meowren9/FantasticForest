using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
public class MovingShrubs : MonoBehaviour, IInputClickHandler {

    Renderer rend;
    ShrubManager shrubs;

    bool isShaking = false;
    bool offest = true;
    float timmer = 0;

    AudioSource bushAudio;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();

        shrubs = GameObject.Find("MovingShrubs").GetComponent<ShrubManager>();
        bushAudio = GetComponent<AudioSource>();
    }

   

    private void Update()
    {
        if(isShaking)
        {
            if(timmer >= 0.05)
            {

                if(offest)
                {
                    transform.Translate(0.1f, 0, 0);
                    
                }
                else
                {
                    transform.Translate(-0.1f, 0, 0);
                }

                offest = !offest;
                timmer = 0;

            } else {
                timmer += Time.deltaTime;
            }

        }

    }


    public void Shake()
    {
        //rend.material.color = Color.white;
        isShaking = true;
        bushAudio.Play();
    }

    public void StopShaking()
    {
        //rend.material.color = new Color32(31, 53, 16, 1);
        isShaking = false;
        bushAudio.Stop();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {

        if(isShaking)
        {
            //rend.material.color = Color.red;
            shrubs.shaking = false;
			StopShaking ();
            bushAudio.Stop();
            //jump out a jugar right here
            shrubs.JumpJuagar(transform);
        }

    }


}
