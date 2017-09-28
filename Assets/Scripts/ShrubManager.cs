using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrubManager : MonoBehaviour {


    public MovingShrubs[] shrubs;
    public GameObject player;
    public bool shaking;
    int index = 0;
    int direction = 1;

    public GameObject juagar;

	// Use this for initialization
	void Start () {
        StartCoroutine(Shake());
    }

    public void StartShaking()
    {
        shaking = true;
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {

        while (shaking)
        {

            //Debug.Log(index);
            shrubs[index].Shake();

            float second = Random.Range(1, 2);

            yield return new WaitForSeconds(second);
            shrubs[index].StopShaking();

            index += direction;
            if (index > 4 || index < 0)
            {
                direction = -direction;
                index += direction;
            }

        }

    }

    public void JumpJuagar (Transform shrub_trans)
    {
        juagar.SetActive(true);
        juagar.transform.position= shrub_trans.position;

        var playP = new Vector3(player.transform.position.x, -1.5f, player.transform.position.z);
        var targetRotation = Quaternion.LookRotation(playP - shrub_trans.position);
        juagar.transform.rotation = targetRotation;

        //jump animation

        BasicAnimal animal = juagar.GetComponent<BasicAnimal>();
        animal.ResetMovement();
    }


}
