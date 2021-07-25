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

    public string cur_input="";

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
        if (Input.GetKeyDown(KeyCode.A)) { feedback_spriteA.color = Color.yellow; }
        else if (Input.GetKeyUp(KeyCode.A)) {Color t= new Color(0.97f, 1f, 0.61f); feedback_spriteA.color = t;  }
            if (Input.GetKey(KeyCode.S)) { feedback_spriteS.color = Color.red; }
            else if (Input.GetKeyUp(KeyCode.S)) { Color t = new Color(1, 0.72f, 0.72f); feedback_spriteS.color = t; }
                if (Input.GetKey(KeyCode.K)) { feedback_spriteK.color = Color.blue; }
                else if (Input.GetKeyUp(KeyCode.K)) { Color t = new Color(0.64f, 0.83f, 1f); feedback_spriteK.color = t; }
                    if (Input.GetKey(KeyCode.L)) { feedback_spriteL.color = Color.green; }
                    else if (Input.GetKeyUp(KeyCode.L)) { Color t = new Color(0.67f, 0.95f, 0.71f); feedback_spriteL.color = t; }
    }

    void CompareInputToNotes()
    {
        foreach (Note note in SongReciever.instance.current_notes)
        {
            if (ArrayUtility.Contains(cur_input.ToCharArray(), note.input))
            {
                Debug.Log("Hit!");
                note.state = Note.note_state.hit;
                note.sibling_anticipator.GetComponent<SpriteRenderer>().color = Color.green;
            }

        }
    }

}
