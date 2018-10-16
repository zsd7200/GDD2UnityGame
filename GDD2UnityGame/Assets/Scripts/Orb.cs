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
                gameObject.GetComponent<MeshRenderer>().materials[0] = Resources.Load("Material/Orb Red") as Material;
                break;
            case OrbType.Yellow:
                gameObject.GetComponent<MeshRenderer>().materials[0] = Resources.Load("Material/Orb Yellow") as Material;
                break;
            case OrbType.Green:
                gameObject.GetComponent<MeshRenderer>().materials[0] = Resources.Load("Material/Orb Green") as Material;
                break;
            case OrbType.Blue:
                gameObject.GetComponent<MeshRenderer>().materials[0] = Resources.Load("Material/Orb Blue") as Material;
                break;
            case OrbType.Black:
                gameObject.GetComponent<MeshRenderer>().materials[0] = Resources.Load("Material/Orb Black") as Material;
                break;
        }
	}
}
