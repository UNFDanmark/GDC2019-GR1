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
        if (!Instance)
            Instance = gameObject;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //spiller lyden fra specific GameObject's AudioSource
    public void PlayOnSpot(GameObject Audio_Source, string AssetName, float Volume)
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
    public void PlayItNow()
    {
        PlayDelayed("HammerSlag", GameObject.Find("MyTestGuy"), 3);
        Debug.Log("This Is Doing Someting");
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
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }
}
