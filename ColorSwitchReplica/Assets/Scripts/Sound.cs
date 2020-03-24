using UnityEngine.Audio;
using UnityEngine;
/// <summary>
/// This Class contains the sound properties for the audio manager
/// </summary>
[System.Serializable]
public class Sound
{
    // name of the effect
    public string name;
    // the audio clip
    public AudioClip clip;
    //Audio source for the audio manager
    [HideInInspector]
    public AudioSource source;
    //Volume of the clip
    [Range(0f, 1f)]
    public float volume;
    //Pitch of the effect
    [Range(0.1f, 3f)]
    public float pitch;
    //Looping boolean useful for background music
    public bool loop;
}
