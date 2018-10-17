using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	//public so we can access them in the editor.  easier to change for testing
    GameObject[] field;
    public int width;
	public int height;
    public float padding = .5f; //Distance between orbs on board
	public int startX;
	public int startY;
    int size;
	public GameObject[,] allOrbs;

	// Use this for initialization
	void Start () {
		//sets size
		size = width * height;

		//makes 2d array for orbs
		allOrbs = new GameObject[width,height];

		field = new GameObject[size];

		//Fills table with random orbs
		for(int i = 0; i < width; i++){  //		for(int i = 0 + startX; i < width + startX; i++){
			for(int j = 0; j < height; j++){ //			for(int j = 0 + startY; j < height + startY; j++){
				Vector2 tempPos = new Vector2 (i, j);
				GameObject orb = Instantiate(Resources.Load("Prefabs/Orb"), tempPos, Quaternion.identity) as GameObject;
	            orb.GetComponent<Orb>().type = (OrbType)Random.Range(0, 5); //Will need to change this later because pure random isn't going to get a lot of possible moves
	            //orb.transform.position = new Vector3((-(width - 1) / 2f + i % width) * padding, i / width * padding); //Grid is centered horizontally at the position and builds upward
				orb.name = "( " + i + ", " + j + " )";
				allOrbs[i,j] = orb;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
