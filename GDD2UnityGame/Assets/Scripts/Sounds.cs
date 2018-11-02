using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

    public AudioSource audioSource; //Used to handle audio
    public AudioClip moveSound; //Used when an object is moved
    public AudioClip matchSound; //Used when an object is matched
                                 // Use this for initialization
    void Start () {
        audioSource = new AudioSource();
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
