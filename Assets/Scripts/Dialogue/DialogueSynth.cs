using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSynth : DialogueTyperBase
{
    public override void Dialogue() //the dialogue itself
    {
        switch (i)
        {
            case 0:
                typingWait = base_typingWait;
                dialog = "Not bad kid";
                Coroutine();
                break;
            case 1:
                dialog = "But you could use a note or two from me";
                Coroutine();
                break;
            case 2:
                dialog = "yes, I'm joining";
                Coroutine();
                break;
        }
    }
}
