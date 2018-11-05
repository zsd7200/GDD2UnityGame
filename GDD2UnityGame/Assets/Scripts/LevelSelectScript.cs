using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour
{
    public int level;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnMouseDown()
    {
        GetComponent<Renderer>().material = Resources.Load<Material>("Materials\\ButtonBackdrop_Hover");
    }

    private void OnMouseUp()
    {
        SceneManager.LoadScene("Level" + level);
    }
}
