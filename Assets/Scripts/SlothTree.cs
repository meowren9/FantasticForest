using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SlothTree : MonoBehaviour, IInputClickHandler
{

    //temp test
    Renderer rend;
    public GameObject sloth;

    public LeafManager leaves;

    bool isShaking = false;
    float timmer;
    bool offest = true;

    AudioSource treeAudio;

    void Start () {
        rend = GetComponent<Renderer>();
        treeAudio = GetComponent<AudioSource>();
        //test
        //StartEffect();
    }
	
	void Update () {

        if (isShaking)
        {
            if (timmer >= 0.2)
            {

                if (offest)
                {
                    transform.Translate(0.08f, 0, 0);

                }
                else
                {
                    transform.Translate(-0.08f, 0, 0);
                }

                offest = !offest;
                timmer = 0;

            }
            else
            {
                timmer += Time.deltaTime;
            }

        }

    }

    public void StartEffect()
    {
        //start dropping leaves here
        //rend.material.color = Color.white;


        
        isShaking = true;

        leaves.StartFalling();
        treeAudio.Play();

    }

    public void StopEffect()
    {
        //stop dropping leaves here
        //rend.material.color = new Color32(31, 53, 16, 1);
        isShaking = false;

        //var leafManager = GameObject.Find("LeafManager");
        //leafManager.SetActive(false);

        leaves.StopFalling();
        treeAudio.Stop();

        Debug.Log("after rend");
        //sloth come down slowly
        sloth.SetActive(true);
        Sloth slothFunc = sloth.GetComponent<Sloth>();
        slothFunc.ClimbDown();
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("click");
        StopEffect();
        //rend.material.color = Color.yellow;

    }



}
