using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetListScript : MonoBehaviour
{

    //list of objects
    public List<GameObject> hats1 = new List<GameObject>();
    public List<GameObject> chest = new List<GameObject>();
    public List<GameObject> faceHair = new List<GameObject>();
    public List<GameObject> eye = new List<GameObject>();
    //list of placements
    List<Vector3> hPlace = new List<Vector3> {new Vector3(0, 12.58f, 0), new Vector3(0, 13.9f, 0), new Vector3(0, 8.19f, 2)};
    public int hatNum;
    public GameManagerScript ManagerScript;
    public GameObject GameManager;
    GameObject Hat, Hat2, Chest, Eye, FaceHair;
    
    public Vector3 ManPos = new Vector3();
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ManagerScript = GameManager.GetComponent<GameManagerScript>();

        hatNum = Random.Range(0, hats1.Count);

        //spawns object
        GameObject spawnObject = Instantiate(hats1[hatNum], transform);
                print(hatNum);
    }

    // Update is called once per frame
    void Update()
    {
        ManPos = transform.parent.position;
    }

    public void AddClothes()
    {
        hatNum = Random.Range(0, hats1.Count);

        //spawns object
        GameObject spawnObject = Instantiate(hats1[hatNum], transform);
        print(hatNum);
    }

    public void RemoveClothes()
    {
        Hat = GameObject.FindGameObjectWithTag("Hat");
        Chest = GameObject.FindGameObjectWithTag("Chest");
        Eye = GameObject.FindGameObjectWithTag("Eye");
        FaceHair = GameObject.FindGameObjectWithTag("FaceHair");
        GameObject.Destroy(Hat);
        GameObject.Destroy(Chest);
        GameObject.Destroy(Eye);
        GameObject.Destroy(FaceHair);
    }

    public void Restart()
    {
        transform.parent.position = new Vector3(0, 6, -23);
    }
}
