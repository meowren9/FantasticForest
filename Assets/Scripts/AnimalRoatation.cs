using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalRoatation : MonoBehaviour {

    public bool rotating = true;
    public float speed = 4f;

    public Transform target;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (rotating)
        {

            var targetP = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            var targetRotation = Quaternion.LookRotation(targetP - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        }
    }


}
