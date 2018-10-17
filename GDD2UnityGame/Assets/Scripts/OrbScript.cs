using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbScript : MonoBehaviour {

	private Vector2 firstTouchPos;
	private Vector2 finalTouchPos;
	public float swipeAngle = 0;

	public int row;
	public int column;
	private GameScript board;
	private GameObject otherdot;
	public int targetX;
	public int targetY;

	// Use this for initialization
	void Start () {
        
		board = FindObjectOfType<GameScript> ();
		targetX = (int)transform.position.x;
		targetY = (int)transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		targetX = column;
		targetY = row;

	}

	private void OnMouseDown(){
		firstTouchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

	}

	private void OnMouseUp(){
		finalTouchPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		CalcAngle ();
	}

	void CalcAngle(){
		swipeAngle = Mathf.Atan2 (finalTouchPos.y - firstTouchPos.y, finalTouchPos.x - firstTouchPos.x) * 180 / Mathf.PI;
		Debug.Log (swipeAngle);
	}

	void MovePieces(){
		//right swipe
		if (swipeAngle > -45 && swipeAngle <= 45) {
			for (int i = 0; i < board.width; i++) {
				for (int j = 0; j < board.height; j++) {
					if (j == row) {
						//if its the last emelment
						if(board.allOrbs[i +1,j] == null){
							board.allOrbs [i, j] = board.allOrbs[0, j];
							continue;
						}
						board.allOrbs [i, j] = board.allOrbs[i + 1, j];
					}
				}
			}
		}

		//left swipe
	}


}
