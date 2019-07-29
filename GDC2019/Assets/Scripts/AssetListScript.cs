using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetListScript : MonoBehaviour
{

    //list of objects
    public List<GameObject> hats = new List<GameObject>();
    //list of placements
    List<Vector3> hPlace = new List<Vector3> {new Vector3(0, 12.58f, 0), new Vector3(0, 13.9f, 0), new Vector3(0, 8.19f, 2)};
    public int hatNum;
    public GameManagerScript ManagerScript;
    public GameObject GameManager;
    GameObject Hat;
    
    public Vector3 ManPos = new Vector3();
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        ManagerScript = GameManager.GetComponent<GameManagerScript>();

        int hatNum = Random.Range(0, hats.Count);

        //spawns object
        GameObject spawnObject = Instantiate(hats[hatNum], transform);
                print(hatNum);
    }

    // Update is called once per frame
    void Update()
    {
        ManPos = transform.parent.position;
    }

    public void AddClothes()
    {
        hatNum = Random.Range(0, hats.Count);

        //spawns object
        GameObject spawnObject = Instantiate(hats[hatNum], transform);
        print(hatNum);
    }

    public void RemoveClothes()
    {
        Hat = GameObject.FindGameObjectWithTag("Hat");
        GameObject.Destroy(Hat);
    }

    public void Restart()
    {
        transform.parent.position = new Vector3(0, 6, -23);
    }
}
