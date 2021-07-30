using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueIntro : DialogueTyperBase
{
    public Animator sign_neoning;
    public Animator background;

    public override void Dialogue() //the dialogue itself
    {
        switch (i)
        {
            case 0:
                typingWait = base_typingWait * 1.5f;
                dialog = "*It’s dark.*";
                Coroutine();
                break;
            case 1:
                typingWait = base_typingWait * 1.2f;
                dialog = "Where am I?";
                Coroutine();
                break;
            case 2:
                sign_neoning.SetTrigger("ShowSign");
                typingWait = base_typingWait*1.5f;
                dialog = "            \n           \nWell that would make sense.";

              
                
                Coroutine();
                break;
            case 3:
                background.SetTrigger("FadeInBackground");
                dialog = "The latest experiment must have backfired…";
                Coroutine();
                break;
            case 4:
                typingWait = base_typingWait*15f;
                dialog = ". . .";
                Coroutine();
                break;
            case 5:
                typingWait = base_typingWait*0.85f;
                dialog = "No way! I’m not ready to be dead. There must be a way to lift the veil.";
                Coroutine();
                break;
            case 6:
                typingWait = base_typingWait * 10f;
                dialog = ". . .";
                Coroutine();
                break;
            case 7:
                typingWait = base_typingWait * 0.3f;
                dialog = "I KNOW!";
                Coroutine();
                break;
            case 8:
                typingWait = base_typingWait * 0.85f;
                dialog = "I will only need to make a good impression on the Devil. ";
                Coroutine();
                break;
            case 9:
                typingWait = base_typingWait * 0.85f;
                dialog = "I’ll make the SICKEST BAND in the whole underworld and play the SICKEST TUNE for the devil.";
                Coroutine();
                break;
            case 10:
                typingWait = base_typingWait * 1.25f;
                dialog = "It will be TO DIE FOR.\n               (heh)";
                Coroutine();
                break;
            case 11:
                typingWait = base_typingWait;
                dialog = "The Devil will for sure be impressed.";
                Coroutine();
                break;
            case 12:
                typingWait = base_typingWait * 1.2f;
                dialog = "Only, I need to recruit people for my band by proving I can play.";
                Coroutine();
                break;
            case 13:
                typingWait = base_typingWait * 1.2f;
                dialog = "It’s convenient that my guitar died with me and is now here.";
                Coroutine();
                break;
            case 14:
                typingWait = base_typingWait;
                dialog = "(It was quite the experiment…)";
                Coroutine();
                break;
            case 15:
                dialog = "Time to see what this old guitar’s got…";
                Coroutine();
                break;


            case 16:
                SceneSwitcher.instance.LoadSceneFancy(4);   //Load victor1 battlescene
                break;
            case 17:
                Debug.LogWarning("overextending dialogue!");
                break;
        }
    }
}
