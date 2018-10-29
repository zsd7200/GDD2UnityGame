using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    public int score = 0;

	// Use this for initialization
	void Start ()
    {
        score = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(gameObject.GetComponent<TMP_Text>().text);
        gameObject.GetComponent<TMP_Text>().text = "Score: " + score;
    }
}
