using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Awake() runs when object becomes active
    private void Awake()
    {
        // loop through and set every orb to be frozen
        for (int i = 0; i < FindObjectOfType<GameScript>().height; i++)
            for (int j = 0; j < FindObjectOfType<GameScript>().width; j++)
                FindObjectOfType<GameScript>().allOrbs[i, j].GetComponent<OrbScript>().frozen = true;
    }

}
