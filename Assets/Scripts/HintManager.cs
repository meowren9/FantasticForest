using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour {


    public int state = 0;
	public ShrubManager shrub;
    
    public SlothTree tree;

    public Sloth sloth;
    public BasicAnimal panda;
    public BasicAnimal juagar;
    public GameObject path;
    public GameObject gate;

    public float waitTime;

    

	// Use this for initialization
	void Start () {

        //test
        //ChangeAnimal("Sloth");


    }
	
	public void ChangeAnimal(string current_name) {

        //Debug.Log(current_name);
		switch (current_name)
		{
			case "Panda":
                shrub.StartShaking();
				break;

			case "Jaguar":
                Debug.Log("jaguar");
                tree.StartEffect();
                break;

			case "Sloth":
                // gun shot,animals runing away, path shows
                StartCoroutine(OpenNewMap());
                break;


			default:
				break;
		}


		
	}

    IEnumerator OpenNewMap()
    {

        yield return new WaitForSeconds(waitTime);

        var gun = GameObject.Find("GunSound").GetComponent<AudioSource>();
        var bird = GameObject.Find("BirdSound").GetComponent<AudioSource>();

        gun.Play();
        yield return new WaitForSeconds(0.6f);
        bird.Play();

        panda.RunAway();
        juagar.RunAway();
        sloth.RunAway();

        //need wait?
        path.SetActive(true);
        gate.SetActive(false);

    }


}
