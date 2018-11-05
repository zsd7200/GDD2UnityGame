using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    public int winScore;
    public int score = 0;

    private void Start()
    {
        winScore = FindObjectOfType<GameScript>().winScore;
    }

    // Update is called once per frame
    void Update ()
    {
        if (winScore - score >= 0)
            gameObject.GetComponent<TMP_Text>().text = "Item Energy: " + (winScore - score);
        else
            gameObject.GetComponent<TMP_Text>().text = "Item Energy: 0";
    }
}
