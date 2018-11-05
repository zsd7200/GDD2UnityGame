using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;

    // Update is called once per frame
    void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
            if (pauseUI.activeSelf == true)
                Resume();
            else
                Pause();
	}

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;

        // loop through and set every orb to NOT be frozen
        for (int i = 0; i < FindObjectOfType<GameScript>().height; i++)
            for (int j = 0; j < FindObjectOfType<GameScript>().width; j++)
                FindObjectOfType<GameScript>().allOrbs[i, j].GetComponent<OrbScript>().frozen = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;

        // loop through and set every orb to be frozen
        for (int i = 0; i < FindObjectOfType<GameScript>().height; i++)
            for (int j = 0; j < FindObjectOfType<GameScript>().width; j++)
            {
                FindObjectOfType<GameScript>().allOrbs[i, j].GetComponent<OrbScript>().frozen = true;
            }

    }

    public void Restart()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
