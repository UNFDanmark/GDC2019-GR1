using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject Man;
    public Vector3 ManPos = new Vector3();
    public bool accept;
    public bool Respawn;
    public int score = 0;
    public GameObject headObject;
    public AssetListScript AssetScript;
    public List<GameObject> Hats = new List<GameObject>();
    public int hatNum2, hatNum1;


    // Start is called before the first frame update
    void Start()
    {
        
        UpdateScoreText();
        Man = GameObject.FindGameObjectWithTag("Man");
        headObject = GameObject.FindGameObjectWithTag("Head");
        AssetScript = headObject.GetComponent<AssetListScript>();
        hatNum1 = headObject.GetComponent<AssetListScript>().hatNum;
        //ManPos = AssetScript.ManPos;
        hatNum2 = Random.Range(0, Hats.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        Success();

        if(hatNum2 == hatNum1)
        {
            print("True");
        }
        ManPos = AssetScript.ManPos;

    }

    public void Success()
    {
        if (Input.GetKeyDown(KeyCode.A) && accept == true || Input.GetKeyDown(KeyCode.D) && accept == false && GameObject.FindGameObjectWithTag("Man") != null && ManPos.y <= 1)
        {
            print("success");
            score++;
            UpdateScoreText();
            Respawn = true;
            RespawnMan();
            
        }
        else if (Input.GetKeyDown(KeyCode.A) && accept == false || Input.GetKeyDown(KeyCode.D) && accept == true && GameObject.FindGameObjectWithTag("Man") != null && ManPos.y <= 1)
        {
            print("Fail");
            Respawn = true;
            RespawnMan();
        }
    }

    void RespawnMan()
    {
        if(Respawn == true && ManPos.y <= 3.5f)
        {
            AssetScript.RemoveClothes();
            AssetScript.Restart();
            AssetScript.AddClothes();
        }

    }

    void SpawnMan()
    {
        headObject = Instantiate(Man, Vector3.zero, Quaternion.identity);
         //GameObject.FindGameObjectWithTag("Head");
        AssetListScript AssetScript = headObject.GetComponent<AssetListScript>();
        AssetScript = headObject.GetComponent<AssetListScript>();
        AssetScript.hatNum = hatNum1;
    }
    void UpdateScoreText()
    {
        GetComponent<Text>().text = "Score: " + score;
    }
}
