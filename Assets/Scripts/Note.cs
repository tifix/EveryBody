using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note 
{
    public float start_time;
    public float duration;
    public char input;
    public note_state state=note_state.incoming;

    public enum note_state{incoming,missed, hit, perfect }        

    public Note(int position) 
    {
        start_time = position*PlayerInput.instance.beat_interval;
        duration = PlayerInput.instance.beat_interval*0.25f;
        input = 'A';
    }

    public void play() 
    {
        Debug.Log("bam"); 
        PlayerInput.instance.StartCoroutine(PlayerInput.instance.ExtendedPlay(this));
    }

}
