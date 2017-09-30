using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class BasicAnimal : MonoBehaviour, IFocusable, ISpeechHandler, IInputClickHandler
{

	public string animal_name;

	Animator anim;

	//rotation
    public GameObject player;
    float speed = 4f;
    bool rotating = false;


    bool moving = false;


	//movement
    Transform startMarker;
    Transform endMarker;
    public float movingSpeed = 0.1F;
    private float startTime;
    private float journeyLength;


	//?
    bool voiceControl = false;


	//point count
	int point;
    public int point_need;
	bool already_change_state = false;
	HintManager manager;

    //runaway
    public Vector3 disappear;
    Vector3 start_running_point;
    private float runningLength;
    private float startRunningTime;
    bool running;
    public float running_speed;

    //audio
    AudioSource myAudio;
    public AudioClip walkSound;
    public AudioClip tiltSound;
    public AudioClip idleSound;
    public AudioClip runSound;

    private void Awake()
    {
        point = 0;
        anim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        myAudio.clip = idleSound;
    }


    void Start () {
		point = 0;
        anim = GetComponent<Animator>();

        //test
        //RunAway();

    }

	void Update () {

        if(rotating)
        {
            
			var playP = new Vector3 (player.transform.position.x, -1.5f, player.transform.position.z);
			var targetRotation = Quaternion.LookRotation(playP - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

            if(transform.rotation == targetRotation)
            {
				//point ++;
                Debug.Log("rotation finished");
                Debug.Log(point);
                rotating = false;
            }
        }

        if(moving)
        {
            float distCovered = (Time.time - startTime) * movingSpeed;
            float fracJourney = distCovered / journeyLength;

			var startP = new Vector3 (startMarker.position.x, -1.5f, startMarker.position.z);
			var endP = new Vector3 (endMarker.position.x, -1.5f, endMarker.position.z);

			transform.position = Vector3.Lerp(startP, endP, fracJourney);

        }

		if (point >= point_need && !already_change_state) {
            Debug.Log("change state");
            manager = GameObject.Find("HintManager").GetComponent<HintManager>();
			manager.ChangeAnimal(animal_name);
			already_change_state = true;
		}

        if(running)
        {
            float distCovered = (Time.time - startRunningTime) * running_speed;
            float fracJourney = distCovered / runningLength;

            transform.position = Vector3.Lerp(start_running_point, disappear, fracJourney);
        }


    }

    public void OnFocusEnter()
    {

        Debug.Log("enter");
        rotating = true;
        voiceControl = true;

        SetSound(tiltSound);
        anim.SetBool("inGazing", true);

    }

    public void OnFocusExit()
    {

        Debug.Log("exit");
        rotating = false;
        voiceControl = false;
        SetSound(idleSound);
        anim.SetBool("inGazing", false);

    }

    public void OnSpeechKeywordRecognized(SpeechKeywordRecognizedEventData eventData)
    {
        //if(voiceControl) // ?
        Debug.Log("speaking");
        string word = eventData.RecognizedText.ToLower();
        Debug.Log(word);

        
        switch (word)
        {
			case "hi":
                ResetMovement();
                //trigger tilting
                break;

            case "hey":
                //trigger noding
                ResetMovement();
                break;

            case "come":
                ResetMovement();
                break;

            case "here":
				ResetMovement();
                break;

            default:
                break;
        }
    }

	public void ResetMovement() {
		startTime = Time.time;
		startMarker = transform;
		endMarker = player.transform;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
		moving = true;
        //walking animation:
        anim.SetBool("isWalking", true);
        SetSound(walkSound);

    }

	public void OnInputClicked(InputClickedEventData eventData) {

        ResetMovement();
        //heart start
        point ++;
        Debug.Log(point);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {

            Debug.Log("collide with camara");
            //stop walking animation:
            anim.SetBool("isWalking", false);
            moving = false;
            SetSound(idleSound);
        }

        if(other.tag == "disappear")
        {
            running = false;
            anim.SetBool("isRunning", false);
            gameObject.SetActive(false);
        }


    }

    public void RunAway()
    {
        anim.SetBool("isRunning", true);
        SetSound(runSound);
        transform.rotation = Quaternion.LookRotation(disappear - transform.position);

        start_running_point = transform.position;
        runningLength = Vector3.Distance(start_running_point, disappear);
        startRunningTime = Time.time;
        running = true;
    }



    void SetSound(AudioClip choice)
    {
        myAudio.Stop();
        myAudio.clip = choice;
        myAudio.Play();
    }


}
