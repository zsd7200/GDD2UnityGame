using System.Collections;
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
                break;
            case OrbType.Yellow:
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case OrbType.Green:
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                break;
            case OrbType.Blue:
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case OrbType.Black:
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                break;
        }
	}
}
