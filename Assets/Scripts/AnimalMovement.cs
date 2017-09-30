using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour {

    bool moving;

    //movement
    Transform startMarker;
    Transform endMarker;
    public float movingSpeed = 0.1F;
    private float startTime;
    private float journeyLength;

    //test
    //public Transform test;

    void Start () {
        //test
        //StartMovement(test);
    }
	
	void Update () {

        if (moving)
        {
            float distCovered = (Time.time - startTime) * movingSpeed;
            float fracJourney = distCovered / journeyLength;

            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        }
    }

    public void StartMovement(Transform endPoint)
    {
        startTime = Time.time;
        startMarker = transform;
        endMarker = endPoint;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        moving = true;
        
    }

}
