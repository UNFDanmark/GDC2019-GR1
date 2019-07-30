using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSceneOnClick : MonoBehaviour
{
    public List<GameObject> NewActive = new List<GameObject>();
    public List<GameObject> NewInactive = new List<GameObject>();
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
                t.color = new Color(t.color.r, t.color.g, t.color.b, StartTime);
            if (StartTime <= 0)
                if(!Once)
                    ChangeMenu();
            /*foreach (Behaviour b in GetComponents<Behaviour>())
                if (b == CodeToRun)
                    b.Run();*/
            //SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }
    public void ChangeMenu()
    {
        Fade = false;
        StartTime = 1;
        foreach (GameObject g in NewActive)
        {
            g.SetActive(true);
            if (g.GetComponent<Text>() != null)
                g.GetComponent<Text>().color = new Color(g.GetComponent<Text>().color.r, g.GetComponent<Text>().color.g,
                    g.GetComponent<Text>().color.b, 1);
            if (g.transform.childCount > 0)
                foreach (Transform t in g.transform)
                {
                    if(t.GetComponent<Text>() !=  null)
                        t.GetComponent<Text>().color = new Color(t.GetComponent<Text>().color.r, t.GetComponent<Text>().color.g,
                            t.GetComponent<Text>().color.b, 1);
                    if (t.childCount > 0)
                        foreach (Transform c in t)
                            if(c.GetComponent<Text>() != null)
                                c.GetComponent<Text>().color = new Color(c.GetComponent<Text>().color.r, c.GetComponent<Text>().color.g,
                                    c.GetComponent<Text>().color.b, 1);
                }
        }
        foreach (GameObject b in NewInactive)
            b.SetActive(false);
    }
    public void BeginFade()
    {
        Fade = !Fade;
    }
}
