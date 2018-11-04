using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    private ScoreCounter scoreCounter;

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

        // set scorecounter object
        scoreCounter = FindObjectOfType<ScoreCounter>();

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
                StartCoroutine(MoveAnim(orb, 0.09f, new Vector3(nextPos, row)));

                //orb.transform.position = new Vector3((nextPos - 0.099993f), row); // subtract height/2 to keep the line from moving all around the screen

                orb.transform.position = new Vector3(nextPos, row);
                orb.name = "( " + row + ", " + nextPos + " )";
                allOrbs[row, i] = storedOrb;
                storedOrb = orb;
            }

            for (int i = 0; i < width; i++)
                CheckMatch(row, i);
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
                StartCoroutine(MoveAnim(orb, 0.09f, new Vector3(nextPos, row)));

                //orb.transform.position = new Vector3((nextPos + 0.099993f), row);

                orb.transform.position = new Vector3(nextPos, row);
                orb.name = "( " + row + ", " + nextPos + " )";
                if (i == width - 1) allOrbs[row, i] = storedOrb;
                else allOrbs[row, i] = allOrbs[row, (i + 1) % width];
            }

           

            for (int i = 0; i < width; i++)
                CheckMatch(row, i);
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
                StartCoroutine(MoveAnim(orb, 0.09f, new Vector3(column, nextPos)));

                //orb.transform.position = new Vector3(column, (nextPos - 0.099993f));

                orb.transform.position = new Vector3(column, nextPos);
                orb.name = "( " + nextPos + ", " + column + " )";
                allOrbs[i, column] = storedOrb;
                storedOrb = orb;
            }

            for (int i = 0; i < height; i++)
                CheckMatch(i, column);
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
                StartCoroutine(MoveAnim(orb, 0.09f, new Vector3(column, nextPos)));

                //orb.transform.position = new Vector3(column, (nextPos + 0.099993f));

                orb.transform.position = new Vector3(column, nextPos);
                orb.name = "( " + nextPos + ", " + column + " )";
                if (i == height - 1) allOrbs[i, column] = storedOrb;
                else allOrbs[i, column] = allOrbs[(i + 1) % height, column];
            }

            for (int i = 0; i < height; i++)
                CheckMatch(i, column);
        }
    }

    public void CheckMatch(int row, int column)
    {
        GameObject orb = allOrbs[row, column];
        //Find Up down left and right
        GameObject up, down, left, right, up2, down2, left2, right2;

        orb.GetComponent<OrbScript>().UpdatePosition(); //Update the current position of the selected orb

        #region Setting up/down/left/right/etc. GameObjects

        //If the orb to the above is not out of range
        if (!(row + 1 > height - 1))
            up = allOrbs[row + 1, column];
        else
            up = null;

        if (!(row + 2 > height - 1))
            up2 = allOrbs[row + 2, column];
        else
            up2 = null;

        //If the orb to the above is not out of range
        if (!(row - 1 < 0))
            down = allOrbs[row - 1, column];
        else
            down = null;

        if (!(row - 2 < 0))
            down2 = allOrbs[row - 2, column];
        else
            down2 = null;

        //Right
        if (!(column + 1 > width - 1))
            right = allOrbs[row, column + 1];
        else
            right = null;

        if (!(column + 2 > width - 1))
            right2 = allOrbs[row, column + 2];
        else
            right2 = null;

        //left
        if (!(column - 1 < 0))
            left = allOrbs[row, column - 1];
        else
            left = null;

        if (!(column - 2 < 0))
            left2 = allOrbs[row, column - 2];
        else
            left2 = null;

        #endregion

        // list to hold every orb matched in one movement
        List<GameObject> matchedOrbs = new List<GameObject>();
        matchedOrbs.Add(orb);

        //Check Vert
        if (up && up.tag == orb.tag)
        {
            matchedOrbs.Add(up.gameObject);
            if (up2 && up2.tag == orb.tag)
            {
                matchedOrbs.Add(up2.gameObject);
                Debug.Log("Up 2 match");
            }
        }

        if (down && down.tag == orb.tag)
        {
            matchedOrbs.Add(down.gameObject);

            if (down2 && down2.tag == orb.tag)
            {
                matchedOrbs.Add(down2.gameObject);
                Debug.Log("Down 2 match");
            }
        }

        if (matchedOrbs.Count >= 3)
        {
            Debug.Log("Vertical " + matchedOrbs.Count + " Match");
            scoreCounter.score += 100 * matchedOrbs.Count;
            Respawn(matchedOrbs);
        }

        //Clears list for next check
        matchedOrbs.Clear();
        matchedOrbs.Add(orb);

        //Check Horz
        if (left && left.tag == orb.tag)
        {
            matchedOrbs.Add(left.gameObject);
            if (left2 && left2.tag == orb.tag)
            {
                matchedOrbs.Add(left2.gameObject);
                Debug.Log("Left 2 match");
            }
        }
        if (right && right.tag == orb.tag)
        {
            matchedOrbs.Add(right.gameObject);
            if (right2 && right2.tag == orb.tag)
            {
                matchedOrbs.Add(right2.gameObject);
                Debug.Log("Right 2 match");
            }
        }
        if (matchedOrbs.Count >= 3)
        {
            Debug.Log("Horizontal " + matchedOrbs.Count + " Match");
            scoreCounter.score += 100 * matchedOrbs.Count;
            Respawn(matchedOrbs);
        }
    }

    // method to handle orb deletion and respawn
    void Respawn(List<GameObject> matches)
    {
        foreach (GameObject match in matches)
            StartCoroutine(RespawnAnim(match, 1, new Vector3()));

        foreach (GameObject match in matches)
        {
            match.GetComponent<Orb>().type = (OrbType)Random.Range(0, 9);
            match.GetComponent<Orb>().ChangeOrb();
            StartCoroutine(RespawnAnim(match, 1, new Vector3(0.4f, 0.4f, 0.4f)));
        }

    }

    // movement animation
    private IEnumerator MoveAnim(GameObject orb, float delay, Vector3 newPos)
    {
        float currTime = 0;
        Vector3 start = orb.transform.position;

        while (currTime <= delay)
        {
            orb.transform.position = Vector3.Lerp(start, newPos, currTime / delay);
            currTime += Time.deltaTime;

            if (currTime > delay)
                orb.transform.position = newPos;

            yield return null;
        }
    }

    // respawn animation
    private IEnumerator RespawnAnim(GameObject orb, float delay, Vector3 scale)
    {
        float currTime = 0;

        while (currTime <= delay)
        {
            orb.transform.localScale = Vector3.Lerp(orb.transform.localScale, scale, currTime / delay);
            currTime += Time.deltaTime;
            yield return null;
        }
    }
}
