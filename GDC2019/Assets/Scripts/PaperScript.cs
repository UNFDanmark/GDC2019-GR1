﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    public bool accept=true;
    int score;
    public GameObject Man;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        success();
        score = 0;


    }

    public void success()
    {
        if (Input.GetKeyDown(KeyCode.A) && accept == true || Input.GetKeyDown(KeyCode.D) && accept == false)
        {
            print("success");
            score++;
            
        }
        else if (Input.GetKeyDown(KeyCode.A) && accept == false || Input.GetKeyDown(KeyCode.D) && accept == true)
        {
            print("Fail");
        }

        //Man = GameObject.FindWithTag("Man");
        foreach(GameObject man in GameObject.FindGameObjectsWithTag("Man"))
        {
            print(man);
            Destroy(man);
        }
          Destroy(GameObject.FindWithTag("Man"));

        if (GameObject.FindGameObjectWithTag("Man") == null)
        {
            Instantiate(Man, Vector3.zero, Quaternion.identity);
        }

    }
}
