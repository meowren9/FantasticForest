using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Cube : MonoBehaviour, IFocusable, IInputClickHandler, ISpeechHandler
{

    Renderer rend;


    void Start()
    {

        rend = GetComponent<Renderer>();

    }

    public void OnFocusEnter()
    {

        Debug.Log("enter");
        rend.material.color = Color.green;


    }

    public void OnFocusExit()
    {

        Debug.Log("exit");
        rend.material.color = Color.white;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {



        rend.material.color = Color.yellow;

    }

    public void OnSpeechKeywordRecognized(SpeechKeywordRecognizedEventData eventData)
    {

        Debug.Log("speaking");
        string word = eventData.RecognizedText.ToLower();
        Debug.Log(word);

        switch (word)
        {
            case "left":
                rend.material.color = Color.blue;
                break;

            case "right":
                rend.material.color = Color.red;
                break;

            default:
                break;
        }


    }



}
