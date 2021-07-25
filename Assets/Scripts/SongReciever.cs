using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongReciever : MonoBehaviour
{
    public static SongReciever instance;
    public SpriteRenderer rhythm_sprite;

    //public List<Note> song = new List<Note>();
    [Tooltip("Track is made up of beats (4 by default)")]
    public List<Beat> track = new List<Beat>();
    public float BPM = 140;
    public float beat_interval;

    [HideInInspector] public List<Note> current_notes = new List<Note>();
    [Header("Track progression")]
    public float song_start_time;
    private float beat_start_time;
    private int cur_note = 0;
    public int cur_beat = 0;
   

    public IEnumerator NoteRetrieval()
    {
        beat_start_time = song_start_time;

        //iterate over beats
        while (cur_beat < track.Count)  //if cur beat is less than the last beat of the track, play it
        {

            //iterate over notes
            while (cur_note < track[cur_beat].notes.Count) 
            {
                float cur_note_init = track[cur_beat].notes[cur_note].start_time;
                yield return new WaitForFixedUpdate();

                if(Time.time-beat_start_time > cur_note_init * beat_interval)
                {
                    track[cur_beat].notes[cur_note].play();
                    Debug.Log(" b:" + cur_beat + " n:" + cur_note);
                    cur_note++;

                }
            }
            while (Time.time - song_start_time < (cur_beat+1)*beat_interval) 
                yield return new WaitForFixedUpdate();
            
            cur_beat++;
            cur_note = 0;
            beat_start_time = Time.time;


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
        

        yield return new WaitForSeconds(note.duration*beat_interval);
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

        beat_interval = 240 / BPM;
    }

    public void Start()
    {

        StartCoroutine(NoteRetrieval());
    }

}
