using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbType { Red, Yellow, Green, Blue, Black, Purple, White, Orange, Pink}

public class Orb : MonoBehaviour {

    public OrbType type;
    public GameObject[] symbols = new GameObject[6];

	// Use this for initialization
	void Start ()
    {
        // declare colors not included in unity
        Color orange = new Color32(243, 110, 33, 1); // this is mycourses orange
        Color purple = new Color32(92, 0, 206, 1); // random purple color
        Color pink = new Color32(255, 145, 234, 1); // random pink color, possibly use Color.magenta instead?

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
                gameObject.GetComponent<Renderer>().material.color = purple;
                gameObject.tag = "Purple";
                break;
            case OrbType.White:
                //gameObject.GetComponent<MeshFilter>().mesh = symbols[6].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                gameObject.tag = "White";
                break;
            case OrbType.Orange:
                //gameObject.GetComponent<MeshFilter>().mesh = symbols[7].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = orange;
                gameObject.tag = "Orange";
                break;
            case OrbType.Pink:
                //gameObject.GetComponent<MeshFilter>().mesh = symbols[8].GetComponent<MeshFilter>().sharedMesh;
                gameObject.transform.rotation = Quaternion.Euler(-270, -90, 90);
                gameObject.GetComponent<Renderer>().material.color = pink;
                gameObject.tag = "Pink";
                break;
        }
	}
}
