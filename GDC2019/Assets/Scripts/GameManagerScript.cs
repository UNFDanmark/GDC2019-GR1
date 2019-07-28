using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Man;
    public bool accept;
    public int score = 0;
    public GameObject headObject;
    public AssetListScript AssetScript;
    public List<GameObject> Hats = new List<GameObject>();
    public int hatNum2, hatNum1;
    // Start is called before the first frame update
    void Start()
    {
        
        UpdateScoreText();
        AssetScript = headObject.GetComponent<AssetListScript>();
        hatNum1 = headObject.GetComponent<AssetListScript>().hatNum;
        hatNum2 = Random.Range(0, Hats.Count);
    }

    // Update is called once per frame
    void Update()
    {
        Success();
        AssetListScript AssetScript = headObject.GetComponent<AssetListScript>();
        AssetScript.hatNum = hatNum1;
        if(hatNum2 == hatNum1)
        {
            print("True");
        }
        
    }

    public void Success()
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
            Invoke("SpawnMan", 1);
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
