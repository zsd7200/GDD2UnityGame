using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {
    GameObject[] field;
    [SerializeField] const int width = 7;
    [SerializeField] const int height = 15;
    [SerializeField] const float padding = .5f; //Distance between orbs on board
    const int size = width * height;

	// Use this for initialization
	void Start () {
		field = new GameObject[size];
        for(int i = 0; i < size; i++) //Fills table with random orbs
        {
            GameObject orb = Instantiate(Resources.Load("Prefabs/Orb"), new Vector3(), Quaternion.identity) as GameObject;
            orb.GetComponent<Orb>().type = (OrbType)Random.Range(0, 5); //Will need to change this later because pure random isn't going to get a lot of possible moves
            orb.transform.position = new Vector3((-(width - 1) / 2f + i % width) * padding, i / width * padding); //Grid is centered horizontally at the position and builds upward
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
