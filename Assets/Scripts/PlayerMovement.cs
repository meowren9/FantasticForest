using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform player_camera;

	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player_camera.position.x, 0, player_camera.position.z);
	}
}
