using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdownScript : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 120;
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        GetComponent<Text>().text = "Time Left: " + time.ToString("f0");

        if (time <= 0) print("Game Over");
    }
}
