using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Man;
    public bool accept;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        success();
        
        
    }
    public void success()
    {
        if (Input.GetKeyDown(KeyCode.A) && accept == true || Input.GetKeyDown(KeyCode.D) && accept == false && GameObject.FindGameObjectWithTag("Man") != null)
        {
            print("success");
            score++;
            UpdateScoreText();
            DestroyMan();
        }
        else if (Input.GetKeyDown(KeyCode.A) && accept == false || Input.GetKeyDown(KeyCode.D) && accept == true && GameObject.FindGameObjectWithTag("Man") != null)
        {
            print("Fail");
            DestroyMan();
        }
    }
    void DestroyMan()
    {
        Destroy(GameObject.FindWithTag("Man"));
        if(GameObject.FindGameObjectWithTag("Man") != null)
        {
            Invoke("SpawnMan", 0.5f);
        }
        
       
    }
    void SpawnMan()
    {
        Instantiate(Man, Vector3.zero, Quaternion.identity);
    }
    void UpdateScoreText()
    {
        GetComponent<Text>().text = "Score: " + score;
    }
}
