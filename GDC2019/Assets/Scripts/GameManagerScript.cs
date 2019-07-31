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
    public List<GameObject> Hats1 = new List<GameObject>();
    public List<GameObject> Chest = new List<GameObject>();
    public List<GameObject> FaceHair = new List<GameObject>();
    public List<GameObject> Eye = new List<GameObject>();
    public List<int> intList = new List<int>();
    public int hatNumList, chestNumList, FaceHairNumList, EyeNumList, hatNum, chestNum, faceNum, eyeNum, intListNum;
    public Text CriteriaText;
    public Text DayCountText;


    // Start is called before the first frame update
    void Start()
    {
        Day = 1;
        UpdateScoreText();
        Man = GameObject.FindGameObjectWithTag("Man");
        headObject = GameObject.FindGameObjectWithTag("Head");
        AssetScript = headObject.GetComponent<AssetListScript>();
        
        

        //ManPos = AssetScript.ManPos;
        hatNumList = Random.Range(0, Hats1.Count);
        chestNumList = Random.Range(0, Chest.Count);
        FaceHairNumList = Random.Range(0, FaceHair.Count);
        EyeNumList = Random.Range(0, EyeNumList);
        CriteriaText.text = "Send to Hell if:\n" + Hats1[hatNumList].name;
        DayCountText.text = "Day: " + Day;
    }

    float DelayedExtra = 0;
    // Update is called once per frame
    void Update()
    {
        hatNum = headObject.GetComponent<AssetListScript>().hatNum;
        chestNum = headObject.GetComponent<AssetListScript>().chestNum;
        faceNum = headObject.GetComponent<AssetListScript>().faceNum;
        eyeNum = headObject.GetComponent<AssetListScript>().eyeNum;

        intList.Add(hatNumList);
        intList.Add(chestNumList);
        intList.Add(FaceHairNumList);
        intList.Add(EyeNumList);

        intListNum = Random.Range(0, intList.Count);

        //intList


        if ((hatNumList == hatNum) /* || (chestNumList == chestNum) || (FaceHairNumList == faceNum) || (EyeNumList == eyeNum)*/)
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
        if (((Input.GetKeyDown(KeyCode.A) && accept == false) || (Input.GetKeyDown(KeyCode.D) && accept == true)) && GameObject.FindGameObjectWithTag("Man") != null && ManPos.y <= 1)
        {
            DelayedExtra = 0.3f;
            print("success");
            score++;
            //FindObjectOfType<AudioManager>().Play(FindObjectOfType<AudioManager>().gameObject, "Heaven", 1);
            UpdateScoreText();
            Respawn = true;
            RespawnMan();
            i++;
            //hatNumList = Random.Range(0, Hats1.Count);

        }
        else if (((Input.GetKeyDown(KeyCode.A) && accept == true) || (Input.GetKeyDown(KeyCode.D) && accept == false)) && GameObject.FindGameObjectWithTag("Man") != null && ManPos.y <= 1)
        {
            print("Fail");
            Respawn = true;
            RespawnMan();
            FindObjectOfType<TimerCountdownScript>().time -= timePenalty;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            FindObjectOfType<AudioManager>().PlayDelayedAtPointWithCancel("Heaven", new Vector3(0, 3, -23), DelayedExtra);
        }
            
        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<AudioManager>().PlayAtPositionWithCancel("Burn in Hell you son of a bitch", new Vector3(0, -2, -23), 1);
            //FindObjectOfType<AudioManager>().PlayDelayedAtPointWithCancel("Lava", new Vector3(0, -3, -23), 1.2f);
            //FindObjectOfType<AudioManager>().PlayDelayedAtPoint("Burst into Ash", new Vector3(0, -3, -23), 1.6f);
        }
    }

    public int i;
    public int Day;
    public float quota;
    public float timePenalty = 10;
    public float DayValBase;
    public float DayVal;
    void RespawnMan()
    {
        if(Respawn == true && ManPos.y <= 3.5f)
        {
            AssetScript.RemoveClothes();
            AssetScript.Restart();
            AssetScript.AddClothes();
            hatNum = Random.Range(0, Hats1.Count);
            
            if (i == quota)
            {
                i = 0;
                DayValBase = (Mathf.Pow(Day, 0.9f));
                DayVal = 5 * DayValBase;
                timePenalty += 5;
                quota = (Mathf.Round(DayVal));
                Day++;
                FindObjectOfType<TimerCountdownScript>().time = 120;
                DayList();

                CriteriaText.text = "Send to Hell if:\n" + Hats1[hatNumList].name;
                DayCountText.text = "Day: " + Day;
            }
        }

    }

    void DayList()
    {
        if(Day >= 1)
        {
            hatNumList = Random.Range(0, Hats1.Count);
            hatNum = headObject.GetComponent<AssetListScript>().hatNum;
            if (hatNumList == hatNum)
            {
                print("True");
                accept = true;
            }
            else
            {
                print("false");
                accept = false;
            }
        }
        if(Day >= 3)
        {

        }
        if(Day >= 5)
        {

        }
        if(Day >= 7)
        {

        }
        

    }

    void SpawnMan()
    {
        headObject = Instantiate(Man, Vector3.zero, Quaternion.identity);
         //GameObject.FindGameObjectWithTag("Head");
        AssetListScript AssetScript = headObject.GetComponent<AssetListScript>();
        AssetScript = headObject.GetComponent<AssetListScript>();
        AssetScript.hatNum = hatNum;
    }
    void UpdateScoreText()
    {
        GetComponent<Text>().text = "Klienter: " + score;
    }

}
