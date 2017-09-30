using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class Jaguar : MonoBehaviour, IFocusable
{

    AnimalMovement jaguarMove;
    public Transform treasure;

    public GameObject eyeball;

    int status = 0;

    public LazySloth sloth;


	// Use this for initialization
	void Start () {
        jaguarMove = GetComponent<AnimalMovement>();
    }

	void Update () {

	}


    public void Win()
    {
        //change animation

        //sound
        Debug.Log("Congratuation!");
        jaguarMove.StartMovement(treasure);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(status == 1 && other.tag == "Player")
        {
            Debug.Log("alright young man, now I will read your mind through your eyes, look at my eyes, don't blink");

            eyeball.SetActive(true);
            status = 2;
        }

    }

    public void OnFocusEnter()
    {

        Debug.Log("enter");
        if(status == 0)//first sight
        {
            //MOVE SLOTH
            sloth.ClimbUp();

            //come close young man
            Debug.Log("come close young man.");

            status = 1;
        }
       
    }

    public void OnFocusExit()
    {


    }

    


}
