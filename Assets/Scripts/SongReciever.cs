using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongReciever : MonoBehaviour
{
    public static SongReciever instance;
    public SpriteRenderer rhythm_sprite;

    public List<Note> song = new List<Note>();
    public float BPM = 140;
    public float beat_interval;
    public int cur_note = 0;
    public float song_start_time;
    public List<Note> current_notes = new List<Note>();

    public IEnumerator NoteRetrieval()
    {
        while (cur_note < song.Count)
        {
            if (Time.time > song[cur_note].start_time)   //if the time elapsed from the start of the song is longer than the song start point
            {
                song[cur_note].play();
                cur_note++;
            }

            yield return new WaitForFixedUpdate();
        }

        Debug.LogWarning("song finished");

    }

    public IEnumerator ExtendedPlay(Note note)
    {
        yield return new WaitForSeconds(1); //wait for note to travel
        note.state = Note.note_state.active;
        current_notes.Add(note);
        SpriteRenderer SR = note.sibling_anticipator.GetComponent<SpriteRenderer>();
        SR.color = Color.magenta;
        

        yield return new WaitForSeconds(note.duration);
        current_notes.Remove(note);


        if (note.state == Note.note_state.active) 
        {
            SR.color = Color.red;
            note.state = Note.note_state.missed;  //timeout if missed
            PlayerInput.instance.streak = 0;
            PlayerInput.instance.multiplier = 1;
            yield return new WaitForSeconds(0.25f);
        }
        yield return null;
    }


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

        beat_interval = 60 / BPM;

        if (song.Count < 1) for (int i = 0; i < 120; i++) //filling song with default
            {
                song.Add(new Note(i));
            }
    }

    public void Start()
    {

        StartCoroutine(NoteRetrieval());
    }

}
