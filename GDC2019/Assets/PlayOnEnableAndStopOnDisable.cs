using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnableAndStopOnDisable : MonoBehaviour
{
    public string ClipName;
    private void OnEnable()
    {
        FindObjectOfType<AudioManager>().PlayNarrator(FindObjectOfType<AudioManager>().gameObject, ClipName, 1);
    }
}
