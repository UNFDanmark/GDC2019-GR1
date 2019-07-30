using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGameScene : MonoBehaviour
{
    public float StartTime = 1;
    public bool Fade;
    public List<Text> TheTexts = new List<Text>();
    bool Once;

    private void OnEnable()
    {
        Once = false;
    }
    private void Update()
    {
        if (Fade)
        {
            if(StartTime > 0)
                StartTime -= Time.deltaTime;
            foreach (Text t in TheTexts)
                t.color = new Color(1, 0, 0, StartTime);
            if (StartTime <= 0 && !Once)
                BeginGame();
        }
    }
    public void BeginGame()
    {
        StartTime = 1;
        Fade = false;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    public void BeginFade()
    {
        Fade = !Fade;
    }
}
