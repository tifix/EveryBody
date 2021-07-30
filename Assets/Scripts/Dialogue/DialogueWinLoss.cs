using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueWinLoss : DialogueTyperBase
{
    public bool did_win=false;
    public int points_to_win = 300;

    protected Sprite angry_sprite;

    public override void Awake() 
    {
        base.Awake();
        if (SceneSwitcher.score > points_to_win) did_win = true;
    }

    public override void Dialogue() //the dialogue itself
    {
        if(did_win) switch (i)
        {
            case 0:
                if (e_sprite != null)
                {
                GameObject.Find("Frame_Enemy").GetComponent<SpriteRenderer>().sprite = e_sprite;
                }
                typingWait = base_typingWait;
                dialog = "yEAAAAAA";
                Coroutine();
                break;
            case 1:
                dialog = "WOOOoooOOOOooo";
                Coroutine();
                break;
            case 2:
                dialog = "yes, I'm joining";
                Coroutine();
                break;
        }
        if (!did_win) switch (i)
            {
                case 0:
                    if (angry_sprite != null)
                    {
                        GameObject.Find("Frame_Enemy").GetComponent<SpriteRenderer>().sprite = angry_sprite;
                    }
                    typingWait = base_typingWait;
                    dialog = "Noooooo";
                    Coroutine();
                    break;
                case 1:
                    dialog = "BOOOoooOOOOooo";
                    Coroutine();
                    break;
                case 2:
                    dialog = "No, I'm not joining";
                    Coroutine();
                    break;
            }
    }
}
