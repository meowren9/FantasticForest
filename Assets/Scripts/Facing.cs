using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour {


    public GameObject player;
    public float speed = 4f;

	void Update () {

        var playP = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        var targetRotation = Quaternion.LookRotation(playP - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

    }


}
