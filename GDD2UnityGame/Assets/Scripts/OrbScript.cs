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
        
		board = FindObjectOfType<GameScript>();
		row = (int)transform.position.y;
		column = (int)transform.position.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(row != (int)transform.position.y) row = (int)transform.position.y;
        if(column != (int)transform.position.x) column = (int)transform.position.x;
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
        GameObject up, down, left = board.allOrbs[0,0], right = board.allOrbs[0,0];

        // these give index out of array errors
        if (row > 0 && row < board.width - 1)
        {
            if ((row - 1) >= 0)
                left = board.allOrbs[row - 1, column];

            if ((row + 1) < board.width)
                right = board.allOrbs[row + 1, column];
        }

        if (column > 0 && column < board.height - 1)
        {
            if ((column + 1) < board.width)
                up = board.allOrbs[row, column + 1];

            if ((column - 1) >= 0)
                down = board.allOrbs[row, column - 1];
        }

        Debug.Log("This Tag: " + tag);
        Debug.Log("This Name: " + name);
        Debug.Log("Left Tag: " + left.tag);
        Debug.Log("Left Name: " + left.name);
        Debug.Log("Right Tag: " + right.tag);
        Debug.Log("Right Name: " + right.name);

        if (gameObject.tag == left.tag && gameObject.tag == right.tag)
        {
            Debug.Log("sideways match");
        }
    }
}
