using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static GameObject Instance;
    public List<AudioClip> Sounds = new List<AudioClip>();

    void Start()
    {
        /*if (!Instance)
            Instance = gameObject;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);*/
    }

    //Stop all Lyd
    public void StopAll()
    {
        foreach (AudioSource a in FindObjectsOfType<AudioSource>())
            a.Stop();
    }

    //Stop specific Sound
    public void Stop(GameObject AudioSourceGameObject)
    {
        AudioSourceGameObject.GetComponent<AudioSource>().Stop();
    }

    //spiller lyden fra specific GameObject's AudioSource
    public void Play(GameObject Audio_Source, string AssetName, float Volume)
    {
        int Position = 0;
        int PositionInList = Sounds.Count;
        foreach (AudioClip clipNames in Sounds)
        {
            if (clipNames.name == AssetName)
                PositionInList = Position;
            Position++;
        }

        if (PositionInList != Sounds.Count)
            Audio_Source.GetComponent<AudioSource>().PlayOneShot(Sounds[PositionInList], Volume);
    }
    //spiller lyden fra en specific GameObject's AudioSource efter delay
    public void PlayDelayed(string AssetName, GameObject AudioSourceGameObject, float Delay)
    {
        int Position = 0;
        int PositionInList = Sounds.Count;
        foreach (AudioClip clipNames in Sounds)
        {
            if (clipNames.name == AssetName)
                PositionInList = Position;
            Position++;
        }
        /*GameObject AudioPlayer = new GameObject();
        AudioPlayer.AddComponent<AudioSource>();
        AudioPlayer.GetComponent<AudioSource>().clip = Sounds[PositionInList];
        AudioPlayer.GetComponent<AudioSource>().PlayDelayed(Delay);
        Destroy(AudioPlayer, Sounds[PositionInList].length);*/

        if (PositionInList != Sounds.Count)
        {
            AudioSourceGameObject.GetComponent<AudioSource>().clip = Sounds[PositionInList];
            AudioSourceGameObject.GetComponent<AudioSource>().PlayDelayed(Delay);
        }
    }
    //spiller lyden fra en specific GameObject's AudioSource på en Vector3 placering
    public void PlayAtPosition(string AssetName, Vector3 AfspilningsPlacering, float Volume)
    {
        int Position = 0;
        int PositionInList = Sounds.Count;
        foreach (AudioClip clipNames in Sounds)
        {
            if (clipNames.name == AssetName)
                PositionInList = Position;
            Position++;
        }

        if (PositionInList != Sounds.Count)
            AudioSource.PlayClipAtPoint(Sounds[PositionInList], AfspilningsPlacering, Volume);
    }
    //for test
    public void PlayTestSound()
    {
        Play(gameObject, "Bell", 0.4F);
    }
}
