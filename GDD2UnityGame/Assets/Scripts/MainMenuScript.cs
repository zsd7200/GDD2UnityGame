using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play");
    }

    public void LevelSelect()
    {
        Debug.Log("Level Select");
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
