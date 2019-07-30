using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetyGame : MonoBehaviour
{
    bool Fade;
    float StartTime = 1;
    public List<Text> TheTexts = new List<Text>();
    private void Update()
    {
        if (Fade)
        {
            if (StartTime > 0)
                StartTime -= Time.deltaTime;
            foreach (Text t in TheTexts)
                t.color = new Color(t.color.r, t.color.g, t.color.b, StartTime);
            if (StartTime <= 0)
                Retry();
        }
    }
    public void StartFade()
    {
        Fade = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
}
