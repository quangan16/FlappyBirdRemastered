using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;


public class SoundManager : Singleton<SoundManager>
{
    public static readonly string  scored = "SCORED";
    public static readonly string hit = "HIT";
    public static readonly string die = "DIE";
    public static readonly string swoosh = "SWOOSH";
    public static readonly string flapwing = "FLAP_WING";

    [SerializeField] public AudioSource audioSrc;
    [SerializedDictionary] public SerializedDictionary<string, AudioClip> _audioClips;

    public void PlayOnce(string key)
    {
        audioSrc.PlayOneShot(_audioClips[key]);
    }
}
