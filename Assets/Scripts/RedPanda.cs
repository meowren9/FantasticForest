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

    public GameObject riddle_apple;

    public SlothTree slothTree;

    AudioManager pandaAudio;

    bool isLocked = false;


    void Start () {
        pandaMovement = GetComponent<AnimalMovement>();
        pandaAnim = GetComponent<Animator>();
        pandaAudio = GetComponent<AudioManager>();

        //pandaAudio = GetComponent<AudioSource>();
        //pandaAudio.clip = 

        

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
            pandaAudio.PlayClip("PandaRiddle");

            StopCoroutine(Mumble());
            riddle_apple.SetActive(true);

            status = 1;
        }

        if (status == 1)
        {
            //repeat requesting apple voice
            Debug.Log("where is my apple man?");
            //pandaAudio.PlayClip("PandaCue");
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
                pandaAudio.PlayClip("PandaEnding");

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
        pandaAnim.SetTrigger("walking");

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
        yield return new WaitForSeconds(5f);
        while (status == 0)
        {
            
            Debug.Log("you can't find treasure without my help");
            pandaAudio.PlayClip("PandaOverHere");
            yield return new WaitForSeconds(mumble_interval);
            //repeat annoying voice
        }
    }

    public GameObject bubble;

    public void OnFocusEnter()
    {

        Debug.Log("enter red");
        bubble.SetActive(true);


    }

    public void OnFocusExit()
    {

        Debug.Log("exit red");
        bubble.SetActive(false);
    }

    // bubble up


    public void LetAppleGo()
    {
        apple.SetActive(false);
    }


}
