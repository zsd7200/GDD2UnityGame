using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifAnim : MonoBehaviour
{

    public Texture2D sheet;
    Sprite[] frames;
    int fps = 33;

    void Start()
    {
        frames = Resources.LoadAll<Sprite>("Spritesheets\\" + sheet.name);
        Debug.Log(sheet.name);
        Debug.Log(frames.Length);
    }

    // Update is called once per frame
    void Update ()
    {
        int index = (int)((Time.time * fps) % frames.Length);
        GetComponent<SpriteRenderer>().sprite = frames[index];
    }
}
