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

	// Use this for initialization
	void Start ()
    {
        
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
        GameObject up;
        GameObject down;
        GameObject left;
        GameObject right;

        this.UpdatePosition(); //Update the current position of the selected orb

        //If the orb to the above is not out of range
        if (!(this.row + 1 > board.height - 1))
        {
            up = board.allOrbs[row + 1, column];
        }
        else //CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            up = board.allOrbs[0, column];
        }

        //If the orb to the above is not out of range
        if (!(this.row - 1 < 0))
        {
            down = board.allOrbs[row - 1, column];
        }
        else//CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            down = board.allOrbs[board.height-1, column];
        }

        //Right
        if (!(this.column + 1 > board.width - 1))
        {
            right = board.allOrbs[row, column + 1];
        }
        else//CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            right = board.allOrbs[row, 0];
        }

        //left
        if (!(this.column - 1 < 0))
        {
            left = board.allOrbs[row, column - 1];
        }
        else//CHANGE THESE BASED OFF OF WHAT WE DECIDE AS A TEAM, currently I am checking immediate neighbors, even if it wrapped
        {
            left = board.allOrbs[row, board.width-1];
        }


        //Check Vert
        if (this.tag == up.tag && this.tag == down.tag)
        {
            Debug.Log("VERTICAL MATCH");
            Debug.Log("CURRENT ORB" + row + "," + column);
            Debug.Log("UP ORB" + (row + 1) + "," + column);
            Debug.Log("DOWN ORB" + (row - 1) + "," + column);
        }

        //Check Horizontal
        if (this.tag == left.tag && this.tag == right.tag)
        {
            Debug.Log("HORIZONTAL MATCH");
            Debug.Log("CURRENT ORB" + row + "," + column);
            Debug.Log("RIGHT ORB" + row + "," + (column + 1));
            Debug.Log("LEFT ORB" + row + "," + (column - 1));
        }

        //If there is a match of 3, check to see if following orbs in that direction also match
        //Delete checking wrapped orbs
        //Delete Debug.Logs



    }
}
