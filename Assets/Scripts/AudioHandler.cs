using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * to be put on the same object as scene switcher. it's one mighty sound handling boye
 * 
 */

public class AudioHandler : MonoBehaviour
{
    public static AudioHandler instance;
    public static AudioSource source;
    
    public void Awake()
    {
        if (instance == null) { instance = this; source = GetComponent<AudioSource>(); }
        else Destroy(gameObject);
        
    }

    public static void PlaySFX(AudioClip clip)
    {
        source.volume = 1;
        source.PlayOneShot(clip);
    }
    public static void PlaySFX(AudioClip clip,float volume)
    {
        source.PlayOneShot(clip,volume);
    }
    public static void PlayMusic(AudioClip clip, bool should_loop)
    {
        source.volume = 1;
        source.loop = should_loop;
        source.clip = clip;
        source.Play();
    }
    public void JustPlay()
    {
        source.volume = 1;
        source.loop = false;
        source.Play();
    }

    public static void PlayMusic(AudioClip clip, float delay)
    {
        source.volume = 1;
        if (source.isPlaying && source.clip == clip) return;
        
        source.clip = clip;
        instance.Invoke("JustPlay", delay);
    }
}
