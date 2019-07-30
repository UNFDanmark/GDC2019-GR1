﻿using System.Collections;
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
    public int hatNumList, hatNumPlayer;
    public Text CriteriaText;


    // Start is called before the first frame update
    void Start()
    {
        
        UpdateScoreText();
        Man = GameObject.FindGameObjectWithTag("Man");
        headObject = GameObject.FindGameObjectWithTag("Head");
        AssetScript = headObject.GetComponent<AssetListScript>();
        
        //ManPos = AssetScript.ManPos;
        hatNumList = Random.Range(0, Hats.Count);
        CriteriaText.text = "Required items:\n" + Hats[hatNumList].name;
    }

    // Update is called once per frame
    void Update()
    {
        hatNumPlayer = headObject.GetComponent<AssetListScript>().hatNum;
        if (hatNumList == hatNumPlayer)
        {
            print("True");
            accept = true;
        }
        else
        {
            print("false");
            accept = false;
        }
        ManPos = AssetScript.ManPos;
        Success();
    }

    public void Success()
    {
        float DelayedExtra = 0;
        if ((Input.GetKeyDown(KeyCode.A) && accept == true || Input.GetKeyDown(KeyCode.D) && accept == false) && GameObject.FindGameObjectWithTag("Man") != null && ManPos.y <= 1)
        {
            DelayedExtra = 0.3f;
            print("success");
            score++;
            UpdateScoreText();
            Respawn = true;
            RespawnMan();
            i++;
            FindObjectOfType<AudioManager>().Play(FindObjectOfType<AudioManager>().gameObject, "Bell", 1);
        }
        else if ((Input.GetKeyDown(KeyCode.A) && accept == false || Input.GetKeyDown(KeyCode.D) && accept == true) && GameObject.FindGameObjectWithTag("Man") != null && ManPos.y <= 1)
        {
            print("Fail");
            Respawn = true;
            RespawnMan();
            FindObjectOfType<TimerCountdownScript>().time -= 10;
        }
        if (Input.GetKeyDown("a"))
            FindObjectOfType<AudioManager>().PlayDelayedAtPointWithCancel("Heaven", new Vector3(0, 3, -23), DelayedExtra); 
        if (Input.GetKeyDown("d"))
        {
            FindObjectOfType<AudioManager>().PlayAtPositionWithCancel("Burn in Hell you son of a bitch", new Vector3(0, -2, -23), 1);
            //FindObjectOfType<AudioManager>().PlayDelayedAtPointWithCancel("Lava", new Vector3(0, -3, -23), 1.2f);
            //FindObjectOfType<AudioManager>().PlayDelayedAtPoint("Burst into Ash", new Vector3(0, -3, -23), 1.6f);
        }
    }

    public int i;
    public int Day = 1;
    public float quota;
    public float DayValBase;
    public float DayVal;
    void RespawnMan()
    {
        if(Respawn == true && ManPos.y <= 3.5f)
        {
            AssetScript.RemoveClothes();
            AssetScript.Restart();
            AssetScript.AddClothes();
            hatNumPlayer = Random.Range(0, Hats.Count);
            
            if (i == quota)
            {
                i = 0;
                Day++;
                DayValBase = (Mathf.Pow(Day, 0.7f));
                DayVal = 5 * DayValBase;
                quota = (Mathf.Round(DayVal));
                FindObjectOfType<TimerCountdownScript>().time = 120;
                hatNumList = Random.Range(0, Hats.Count);

                CriteriaText.text = "Required items:\n" + Hats[hatNumList].name;
            }
        }

    }

    void SpawnMan()
    {
        headObject = Instantiate(Man, Vector3.zero, Quaternion.identity);
         //GameObject.FindGameObjectWithTag("Head");
        AssetListScript AssetScript = headObject.GetComponent<AssetListScript>();
        AssetScript = headObject.GetComponent<AssetListScript>();
        AssetScript.hatNum = hatNumPlayer;
    }
    void UpdateScoreText()
    {
        GetComponent<Text>().text = "Score: " + score;
    }

}
