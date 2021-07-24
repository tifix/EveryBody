using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;
    public SpriteRenderer feedback_sprite;
    public SpriteRenderer rhythm_sprite;
    public List<Note> song=new List<Note>();
    public float BPM = 140;
    public float beat_interval;
    public int cur_note=0;
    public float song_start_time;

    public IEnumerator NoteRetrieval() 
    {
        while (cur_note<song.Count) 
        {
            if(Time.time>song[cur_note].start_time)   //if the time elapsed from the start of the song is longer than the song start point
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
        rhythm_sprite.color = Color.red;
        yield return new WaitForSeconds(note.duration);
        rhythm_sprite.color = Color.white;
        yield return null;
    }


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);

         beat_interval = 60 / BPM;

        if (song.Count<1) for (int i = 0; i < 120; i++) //filling song with default
            {
                song.Add(new Note(i));
            }
    }

    public void Start()
    {

        StartCoroutine(NoteRetrieval());
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    char ReadInput()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.A)) { feedback_sprite.color = Color.yellow; return 'a'; }
            if (Input.GetKey(KeyCode.S)) { feedback_sprite.color = Color.red; return 's'; }
            if (Input.GetKey(KeyCode.K)) { feedback_sprite.color = Color.blue; return 'k'; }
            if (Input.GetKey(KeyCode.L)) { feedback_sprite.color = Color.green; return 'l'; }
        }        //Input.GetKeyDown("space")) {; }
        else feedback_sprite.color = Color.white;
        return ' ';

    }
}
