using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{

    public static GameObject Instance;

    // Start is called before the first frame update
    void Start()
    {
        if (!Instance)
            Instance = gameObject;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
