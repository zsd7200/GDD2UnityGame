using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Awake() runs when object becomes active
    private void Awake()
    {
        // get allorbs array
        GameObject[,] allOrbs = GameObject.FindObjectOfType<GameScript>().allOrbs;

        // loop through and set every orb to be frozen
        for (int i = 0; i < GameObject.FindObjectOfType<GameScript>().height; i++)
            for (int j = 0; j < GameObject.FindObjectOfType<GameScript>().width; j++)
                GameObject.FindObjectOfType<GameScript>().allOrbs[i, j].GetComponent<OrbScript>().frozen = true;
    }

}
