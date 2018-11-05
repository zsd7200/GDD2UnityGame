using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public int level;

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material = Resources.Load<Material>("Materials\\ButtonBackdrop_Hover");
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material = Resources.Load<Material>("Materials\\ButtonBackdrop");
    }

    private void OnMouseDown()
    {
        GetComponent<Renderer>().material = Resources.Load<Material>("Materials\\BoardBackdrop");
    }

    private void OnMouseUp()
    {
        SceneManager.LoadScene("Level" + level);
    }
}
