using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType { Red, Yellow, Green, Blue, Black, Purple}

public class Orb : MonoBehaviour {

    public OrbType type;
    public GameObject[] symbols = new GameObject[6];

	// Use this for initialization
	void Start () {
        switch (type) //Loads model and color (still need models)
        {
            case OrbType.Red:
                gameObject.GetComponent<MeshFilter>().mesh = symbols[0].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                gameObject.tag = "Red";
                break;
            case OrbType.Yellow:
                gameObject.GetComponent<MeshFilter>().mesh = symbols[1].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                gameObject.tag = "Yellow";
                break;
            case OrbType.Green:
                gameObject.GetComponent<MeshFilter>().mesh = symbols[2].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = Color.green;
                gameObject.tag = "Green";
                break;
            case OrbType.Blue:
                gameObject.GetComponent<MeshFilter>().mesh = symbols[3].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                gameObject.tag = "Blue";
                break;
            case OrbType.Black:
                gameObject.GetComponent<MeshFilter>().mesh = symbols[4].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                gameObject.tag = "Black";
                break;
            case OrbType.Purple:
                gameObject.GetComponent<MeshFilter>().mesh = symbols[5].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = Color.magenta;
                gameObject.tag = "Purple";
                break;
        }
	}
}
