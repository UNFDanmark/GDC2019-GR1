using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BagrundsLyde : MonoBehaviour
{
    public AudioClip[] BackgroundSounds;
    [Range(0, 1)] public float VolumeForBackgroundAudio;

    void Start()
    {
        Play();
    }

    private void Play()
    {
        if (!enabled)
            return;

        foreach (AudioClip clip in BackgroundSounds)
            if (Random.Range(0, 12) == 4)
            {
                FindObjectOfType<AudioManager>().Play(gameObject, clip.name, VolumeForBackgroundAudio);
                Invoke("Play", Random.Range(1, 3));
                return;
            }

        Invoke("Play", 1);
        //Invoke("Play", Random.Range(1, 3));
    }
}
