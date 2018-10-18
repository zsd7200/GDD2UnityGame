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

    float timeLeft;//Remaining time left (Seconds)
    float startTime;//Amount of time that the level started with(Seconds)
    int formattedTime;//Time remaining without decimals
    public GameObject timerDisplay; //GameObject to display time remaining
    float timerSize;//Original X size of the timerObj


	// Use this for initialization
	void Start () {
        //Create a bar for the timer
        timerDisplay = GameObject.FindGameObjectWithTag("TIMER");
        //Starting Time
        startTime = 60.0f;
        //Current Time remaining
        timeLeft = startTime;
        //Find the size of the timer object
        timerSize = timerDisplay.GetComponent<Transform>().localScale.x;

    }
	
	// Update is called once per frame
	void Update () {
        DisplayTime();//Display the current time
        Tick(); //Subtract time left 

        OutOfTime(); //PLACEHOLDER, USE THIS FUNCTION TO DISPLAY THAT THE PLAYER IS OUT OF TIME
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
        
        if (formattedTime % 2 == 0)
        {
            float newTimerSize = timerSize * (formattedTime / startTime); //Set the new size relative to the starting time and how much time is left
            
            timerDisplay.transform.localScale = new Vector3(newTimerSize, timerDisplay.transform.localScale.y, -1); //Set the new size

            Debug.Log(newTimerSize);
        }
    }

    /// <summary>
    /// Adds time to the timer
    /// </summary>
    void AddTime()
    {
        //Increase time (based off of certain events in the game)
        timeLeft += 5.0f;//Increase by 5 seconds
    }

    /// <summary>
    /// Checks to see if there is still time remaining
    /// </summary>
    /// <returns></returns>
    bool OutOfTime()
    {
        if (timeLeft <= 0.0f)//Checks to see if the timeLeft is less than 0
        {
            return true; //if there is no time remaining, return true
        }
        return false; //If there is still time remaining, return false
    }



    /// <summary>
    /// Displays the formatted timer
    /// </summary>
    public void DisplayTime()
    {
        gameObject.GetComponent<TMP_Text>().text = "" + formattedTime; //Find the game object and display the time
    }
}
