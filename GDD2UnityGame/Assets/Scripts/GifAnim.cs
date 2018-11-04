using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifAnim : MonoBehaviour
{
    // set spritesheet in inspector
    public Texture2D sheet;
    Sprite[] frames;
    int fps = 33;

    void Start()
    {
        // load all sprites from spritesheet
        frames = Resources.LoadAll<Sprite>("Spritesheets\\" + sheet.name);
    }

    // Update is called once per frame
    void Update ()
    {
        int index = (int)((Time.time * fps) % frames.Length); // set frame to change into, throttled by fps
        GetComponent<SpriteRenderer>().sprite = frames[index]; // change frame
    }
}
