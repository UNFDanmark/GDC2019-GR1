using UnityEngine.Audio;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static GameObject Instance;
    public List<AudioClip> Sounds = new List<AudioClip>();

    void Start()
    {
        if(!Instance)
            Instance = gameObject;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
    public void PlaySolo(GameObject Audio_Source, string AssetName, float Volume)
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
        {
            Audio_Source.GetComponent<AudioSource>().clip = Sounds[PositionInList];
            Audio_Source.GetComponent<AudioSource>().volume = Volume;
            Audio_Source.GetComponent<AudioSource>().Play();
            Invoke("PlaySoundTrackAgain", Sounds[PositionInList].length);
        }
    }
    [Range(0,1)]public float SoundTrackVolume;
    public AudioClip SoundTrack;
    void PlaySoundTrackAgain()
    {
        GetComponent<AudioSource>().clip = SoundTrack;
        GetComponent<AudioSource>().volume = SoundTrackVolume;
        GetComponent<AudioSource>().Play();
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
    //spiller lyden fra på et præcis vector3 efter delay
    public void PlayDelayedAtPoint(string AssetName, Vector3 Point, float Delay)
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
        {
            GameObject AudioPlayer = new GameObject();
            AudioPlayer.AddComponent<AudioSource>();
            AudioPlayer.GetComponent<AudioSource>().clip = Sounds[PositionInList];
            AudioPlayer.GetComponent<AudioSource>().PlayDelayed(Delay);
            Destroy(AudioPlayer, Sounds[PositionInList].length);
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

    //with Cancel effect instead of stagging
    AudioClip NextClip;
    public static GameObject AudioSourceForCancel;
    //spiller lyden fra på et præcis vector3 efter delay
    public void PlayDelayedAtPointWithCancel(string AssetName, Vector3 Point, float Delay)
    {
        int Position = 0;
        int PositionInList = Sounds.Count;
        foreach (AudioClip clipNames in Sounds)
        {
            if (clipNames.name == AssetName)
                PositionInList = Position;
            Position++;
        }

        Debug.Log("Clip played : " + Sounds[PositionInList].name);
        if (PositionInList != Sounds.Count)
        {
            Debug.Log("Clip played : " + Sounds[PositionInList].name);
            if (AudioSourceForCancel)
            {
                Invoke("StopAudioSourceForCancel", Delay);
                //AudioSourceForCancel.GetComponent<AudioSource>().Stop();
                CancelInvoke("DestroyForCancel");
                Invoke("SetAduioSourceForCancel", Delay);
                NextClip = Sounds[PositionInList];
                //AudioSourceForCancel.GetComponent<AudioSource>().clip = Sounds[PositionInList];
                //AudioSourceForCancel.GetComponent<AudioSource>().PlayDelayed(Delay);
                Invoke("DestroyForCancel", Sounds[PositionInList].length);
            }
            else
            {
                GameObject AudioPlayer = new GameObject();
                AudioPlayer.AddComponent<AudioSource>();
                AudioPlayer.GetComponent<AudioSource>().clip = Sounds[PositionInList];
                AudioPlayer.GetComponent<AudioSource>().PlayDelayed(Delay);
                AudioSourceForCancel = AudioPlayer;
                Invoke("DestroyForCancel", Sounds[PositionInList].length);
            }
            //Destroy(AudioPlayer, Sounds[PositionInList].length);
        }
    }
    void DestroyForCancel()
    {
        Destroy(AudioSourceForCancel);
        Debug.Log("Destroyed AudioSource");
    }
    void StopAudioSourceForCancel()
    {
        AudioSourceForCancel.GetComponent<AudioSource>().Stop();
        Debug.Log("Canceled AudioSource");
    }
    void SetAduioSourceForCancel()
    {
        AudioSourceForCancel.GetComponent<AudioSource>().clip = NextClip;
        AudioSourceForCancel.GetComponent<AudioSource>().Play();
    }
    //spiller lyden fra en specific GameObject's AudioSource på en Vector3 placering
    public void PlayAtPositionWithCancel(string AssetName, Vector3 AfspilningsPlacering, float Volume)
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
        {
            if (AudioSourceForCancel)
            {
                AudioSourceForCancel.GetComponent<AudioSource>().Stop();
                CancelInvoke("DestroyForCancel");
                AudioSourceForCancel.transform.position = AfspilningsPlacering;
                AudioSourceForCancel.GetComponent<AudioSource>().clip = Sounds[PositionInList];
                AudioSourceForCancel.GetComponent<AudioSource>().Play();
                Invoke("DestroyForCancel", Sounds[PositionInList].length);
            }
            else
            {
                GameObject AudioPlayer = new GameObject();
                AudioPlayer.transform.position = AfspilningsPlacering;
                AudioPlayer.AddComponent<AudioSource>();
                AudioPlayer.GetComponent<AudioSource>().spatialBlend = 1;
                AudioPlayer.GetComponent<AudioSource>().clip = Sounds[PositionInList];
                //AudioPlayer.GetComponent<AudioSource>().PlayDelayed(Delay);
                //AudioSource.PlayClipAtPoint(Sounds[PositionInList], AfspilningsPlacering, Volume);
                AudioPlayer.GetComponent<AudioSource>().Play();
                AudioSourceForCancel = AudioPlayer;
                Invoke("DestroyForCancel", Sounds[PositionInList].length);
            }
        }
    }
    //for test
    public void PlayTestSound()
    {
        Play(gameObject, "Bell", 0.4F);
    }
}
