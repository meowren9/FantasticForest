using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
public class LazySloth : MonoBehaviour, IInputClickHandler, IFocusable
{

    int status = 0;

    AnimalMovement slothMove;
    public Transform top;
    public Transform bottom;

    public GameObject jaguar;
    public GameObject papaya;

	// Use this for initialization
	void Awake () {
        
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClimbDown()
    {
        slothMove = GetComponent<AnimalMovement>();
        slothMove.StartMovement(bottom);

        Debug.Log("who is there");
    }

    public void ClimbUp()
    {
        status = 3;

        //change animation: idle -> walk

        Debug.Log("good luck young man!");
        slothMove.StartMovement(top);
    }


    public void GotPapaya()
    {
        //change animation: peace -> high

        //sound

        Debug.Log("hahahah! thank you so much!");

        Debug.Log("boom shaka laka!");

        
        Debug.Log("jaguar king is right behind you!");
        jaguar.SetActive(true);
        status = 2;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (status == 0 && other.name == "sp2")//stop climbing down
        {
            //change animation

            //start talk
            Debug.Log("ah... young man, you must here for the treasure, could you do me a favor?");
            Debug.Log("I want that papaya,could you please get rid of the flies?");

            papaya.SetActive(true);

            //stop talking
            status = 1;
            
        }

        if(status == 3 && other.name == "sp1")//disappear
        {
            gameObject.SetActive(false);
        }

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {

        if (status == 1)
        {
            //repeat requesting papaya voice
            Debug.Log("yell out the flies, please");

        }

        if (status == 2)
        {
            //repeat sloth is on tree
            Debug.Log("Mr. jaguar is right behind you");
        }

    }

    public void OnFocusEnter()
    {

        //Debug.Log("enter red");

    }

    public void OnFocusExit()
    {

        //Debug.Log("exit red");

    }


}
