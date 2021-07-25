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
        SpriteRenderer SR = note.sibling_anticipator.GetComponent<SpriteRenderer>();
        SR.color = Color.magenta;
        yield return new WaitForSeconds(note.duration);
        SR.color = Color.white;
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
