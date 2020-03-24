using UnityEditor.Audio;
using UnityEngine;
using System;
/// <summary>
/// This Class acts as the audiomanager attached to an empty game object
/// </summary>
public class AudioManager : MonoBehaviour
{
    //list of sounds
    public Sound[] sounds;
    //if the instance is already there the object isn't recreated
    public static AudioManager instance;

    // Called before start to make sure there are no other instances
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        /*
        Play("Theme");
        audioSrc = gameObject.GetComponent<AudioSource>();
        Debug.Log(audioSrc.volume);
        */
    }
    void Update()
    {
        //audioSrc.volume = musicVolume;
        //Sound s = Array.Find(sounds, sound => sound.name == "theme");
        //s.source.volume = musicVolume;
    }
    /// <summary>
    /// Play method to be called from other scripts to enable adding SFX
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }


    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            s.source.Stop();
        }
    }

    public bool isPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
