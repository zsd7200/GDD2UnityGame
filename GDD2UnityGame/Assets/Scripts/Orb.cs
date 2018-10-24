﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType { Red, Yellow, Green, Blue, Black}
public class Orb : MonoBehaviour {
    public OrbType type;
	// Use this for initialization
	void Start () {
        switch (type) //Loads model and color (still need models)
        {
            case OrbType.Red:
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                gameObject.tag = "Red";
                break;
            case OrbType.Yellow:
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                gameObject.tag = "Yellow";
                break;
            case OrbType.Green:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                gameObject.tag = "Green";
                break;
            case OrbType.Blue:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                gameObject.tag = "Blue";
                break;
            case OrbType.Black:
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                gameObject.tag = "Black";
                break;
        }
	}
}
