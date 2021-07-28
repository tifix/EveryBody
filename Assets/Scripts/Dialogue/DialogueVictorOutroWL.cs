using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueVictorOutroWL : DialogueWinLoss
{
    public override void Dialogue() //the dialogue itself
    {
        if (did_win) switch (i)
            {
                case 0:
                    txt.color = col_victoria;
                    font = Resources.Load<Font>("Fonts/Olondon_");
                    typingWait = base_typingWait*0.5f;
                    dialog = "...Fine.";
                    Coroutine();
                    break;
                case 1:
                    txt.color = col_player;
                    typingWait = base_typingWait * 1.1f;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    dialog = "Fine?";
                    Coroutine();
                    break;
                case 2:
                    txt.color = col_victoria;
                    font = Resources.Load<Font>("Fonts/Olondon_");
                    typingWait = base_typingWait * 0.75f;
                    dialog = "Fine. But don’t think’st this changes anything.";
                    Coroutine();
                    break;


                case 3:
                    SceneSwitcher.instance.LoadSceneDialogue("emo_intro");   //Load emo intro
                    break;
                case 4:
                    Debug.LogWarning("overextending dialogue!");
                    break;
            }
        if (!did_win) switch (i)
            {
                case 0:
                    txt.color = col_victoria;
                    font = Resources.Load<Font>("Fonts/Olondon_");
                    typingWait = base_typingWait * 1.25f;
                    dialog = "Ok, so thou basically got no soul and thou art a basic a*s b*tch and I am not joining thine stupid band.";
                    Coroutine();
                    break;
                case 1:
                    txt.color = col_player;
                    typingWait = base_typingWait * 1.1f;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    dialog = "Who taught her to swear like that?";
                    Coroutine();
                    break;
                case 2:
                    typingWait = base_typingWait * 0.8f;
                    dialog = "...Right. We’re in hell. Forgot about that.";
                    Coroutine();
                    break;


                case 3:
                    SceneSwitcher.instance.LoadSceneFancy(5);   //load fightscene agains the victorian child again, when not succesfull
                    break;
                case 4:
                    Debug.LogWarning("overextending dialogue!");
                    break;
            }
    }
}
