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


	// Use this for initialization
	void Start () {
        //Starting Time
        startTime = 60.0f;
        //Current Time remaining
        timeLeft = startTime;
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
