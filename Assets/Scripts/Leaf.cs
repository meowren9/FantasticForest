using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour {

    public float falling_speed;
    public float top;
    public float bottom;

    private float startTime;
    private float journeyLength;



    Vector3 start;
    Vector3 end;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        journeyLength = top - bottom;
        start = new Vector3(transform.position.x,top,transform.position.z);
        end = new Vector3(transform.position.x, bottom, transform.position.z);

        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        float distCovered = (Time.time - startTime) * falling_speed;
        float fracJourney = distCovered / journeyLength;

        
        transform.position = Vector3.Lerp(start, end, fracJourney);

        if (transform.position.y == bottom)
        {
            //Debug.Log("stop climb down");
            Destroy(gameObject);
        }
    }
}
