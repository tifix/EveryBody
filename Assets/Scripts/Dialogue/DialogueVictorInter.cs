using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueVictorInter : DialogueTyperBase
{
    public override void Dialogue() //the dialogue itself
    {
        switch (i)
        {
            case 0:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                typingWait = base_typingWait * 2f;
                dialog = "Hi..?";
                Coroutine();
                break;
            case 1:
                typingWait = base_typingWait * 0.8f;
                dialog = "Hey, something brought you up here. Tell me what it was. ";
                Coroutine();
                break;
            case 2:
                typingWait = base_typingWait;
                dialog = "It’s not like I’m going to kill you.";
                Coroutine();
                break;
            case 3:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "I heard thee play.";
                Coroutine();
                break;
            case 4:
                txt.color = col_player;
                typingWait = base_typingWait * 0.8f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "Yeah?";
                Coroutine();
                break;
            case 5:
                txt.color = col_victoria;
                typingWait = base_typingWait;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "No soul in hell ever plays.";
                Coroutine();
                break;
            case 6:
                txt.color = col_player;
                typingWait = base_typingWait * 0.65f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "Instruments or like-";
                Coroutine();
                break;
            case 7:
                txt.color = col_victoria;
                typingWait = base_typingWait;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "No wonder’st no one plays. Thou suck.";
                Coroutine();
                break;
            case 8:
                txt.color = col_player;
                typingWait = base_typingWait*0.5f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "What?";
                Coroutine();
                break;
            case 9:
                typingWait = base_typingWait * 0.9f;
                dialog = "(Is that even the shakespearean way or is she just humoring me…?)";
                Coroutine();
                break;
            case 10:
                txt.color = col_victoria;
                typingWait = base_typingWait * 1f;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "Thou suck. Have thou even practiced that guitar?";
                Coroutine();
                break;
            case 11:
                dialog = "Instrument is supposed to be practiced 10 hours a day. ";
                Coroutine();
                break;
            case 12:
                typingWait = base_typingWait * 0.9f;
                dialog = "Thou sound like thou occasionally play at bonfires.";
                Coroutine();
                break;
            case 13:
                typingWait = base_typingWait * 1f;
                dialog = "Why did you even learn to play? Was it to IMPRESS PEOPLE?";
                Coroutine();
                break;
            case 14:
                dialog = "I BET it wasn’t for the love of music!";
                Coroutine();
                break;
            case 15:
                dialog = "Only soulless guitar rattling.";
                Coroutine();
                break;
            case 16:
                dialog = "Because I can’t hear the love!";
                Coroutine();
                break;
            case 17:
                txt.color = col_player;
                typingWait = base_typingWait * 1.2f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "I think everything is soulless here…";
                Coroutine();
                break;
            case 18:
                txt.color = col_victoria;
                typingWait = base_typingWait * 1f;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "Thou art caught up in useless details. Actually shut up. ";
                Coroutine();
                break;
            case 19:
                txt.color = col_player;
                typingWait = base_typingWait * 1.1f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "Do you play?";
                Coroutine();
                break;
            case 20:
                txt.color = col_victoria;
                typingWait = base_typingWait * 1f;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "Puh-please. ";
                Coroutine();
                break;
            case 21:
                dialog = "Why do thou care?";
                Coroutine();
                break;
            case 22:
                txt.color = col_player;
                typingWait = base_typingWait * 0.8f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "I want to make a huge band to play a tune sick enough to make an impression on the devil. I might need your help.";
                Coroutine();
                break;
            case 23:
                txt.color = col_victoria;
                typingWait = base_typingWait * 1.1f;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "YEAH thou do.";
                Coroutine();
                break;
            case 24:
                typingWait = base_typingWait;
                dialog = "But I don’t need thee.";
                Coroutine();
                break;
            case 25:
                txt.color = col_player;
                typingWait = base_typingWait;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "Do you want to join anyway?";
                Coroutine();
                break;
            case 26:
                txt.color = col_victoria;
                typingWait = base_typingWait * 1.1f;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "Play. This time with soul. From the heart. THEN I might consider.";
                Coroutine();
                break;




            case 27:
                SceneSwitcher.instance.LoadSceneFancy(5);   //load battle against victor2
                break;
            case 28:
                Debug.LogWarning("overextending dialogue!");
                break;
        }
    }
    public override void Initialise()
    {
        base.Initialise();

        SwapInSmallEnemyGraphic("_oikea_victorian flut_happy",Resources.Load<AudioClip>("victoriantheme")as AudioClip);
    }

}
