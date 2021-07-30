using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Note 
{
    [HideInInspector] public string name = "note";
    [Tooltip("when in this beat should the note play?")] public float start_time;    //note birthtime expressed in terms of beats since the song starts. Note that the note takes 1sec to travel before it is its time.
    [Tooltip("length of note where 0.25 is a quarter of a beat")] public float duration;      //stands for the length of the note in terms of beats > 0.5 is halfnote, 0.25 is quarternote etc
    [Tooltip("which key to press")] public char input='a';
    
    public note_state state=note_state.incoming;
    [HideInInspector] public GameObject sibling_anticipator = null;

    public enum note_state{incoming,active,missed, hit }        

    /*
    public Note(int position) 
    {
        start_time = position;
        duration = SongReciever.instance.beat_interval*0.25f;
        input = 'a';
    }
    public Note() 
    {
        duration = SongReciever.instance.beat_interval * 0.25f;  // new float[] { 0.25f, 0.25f, 0.5f, 1f }[Random.Range(0, 4)];
        input = 's';                                            //new char[] { 'a', 's', 'k', 'l' }[Random.Range(0, 4)];
    }
    */

    public void play() 
    {
        state = note_state.incoming;

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
