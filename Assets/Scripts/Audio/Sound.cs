using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    [HideInInspector]
    public AudioSource source;
    public AudioClip clip;

    public bool loop;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(.1f, 1f)]
    public float pitch = 1f;

    public float panStereo;

    
}
