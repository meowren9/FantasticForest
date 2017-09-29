using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Papaya : MonoBehaviour, IInputClickHandler
{

    int status = 0;

    //flies
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;

    public LazySloth sloth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnInputClicked(InputClickedEventData eventData)
    {
        switch(status)
        {
            case 0:
                f1.SetActive(false);
                status++;
                break;

            case 1:
                f2.SetActive(false);
                status++;
                break;

            case 2:
                f3.SetActive(false);
                //change sloth

                sloth.GotPapaya();

                break;
        }
    }



}
