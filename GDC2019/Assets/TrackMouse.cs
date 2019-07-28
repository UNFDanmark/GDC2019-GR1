using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMouse : MonoBehaviour
{
    [Range(0,1920)]public int x;
    [Range(0, 1080)]public int y;
    [Range(0, 500)] public float Distance;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(1 - Vector2.Distance(Input.mousePosition, new Vector2(x, y)) / Distance);
        if (Vector2.Distance(Input.mousePosition, new Vector2(x, y)) < Distance)
           GetComponent<AudioSource>().volume = 1 - Vector2.Distance(Input.mousePosition, new Vector2(x, y)) / Distance;
    }
}
