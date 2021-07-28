using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueOutro : DialogueTyperBase
{
    public override void Dialogue() //the dialogue itself
    {
        switch (i)
        {
            case 0:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                typingWait = base_typingWait;
                dialog = "The veil was lifted and I got to go home and finish what I started. ";
                Coroutine();
                break;
            case 1:
                typingWait = base_typingWait;
                dialog = "The guitar is no longer with us, not in the mortal world or the immortal.";
                Coroutine();
                break;
            case 2:
                typingWait = base_typingWait*0.3f;
                dialog = "Hopefully.";
                Coroutine();
                break;
            case 3:
                typingWait = base_typingWait;
                dialog = "There was a hole in the plan, though.";
                Coroutine();
                break;
            case 4:
                typingWait = base_typingWait;
                dialog = "Because now there was a hole in hell. The word travelled fast and mostly everyone got out.";
                Coroutine();
                break;
            case 5:
                typingWait = base_typingWait;
                dialog = "I hear that Devil never left.";
                Coroutine();
                break;
            case 6:
                typingWait = base_typingWait;
                dialog = "She’s still making phone calls somewhere.";
                Coroutine();
                break;
            case 7:
                typingWait = base_typingWait;
                dialog = "Anyway, back to the state of the world.";
                Coroutine();
                break;
            case 8:
                typingWait = base_typingWait;
                dialog = "It’s sad, really.";
                Coroutine();
                break;
            case 9:
                typingWait = base_typingWait;
                dialog = "When every sinner got freed, the world was dangerously overpopulated. ";
                Coroutine();
                break;
            case 10:
                typingWait = base_typingWait;
                dialog = "The crime increased.";
                Coroutine();
                break;
            case 11:
                typingWait = base_typingWait;
                dialog = "And there are no more experiments to make.";
                Coroutine();
                break;
            case 12:
                typingWait = base_typingWait;
                dialog = "Because there’s no earth to make them on.";
                Coroutine();
                break;
            case 13:
                typingWait = base_typingWait;
                dialog = "Or there is, but it’s no fun.";
                Coroutine();
                break;
            case 14:
                typingWait = base_typingWait;
                dialog = "Maybe, and only maybe.";
                Coroutine();
                break;
            case 15:
                typingWait = base_typingWait;
                dialog = "If I form an even sicker band. And play even sicker tune.";
                Coroutine();
                break;
            case 16:
                typingWait = base_typingWait;
                dialog = "It will shut the veil again and shut everyone in again.";
                Coroutine();
                break;
            case 17:
                typingWait = base_typingWait;
                dialog = "Including me.";
                Coroutine();
                break;
            case 18:
                typingWait = base_typingWait;
                dialog = "But this is the only hope.";
                Coroutine();
                break;
            case 19:
                typingWait = base_typingWait;
                dialog = "Maybe it will work...";
                Coroutine();
                break;


            case 20:
                SceneSwitcher.instance.LoadSceneFancy(0);   //Load the menu scene
                break;
            case 21:
                //Debug.LogWarning("overextending dialogue!");
                break;
        }
    }
}
