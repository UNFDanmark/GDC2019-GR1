using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonPressAudio : MonoBehaviour
{
    public void PlayAudio()
    {
        FindObjectOfType<AudioManager>().Play(FindObjectOfType<AudioManager>().gameObject, "Slag(slår i bord) v3", 1);
    }
}
