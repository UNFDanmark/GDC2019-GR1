using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetListScript : MonoBehaviour
{

    //list of objects
    public List<GameObject> hats = new List<GameObject>();
    //list of placements
    List<Vector3> hPlace = new List<Vector3> {new Vector3(0, 12.58f, 0), new Vector3(0, 13.9f, 0), new Vector3(0, 8.19f, 2)};
    void Start()
    {

        int hatNum = Random.Range(0, hats.Count);
            print(hatNum);

            //spawns object
                GameObject spawnObject = Instantiate(hats[hatNum], transform);
                print(hats[1].transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
