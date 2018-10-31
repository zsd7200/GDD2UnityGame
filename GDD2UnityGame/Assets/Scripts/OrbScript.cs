using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {

	private Vector3 firstTouchPos;
	private Vector3 finalTouchPos;
	public float swipeAngle = 0;

	public int row;
	public int column;
	private GameScript board;
	private GameObject otherdot;

    private ScoreCounter scoreCounter;

	// Use this for initialization
	void Start ()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
		board = FindObjectOfType<GameScript>(); //Find the current board
		row = (int)transform.position.y; //Find the starting row
		column = (int)transform.position.x; //Find the starting column
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Update Row and Column
        if(row != (int)transform.position.y) row = (int)transform.position.y;
        if(column != (int)transform.position.x) column = (int)transform.position.x;
    }
    void UpdatePosition()
    {
        //Update Row and Column
        if (row != (int)transform.position.y) row = (int)transform.position.y;
        if (column != (int)transform.position.x) column = (int)transform.position.x;
    }

	private void OnMouseDown()
    {
		firstTouchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        // scale object so its bigger
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void OnMouseUp()
    {
		finalTouchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		CalcAngle();

        // scale object back to original size
        // this does not revert a gameObject if it is looped to the other side
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    void CalcAngle()
    {
		swipeAngle = Mathf.Atan2 (finalTouchPos.y - firstTouchPos.y, finalTouchPos.x - firstTouchPos.x) * 180 / Mathf.PI;
		//Debug.Log (swipeAngle);
        board.MovePieces(row, column, swipeAngle);
    }

    public void CheckMatch()
    {
        //Find Up down left and right
        GameObject up, down, left, right, up2, down2, left2, right2;

        UpdatePosition(); //Update the current position of the selected orb

        //If the orb to the above is not out of range
        if (!(row + 1 > board.height - 1))
        {
            up = board.allOrbs[row + 1, column];
        }

        else //CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            up = board.allOrbs[0, column];
        }

        if (!(row + 2 > board.height - 2))
            up2 = board.allOrbs[row + 2, column];
        else
            up2 = board.allOrbs[0, column];

        //If the orb to the above is not out of range
        if (!(row - 1 < 0))
        {
            down = board.allOrbs[row - 1, column];
        }

        else//CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            down = board.allOrbs[board.height-1, column];
        }

        if (!(row - 2 < 0))
            down2 = board.allOrbs[row - 2, column];
        else
            down2 = board.allOrbs[board.height - 2, column];

        //Right
        if (!(column + 1 > board.width - 1))
        {
            right = board.allOrbs[row, column + 1];
        }

        else//CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            right = board.allOrbs[row, 0];
        }

        if (!(column + 2 > board.width - 2))
            right2 = board.allOrbs[row, column + 2];
        else
            right2 = board.allOrbs[row, 0];

        //left
        if (!(column - 1 < 0))
        {
            left = board.allOrbs[row, column - 1];
        }

        else//CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            left = board.allOrbs[row, board.width-1];
        }

        if (!(column - 2 < 0))
            left2 = board.allOrbs[row, column - 2];
        else
            left2 = board.allOrbs[row, board.width - 1];



        // list to hold every orb matched in one movement
        List<GameObject> matchedOrbs = new List<GameObject>();


        // Check Vert
        if (tag == up.tag && tag == up2.tag && tag == down.tag && tag == down2.tag)
        {
            Debug.Log("Vertical 5 Match");
            scoreCounter.score += 500;

            // add all orbs in if statement to matchedOrbs list
            matchedOrbs.Add(up);
            matchedOrbs.Add(up2);
            matchedOrbs.Add(down);
            matchedOrbs.Add(down2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == up.tag && tag == down.tag && tag == up2.tag)
        {
            Debug.Log("Vertical 4 Match -- Up 2");
            scoreCounter.score += 400;

            matchedOrbs.Add(up);
            matchedOrbs.Add(up2);
            matchedOrbs.Add(down);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == up.tag && tag == down.tag && tag == down2.tag)
        {
            Debug.Log("Vertical 4 Match -- Down 2");
            scoreCounter.score += 400;

            matchedOrbs.Add(up);
            matchedOrbs.Add(down);
            matchedOrbs.Add(down2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == down.tag && tag == down2.tag)
        {
            Debug.Log("Vertical Match -- Down 2");
            scoreCounter.score += 200;

            matchedOrbs.Add(down);
            matchedOrbs.Add(down2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == up.tag && tag == up2.tag)
        {
            Debug.Log("Vertical Match -- Up 2");
            scoreCounter.score += 200;

            matchedOrbs.Add(up);
            matchedOrbs.Add(up2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == up.tag && tag == down.tag)
        {
            Debug.Log("VERTICAL MATCH");
            scoreCounter.score += 200;

            matchedOrbs.Add(up);
            matchedOrbs.Add(down);
            matchedOrbs.Add(gameObject);
        }

        // Check Horizontal
        if (tag == left.tag && tag == left2.tag && tag == right.tag && tag == right2.tag)
        {
            Debug.Log("Horizontal 5 Match");
            scoreCounter.score += 500;

            matchedOrbs.Add(left);
            matchedOrbs.Add(left2);
            matchedOrbs.Add(right);
            matchedOrbs.Add(right2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == left.tag && tag == right.tag && tag == left2.tag)
        {
            Debug.Log("Horizontal 4 Match -- left 2");
            scoreCounter.score += 400;

            matchedOrbs.Add(left);
            matchedOrbs.Add(left2);
            matchedOrbs.Add(right);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == left.tag && tag == right.tag && tag == right2.tag)
        {
            Debug.Log("Horizontal 4 Match -- right 2");
            scoreCounter.score += 400;

            matchedOrbs.Add(left);
            matchedOrbs.Add(right);
            matchedOrbs.Add(right2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == right.tag && tag == right2.tag)
        {
            Debug.Log("Horizontal Match -- right 2");
            scoreCounter.score += 200;

            matchedOrbs.Add(right);
            matchedOrbs.Add(right2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == left.tag && tag == left2.tag)
        {
            Debug.Log("Horizontal Match -- left 2");
            scoreCounter.score += 200;

            matchedOrbs.Add(left);
            matchedOrbs.Add(left2);
            matchedOrbs.Add(gameObject);
        }
        else if (tag == left.tag && tag == right.tag)
        {
            Debug.Log("HORIZONTAL MATCH");
            scoreCounter.score += 200;

            matchedOrbs.Add(left);
            matchedOrbs.Add(right);
            matchedOrbs.Add(gameObject);
        }

        //If there is a match of 3, check to see if following orbs in that direction also match
        //Delete checking wrapped orbs

        Respawn(matchedOrbs);

    }

    // method to handle orb deletion and respawn
    void Respawn(List<GameObject> matches)
    {
        foreach(GameObject orb in matches)
        {
            // change color of every matched orb
            orb.GetComponent<Renderer>().material.color = new Color32(79, 255, 255, 1);
        }
    }
}
