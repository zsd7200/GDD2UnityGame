using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour {

	//public so we can access them in the editor.  easier to change for testing
    public int width;
	public int height;
    public float padding = 1f; //Distance between orbs on board
    int size;
	public GameObject[,] allOrbs;

	// Use this for initialization
	void Start ()
    {
		//sets size
		size = width * height;

		//makes 2d array for orbs
		allOrbs = new GameObject[height, width];

        //Fills table with random orbs
        for (int i = 0; i < height; i++){
			for(int j = 0; j < width; j++){
				GameObject orb = Instantiate(Resources.Load("Prefabs/Orb"), new Vector3(j,i), Quaternion.identity) as GameObject; //j - (width/2), i - (height/2)
                orb.GetComponent<Orb>().type = (OrbType)Random.Range(0, 9); //Will need to change this later because pure random isn't going to get a lot of possible moves
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

                // animation poc
                for (int j = 0; j < 100; j++)
                    StartCoroutine(MoveAnim(orb, 0.001f, new Vector3(nextPos, row)));

                orb.transform.position = new Vector3((nextPos - 0.099993f), row); // subtract height/2 to keep the line from moving all around the screen

                orb.name = "( " + row + ", " + nextPos + " )";
                allOrbs[row, i] = storedOrb;
                storedOrb = orb;
            }

            for (int i = 0; i < width; i++)
                allOrbs[row, i].GetComponent<OrbScript>().CheckMatch();
        }
        //left swipe
        else if (swipeAngle > 135 || swipeAngle <= -135)
        {
            GameObject storedOrb = allOrbs[row, 0];
            for (int i = 0; i < width; i++)
            {
                GameObject orb = allOrbs[row, i];
                int nextPos = (i - 1 + width) % width;
                //Debug.Log("if: i = " + i + "   j: " + j);

                // animation poc
                for (int j = 0; j < 100; j++)
                    StartCoroutine(MoveAnim(orb, 0.001f, new Vector3(nextPos, row)));

                orb.transform.position = new Vector3((nextPos + 0.099993f), row);
                orb.name = "( " + row + ", " + nextPos + " )";
                if (i == width - 1) allOrbs[row, i] = storedOrb;
                else allOrbs[row, i] = allOrbs[row, (i + 1) % width];
            }

            for (int i = 0; i < width; i++)
                allOrbs[row, i].GetComponent<OrbScript>().CheckMatch();
        }

        //up swipe
        else if (swipeAngle > 45 && swipeAngle <= 134)
        {
            GameObject storedOrb = allOrbs[height - 1, column];
            for (int i = 0; i < height; i++)
            {
                GameObject orb = allOrbs[i, column];
                int nextPos = (i + 1) % height;
                //Debug.Log("if: i = " + i + "   j: " + j);

                // animation poc
                // something goes wrong here
                // orb goes up slightly higher than it should
                for (int j = 0; j < 100; j++)
                    StartCoroutine(MoveAnim(orb, 0.001f, new Vector3(column, nextPos)));

                orb.transform.position = new Vector3(column, (nextPos - 0.099993f));
                orb.name = "( " + nextPos + ", " + column + " )";
                allOrbs[i, column] = storedOrb;
                storedOrb = orb;
            }

            for (int i = 0; i < height; i++)
                allOrbs[i, column].GetComponent<OrbScript>().CheckMatch();
        }

        //down swipe
        else if (swipeAngle > -135 && swipeAngle <= -45)
        {
            GameObject storedOrb = allOrbs[0, column];
            for (int i = 0; i < height; i++)
            {
                GameObject orb = allOrbs[i, column];
                int nextPos = (i - 1 + height) % height;
                //Debug.Log("if: i = " + i + "   j: " + j);

                // animation poc
                // something goes wrong here
                // after swiping down, the orbs don't set themselves up correctly for some reason
                for (int j = 0; j < 100; j++)
                    StartCoroutine(MoveAnim(orb, 0.001f, new Vector3(column, nextPos)));

                orb.transform.position = new Vector3(column, (nextPos + 0.099993f));
                orb.name = "( " + nextPos + ", " + column + " )";
                if (i == height - 1) allOrbs[i, column] = storedOrb;
                else allOrbs[i, column] = allOrbs[(i + 1) % height, column];
            }

            for (int i = 0; i < height; i++)
                    allOrbs[i, column].GetComponent<OrbScript>().CheckMatch();
        }

        
    }

    // poc movement
    private IEnumerator MoveAnim(GameObject orb, float delay, Vector3 newPos)
    {
        yield return new WaitForSeconds(delay); // waits for the delay
        orb.transform.position = Vector3.Lerp(orb.transform.position, newPos, 1); //new Vector3(newX, orb.transform.position.y, orb.transform.position.z); // sets new position
    }
}
