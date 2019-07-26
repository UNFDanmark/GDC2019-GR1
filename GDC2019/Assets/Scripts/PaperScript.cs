using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    public bool accept;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && accept == true || Input.GetKeyDown(KeyCode.D) && accept == false)
        {
            print("success");
        }
        else if (Input.GetKeyDown(KeyCode.A) && accept == false || Input.GetKeyDown(KeyCode.D) && accept == true)
        {
            print("Fail");
        }
    }
}
