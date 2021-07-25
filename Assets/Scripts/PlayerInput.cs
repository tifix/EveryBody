using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    public SpriteRenderer feedback_spriteA;
    public SpriteRenderer feedback_spriteS;
    public SpriteRenderer feedback_spriteK;
    public SpriteRenderer feedback_spriteL;

    public ParticleSystem PS_a;
    public ParticleSystem PS_s;
    public ParticleSystem PS_k;
    public ParticleSystem PS_l;

    public Text score_text;

    public string cur_input="";
    public int score=0;
    public int streak=0;
    public int multiplier=1;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
       cur_input = EncodeInput();
        if (Input.anyKeyDown) CompareInputToNotes();
       ShowInputFeedback();
    }

    string EncodeInput()
    {
        string temp = "";
        
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.A)) { temp += 'a'; }
            if (Input.GetKey(KeyCode.S)) { temp += 's'; }
            if (Input.GetKey(KeyCode.K)) { temp += 'k'; }
            if (Input.GetKey(KeyCode.L)) { temp += 'l'; }
        }
        return temp;
    }
    

    //DisplayInputFeedback
    void ShowInputFeedback() 
    {
        if (Input.GetKeyDown(KeyCode.A)) { feedback_spriteA.color = Color.yellow; PS_a.Play(); }
        else if (Input.GetKeyUp(KeyCode.A)) {Color t= new Color(0.97f, 1f, 0.61f); feedback_spriteA.color = t; PS_a.Stop(); }
            if (Input.GetKeyDown(KeyCode.S)) { feedback_spriteS.color = Color.red; PS_s.Play(); }
            else if (Input.GetKeyUp(KeyCode.S)) { Color t = new Color(1, 0.72f, 0.72f); feedback_spriteS.color = t; PS_s.Stop(); }
                if (Input.GetKeyDown(KeyCode.K)) { feedback_spriteK.color = Color.blue; PS_k.Play(); }
                else if (Input.GetKeyUp(KeyCode.K)) { Color t = new Color(0.64f, 0.83f, 1f); feedback_spriteK.color = t; PS_k.Stop(); }
                    if (Input.GetKeyDown(KeyCode.L)) { feedback_spriteL.color = Color.green; PS_l.Play(); }
                    else if (Input.GetKeyUp(KeyCode.L)) { Color t = new Color(0.67f, 0.95f, 0.71f); feedback_spriteL.color = t; PS_l.Stop(); }
    }

    void CompareInputToNotes()
    {
        //break streak on keypress when there are no notes incoming
        if (SongReciever.instance.current_notes.Count < 1) 
        {
            PlayerInput.instance.streak = 0;
            PlayerInput.instance.multiplier = 1;
        }

        foreach (Note note in SongReciever.instance.current_notes)
        {
            if (ArrayUtility.Contains(cur_input.ToCharArray(), note.input))
            {
                Debug.Log("Hit!");
                note.state = Note.note_state.hit;
                note.sibling_anticipator.GetComponent<SpriteRenderer>().color = Color.green;

                //streak and multipliers

                streak++;
                if (streak > 5) multiplier = 2;
                if (streak > 10) multiplier = 3;
                if (streak > 20) multiplier = 4;
                if (streak > 50) multiplier = 5;

                score += 10*multiplier;
                
                score_text.text = score.ToString();
            }

        }
    }

    public void NoteHolding() 
    {

    }

}
