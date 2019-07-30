using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (time < 0) time = 0;
        float sec = time % 60;
        GetComponent<Text>().text = "Time Left: " + (((time-sec)<60) ? "0" : ((time - sec) / 60).ToString()) + (((int)sec < 10) ? ":0" : ":") + (int)sec;

        if (time <= 0)
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}