using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OrbScript : MonoBehaviour {

	private Vector3 firstTouchPos;
	private Vector3 finalTouchPos;
	public float swipeAngle = 0;

	public int row;
	public int column;
	private GameScript board;
	private GameObject otherdot;
    public bool frozen = false;

	// Use this for initialization
	void Start ()
    {
		board = FindObjectOfType<GameScript>(); //Find the current board
		row = (int)transform.position.y; //Find the starting row
		column = (int)transform.position.x; //Find the starting column
        //GameObject.FindGameObjectWithTag("GameOver").SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {
        //Update Row and Column
        if (row != (int)transform.position.y) row = (int)transform.position.y;
        if (column != (int)transform.position.x) column = (int)transform.position.x;
    }

    public void UpdatePosition()
    {
        //Update Row and Column
        if (row != (int)transform.position.y) row = (int)transform.position.y;
        if (column != (int)transform.position.x) column = (int)transform.position.x;
    }

	public void OnMouseDown()
    {
        if (frozen == false)
        {
            firstTouchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // scale object so its bigger
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void OnMouseUp()
    {
        if (frozen == false)
        {
		    finalTouchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		    CalcAngle();

            // scale object back to original size
            // this does not revert a gameObject if it is looped to the other side
            gameObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        }

    }

    void CalcAngle()
    {
		swipeAngle = Mathf.Atan2 (finalTouchPos.y - firstTouchPos.y, finalTouchPos.x - firstTouchPos.x) * 180 / Mathf.PI;
		//Debug.Log (swipeAngle);
        board.MovePieces(row, column, swipeAngle);
    }
}
