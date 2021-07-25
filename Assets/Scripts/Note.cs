using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note 
{
    public float start_time;    //when the note is spawned. Note that the note takes 1sec to travel before it is its time.
    public float duration;
    public char input='a';
    public note_state state=note_state.incoming;

    public GameObject sibling_anticipator = null;

    public enum note_state{incoming,missed, hit, perfect }        

    public Note(int position) 
    {
        start_time = position* SongReciever.instance.beat_interval;
        duration = SongReciever.instance.beat_interval*0.25f;
        input = 'a';
    }

    public void play() 
    {
        Debug.Log("spawned "+input);
        switch (input)
        {
            case 'a': { sibling_anticipator = NoteAnticipator.SpawnANote(this); break; }
            case 's': { sibling_anticipator = NoteAnticipator.SpawnSNote(this); break; }
            case 'k': { sibling_anticipator = NoteAnticipator.SpawnKNote(this); break; }
            case 'l': { sibling_anticipator = NoteAnticipator.SpawnLNote(this); break; }

            default:
                break;


        }
        SongReciever.instance.StartCoroutine(SongReciever.instance.ExtendedPlay(this));
    }

}
