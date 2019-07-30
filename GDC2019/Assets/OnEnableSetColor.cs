using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnEnableSetColor : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DoThisShit", 0.01F);
    }
    void DoThisShit()
    {
        Debug.Log("OnEnable");
        foreach (Transform t in transform)
        {
            if (t.GetComponent<Text>() != null)
                t.GetComponent<Text>().color = new Color(1, 0, 0, 1);
            if (t.childCount > 0)
                foreach (Transform c in t)
                    if (c.GetComponent<Text>() != null)
                        c.GetComponent<Text>().color = new Color(1, 0, 0, 1);
        }
    }
}
