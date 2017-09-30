using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    AudioSource myAudio;
    public AudioClip[] clips;

	void Start () {
        myAudio = GetComponent<AudioSource>();
    }
	

    public void PlayClip(string name)
    {
        myAudio.Stop();
        foreach (AudioClip clip in clips)
        {
            if (clip.name == name)
                myAudio.PlayOneShot(clip);
        }

    }

    public void StopClip()
    {
        myAudio.Stop();
    }

}
