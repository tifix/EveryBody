using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEmoOutroWL : DialogueWinLoss
{
    public override void Dialogue() //the dialogue itself
    {
        if (did_win) switch (i)
            {
                case 0:
                    txt.color = col_emo;
                    font = Resources.Load<Font>("Fonts/old evils");
                    typingWait = base_typingWait;
                    dialog = "Can it be… could it be…?";
                    Coroutine();
                    break;
                case 1:
                    dialog = "Finally… someone understands my sorrow… through music....";
                    Coroutine();
                    break;
                case 2:
                    dialog = "I am not alone…";
                    Coroutine();
                    break;
                case 3:
                    dialog = "Or, you know. Whatever.";
                    Coroutine();
                    break;


                case 4:
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    SceneSwitcher.instance.LoadSceneDialogue(2, "devil_intro");   //Load devil intro
                    break;
                case 5:
                    Debug.LogWarning("overextending dialogue!");
                    break;
            }
        if (!did_win) switch (i)
            {
                case 0:
                    txt.color = col_emo;
                    font = Resources.Load<Font>("Fonts/old evils");
                    typingWait = base_typingWait;
                    dialog = "No… this is not it… The technique is there but I cannot feel it…";
                    Coroutine();
                    break;
                case 1:
                    dialog = "I must be left on my own devices… alone again…";
                    Coroutine();
                    break;


                case 2:
                    SceneSwitcher.instance.LoadSceneFancy(6);   //load fightscene agains the emo, from the beggining.
                    break;
                case 3:
                    Debug.LogWarning("overextending dialogue!");
                    break;
            }
    }
}
