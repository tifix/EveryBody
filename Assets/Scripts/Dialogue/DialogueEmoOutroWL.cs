using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                    SwapInSmallEnemyGraphic("SynthGuy_Angry");
                    dialog = "Or, you know. Whatever.";
                    Coroutine();
                    break;


                case 4:
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    SceneSwitcher.instance.LoadSceneDialogue("devil_intro");   //Load devil intro
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
    public override void Initialise() 
    {
        base.Initialise();
        points_to_win = 1200;

        e_sprite = Resources.Load<Sprite>("SynthGuy_Happy") as Sprite;
        angry_sprite = Resources.Load<Sprite>("SynthGuy_Angry") as Sprite;

        if (GameObject.Find("Frame_Enemy").TryGetComponent<Image>(out Image SR))
        {
            if(did_win) SR.sprite = e_sprite;
            else SR.sprite = angry_sprite;


        }
    }
}
