using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Sloth : MonoBehaviour, IFocusable, IInputClickHandler
{

    string animal_name = "Sloth";

    public float climb_speed;
    public Vector3 top;
    public Vector3 bottom;

   

    bool climbing_down;
    bool climbing_up;

    private float startTime;
    private float journeyLength;

    Animator anim;

    int point;
    public int point_need;
    bool already_change_state = false;
    HintManager manager;


    

    void Awake () {
        point = 0;
        climbing_down = false;
        climbing_up = false;
        journeyLength = Vector3.Distance(top, bottom);
        anim = GetComponent<Animator>();
        //test
        //ClimbDown();
        //RunAway();
    }
	
	void Update () {

        if(climbing_down)
        {

            float distCovered = (Time.time - startTime) * climb_speed;
            float fracJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(top, bottom, fracJourney);

            if(transform.position.y == bottom.y)
            {
                Debug.Log("stop climb down");
                climbing_down = false;
                anim.SetBool("isClimbing", false);
                
            }

        }

        if(climbing_up)
        {
            float distCovered = (Time.time - startTime) * climb_speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(bottom, top, fracJourney);

            if (transform.position.y == top.y)
            {
                Debug.Log("stop climb up");
                climbing_up = false;
                anim.SetBool("isClimbing", false);
                gameObject.SetActive(false);
            }
        }

        if (point >= point_need && !already_change_state)
        {
            //manager.state += 1;
            Debug.Log("change state");
            manager = GameObject.Find("HintManager").GetComponent<HintManager>();
            manager.ChangeAnimal(animal_name);
            already_change_state = true;
        }


    }

    public void ClimbDown()
    {
        startTime = Time.time;
        climbing_down = true;
        anim.SetBool("isClimbing", true);

    }

    public void RunAway()
    {
        startTime = Time.time;
        climbing_up = true;
        anim.SetBool("isClimbing", true);
    }


    public void OnFocusEnter()
    {

        anim.SetBool("isGazing", true);

    }

    public void OnFocusExit()
    {

        anim.SetBool("isGazing", false);

    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        point++;
        Debug.Log(point);
    }


}
