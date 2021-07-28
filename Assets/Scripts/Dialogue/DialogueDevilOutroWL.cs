using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDevilOutroWL : DialogueWinLoss
{
    public override void Dialogue() //the dialogue itself
    {
        if (!did_win) switch (i)
            {
                case 0:
                    txt.color = col_devil;
                    font = Resources.Load<Font>("Fonts/AngerStyles");
                    typingWait = base_typingWait;
                    dialog = "Considering this is hell, that was the most torture I’ve endured in a millenia…";
                    Coroutine();
                    break;
                case 1:
                    font = Resources.Load<Font>("Fonts/WrathStyles");
                    dialog = "GET THEM!";
                    Coroutine();
                    break;



                case 2:
                    SceneSwitcher.instance.LoadSceneFancy(7);   //load fightscene agains the Devil, the hot, overworked waifu.
                    break;
                case 3:
                    Debug.LogWarning("overextending dialogue!");
                    break;
            }
        if (did_win) switch (i)
            {
                case 0:
                    txt.color = col_devil;
                    font = Resources.Load<Font>("Fonts/AngerStyles");
                    typingWait = base_typingWait;
                    dialog = "That was fine, I guess. Along with being a complete waste of my time.";
                    Coroutine();
                    break;
                case 1:
                    dialog = "But why?";
                    Coroutine();
                    break;
                case 2:
                    txt.color = col_player;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    dialog = "I was wondering…";
                    Coroutine();
                    break;
                case 3:
                    dialog = "If I could lift the veil… if you’d be impressed enough…";
                    Coroutine();
                    break;
                case 4:
                    dialog = "(It’s only now that I realise the possible holes in my plan.)";
                    Coroutine();
                    break;
                case 5:
                    txt.color = col_devil;
                    font = Resources.Load<Font>("Fonts/AngerStyles");
                    typingWait = base_typingWait*1.2f;
                    dialog = "Unfinished business on earth, I suppose?";
                    Coroutine();
                    break;
                case 6:
                    txt.color = col_player;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    typingWait = base_typingWait*2;
                    dialog = "Yes…";
                    Coroutine();
                    break;
                case 7:
                    txt.color = col_devil;
                    font = Resources.Load<Font>("Fonts/AngerStyles");
                    typingWait = base_typingWait;
                    dialog = "HA! Get in line.";
                    Coroutine();
                    break;
                case 8:
                    dialog = "You really think I let people off if they play me a pretty song?";
                    Coroutine();
                    break;
                case 9:
                    dialog = "No way in hell! There’s no return.";
                    Coroutine();
                    break;
                case 10:
                    dialog = "And there usually are no songs either...";
                    Coroutine();
                    break;
                case 11:
                    typingWait = base_typingWait*5;
                    dialog = ". . . ";
                    Coroutine();
                    break;
                case 12:
                    typingWait = base_typingWait * 5;
                    dialog = ". . . ";
                    Coroutine();
                    break;
                case 13:
                    typingWait = base_typingWait;
                    dialog = "Hey, listen.";
                    Coroutine();
                    break;
                case 14:
                    typingWait = base_typingWait;
                    dialog = "I want to join your band.";
                    Coroutine();
                    break;
                case 15:
                    txt.color = col_player;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    typingWait = base_typingWait;
                    dialog = "Aren’t you busy?";
                    Coroutine();
                    break;
                case 16:
                    txt.color = col_devil;
                    font = Resources.Load<Font>("Fonts/WrathStyles");
                    typingWait = base_typingWait*0.5f;
                    dialog = "DON’T QUESTION ME, MORTAL.";
                    Coroutine();
                    break;
                case 17:
                    txt.color = col_player;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    typingWait = base_typingWait*1.5f;
                    dialog = "I thought I was dead…";
                    Coroutine();
                    break;
                case 18:
                    txt.color = col_victoria;
                    font = Resources.Load<Font>("Fonts/Olondon_");
                    typingWait = base_typingWait * 0.6f;
                    dialog = "Don’t question her…!";
                    Coroutine();
                    break;
                case 19:
                    txt.color = col_player;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    typingWait = base_typingWait * 1.2f;
                    dialog = "Guess the band is now together…";
                    Coroutine();
                    break;
                case 20:
                    txt.color = col_player;
                    font = Resources.Load<Font>("Fonts/Love Taking");
                    typingWait = base_typingWait * 0.8f;
                    dialog = "Come to think of it, what do you play, Devil?";
                    Coroutine();
                    break;



                case 21:
                    SceneSwitcher.instance.LoadSceneFancy(8);   //Load the final battle of the game;
                    break;
                case 22:
                    Debug.LogWarning("overextending dialogue!");
                    break;
            }
    }
}
