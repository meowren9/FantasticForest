using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class RedPanda : MonoBehaviour, IInputClickHandler, IFocusable
{

    public int status = 0;
    public Transform disappear_point;

    AnimalMovement pandaMovement;
    Animator pandaAnim;

    public GameObject apple;

    public SlothTree slothTree;


	void Start () {
        pandaMovement = GetComponent<AnimalMovement>();
        pandaAnim = GetComponent<Animator>();
        StartCoroutine(Mumble());
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if(status == 0)//lying -> requesting
        {
            Debug.Log("click");
            //change animation\
            pandaAnim.SetTrigger("requesting");

            //start talking about apple

            StopCoroutine(Mumble());
            status = 1;
        }

        if (status == 1)
        {
            //repeat requesting apple voice
            Debug.Log("where is my apple man?");

        }

        if(status == 2)
        {
            //repeat sloth is on tree
            Debug.Log("Mr. sloth is on the tree");

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (status == 1)
        {
            if(other.name == "Apple")
            {
                //set apple position to redpanda head

                other.gameObject.SetActive(false);
                apple.SetActive(true);


                //change animation
                pandaAnim.SetTrigger("apple_get");

                //sound
                Debug.Log("thank you");
                Debug.Log("Mr. sloth is on the tree");

                slothTree.StartEffect();

                //bublle: find sloth on tree

                status = 2;
              

            }
        }

        if(status == 3)
        {
            if(other.tag == "disappear")
            {
                gameObject.SetActive(false);
            }
        }

    }

    
    public void RunAway()
    {

        status = 3;
        //sound
        Debug.Log("good luck");
        
        //animation: stand -> run

        StartCoroutine(Disappear());

    }
    

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(5f);
        pandaMovement.StartMovement(disappear_point);
    }

    public float mumble_interval;

    IEnumerator Mumble()
    {
        while(status == 0)
        {
            yield return new WaitForSeconds(mumble_interval);
            Debug.Log("you can't find treasure without my help");
            //repeat annoying voice
        }
    }

    public void OnFocusEnter()
    {

        Debug.Log("enter red");

    }

    public void OnFocusExit()
    {

        Debug.Log("exit red");

    }

    // bubble up



}
