using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    /*
    * Time will always be accurate because we are using timeLeft instead of formatted time.
    * Only use formattedTime to display the time remaining
    * Use timeLeft to do any time calculations
    */

    public GameObject timerDisplay; //GameObject to display time remaining
    public float timeLeft;//Remaining time left (Seconds)
    public float startTime = 60.0f;//Amount of time that the level started with(Seconds)
    int formattedTime;//Time remaining without decimals
    float timerSize;//Original X size of the timerObj
    public Color timerColor = new Color32(207, 145, 0, 0); // default gold color for timer, can be changed in inspector
    public GameObject GameOverText; //Used to tell that the game is over

	// Use this for initialization
	void Start () {
        // set bar color for the timer
        timerDisplay.GetComponent<Renderer>().material.color = timerColor;
        //Current Time remaining
        timeLeft = startTime;
        //Find the size of the timer object
        timerSize = timerDisplay.GetComponent<Transform>().localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft != 0) //If there is still time left, Update
        {
            DisplayTime();//Display the current time
            Tick(); //Subtract time left 
           
        }
        //if no time is left game over
        GameOver();
    }

    /// <summary>
    /// Decreases the time remaining using time between frames.
    /// Should be called every frame
    /// </summary>
    void Tick()
    {
        //Decrease time
        timeLeft = timeLeft - Time.deltaTime; //Subtract the amount of time since the lase frame
        formattedTime = (int)Mathf.Round(timeLeft); //Round the time to the nearest whole number
        if (timeLeft <= 0)
        {
            //If there is no time left set time to 0
            timeLeft = 0.0f;
            formattedTime = 0;
        }
        float newTimerSize = timerSize * (timeLeft / startTime); //Set the new size relative to the starting time and how much time is left 
        timerDisplay.transform.localScale = new Vector3(newTimerSize, timerDisplay.transform.localScale.y, -1); //Set the new size
        
    }

    void GameOver()
    {
        if (timeLeft <= 0)
        {
            //Display Game Over
            GameOverText.SetActive(true);
        }
        //Else do nothing
    }

    /// <summary>
    /// Displays the formatted timer
    /// </summary>
    public void DisplayTime()
    {
        //gameObject.GetComponent<TMP_Text>().text = "" + formattedTime; //Find the game object and display the time
    }
}
