using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	//public so we can access them in the editor.  easier to change for testing
    public int width;
	public int height;
    public float padding = .5f; //Distance between orbs on board
    int size;
	public GameObject[,] allOrbs;

	// Use this for initialization
	void Start ()
    {
		//sets size
		size = width * height;

		//makes 2d array for orbs
		allOrbs = new GameObject[height,width];

        //Fills table with random orbs
        for (int i = 0; i < height; i++){
			for(int j = 0; j < width; j++){
				GameObject orb = Instantiate(Resources.Load("Prefabs/Orb"), new Vector3(j, i), Quaternion.identity) as GameObject;
	            orb.GetComponent<Orb>().type = (OrbType)Random.Range(0, 5); //Will need to change this later because pure random isn't going to get a lot of possible moves
	            //orb.transform.position = new Vector3((-(width - 1) / 2f + i % width) * padding, i / width * padding); //Grid is centered horizontally at the position and builds upward
				orb.name = "( " + i + ", " + j + " )";
				allOrbs[i,j] = orb;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void MovePieces(int row, int column, float swipeAngle)
    {
        // 5            right
        // 90           up
        // -180         left
        // -90          down

        //right swipe
        if (swipeAngle > -45 && swipeAngle <= 45)
        {
            GameObject storedOrb = allOrbs[row, width - 1];
            for (int i = 0; i < width; i++)
            {
                GameObject orb = allOrbs[row, i];
                int nextPos = (i + 1) % width;
                //Debug.Log("if: i = " + i + "   j: " + j);
                orb.transform.position = new Vector3(nextPos, row);
                orb.name = "( " + row + ", " + nextPos + " )";
                allOrbs[row, i] = storedOrb;
                storedOrb = orb;
            }
        }
        //left swipe
    }
}
