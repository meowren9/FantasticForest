using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingBubble : MonoBehaviour {


    public GameObject player;
    public float height;
    public float speed = 4f;

	void Start () {
		
	}

	void Update () {

        var playP = new Vector3(player.transform.position.x, height, player.transform.position.z);
        var targetRotation = Quaternion.LookRotation(playP - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }


}
