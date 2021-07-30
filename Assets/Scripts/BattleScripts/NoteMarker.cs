using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(SpriteRenderer))]
public class NoteMarker : MoveAndDie
{
    public Note sibling_note;
    public ParticleSystem ps_miss;
    public ParticleSystem ps_hit;
    public bool is_vanished = false;

    public override void Start()
    {
        Invoke("Vanish", lifespan);
        StartCoroutine(NoteBeingHit());
        ParticleSystem.ShapeModule shape = ps_hit.shape;
        shape.radius = sibling_note.duration*50;
    }

    public void note_missed()
    {
        StartCoroutine(Vanish());
        ps_miss.Play();
    }

    public IEnumerator Vanish() 
    {
        yield return new WaitForSeconds(0.15f);
        is_vanished = true;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public override void FixedUpdate()
    {

        if (!is_vanished) 
        {
            if (sibling_note.state == Note.note_state.missed) { Debug.Log(sibling_note.state); note_missed(); }
        }
        
        base.FixedUpdate();

    }

    public IEnumerator NoteBeingHit() 
    {
        yield return new WaitForSeconds(1);
        while (true) 
        {
            if(ArrayUtility.Contains(PlayerInput.instance.cur_input.ToCharArray(), sibling_note.input) && sibling_note.state==Note.note_state.hit) //if pressing the right note
            {
                if (!ps_hit.isEmitting) ps_hit.Play();
            } else ps_hit.Stop();

            if (!SongReciever.instance.current_notes.Contains(sibling_note)) break;
            yield return null;
        }
        if(sibling_note.state == Note.note_state.hit) Destroy(gameObject);

    }


}
