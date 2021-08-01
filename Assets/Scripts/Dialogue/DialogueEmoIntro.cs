using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueEmoIntro : DialogueTyperBase
{
    public override void Dialogue() //the dialogue itself
    {
        switch (i)
        {
            case 0:
                SwapInSmallEnemyGraphic("victorian flut_happy");
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "What do we do now?";
                Coroutine();
                break;
            case 1:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "I was, uh, thinking, uh, that we’d play and see if anyone else is attracted.";
                Coroutine();
                break;
            case 2:
                SwapInSmallEnemyGraphic("victorian flut_angry");
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "What an awful strategy.";
                Coroutine();
                break;
            case 3:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "I haven’t had time to think about it. I JUST died. How long have you been here for?";
                Coroutine();
                break;
            case 4:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "HEY! Thou just do not ask.";
                Coroutine();
                break;
            case 5:
                SwapInEmpty();
                txt.color = col_emo;
                font = Resources.Load<Font>("Fonts/old evils");
                dialog = "I remember when I came here…";
                Coroutine();
                break;
            case 6:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "What is that?";
                Coroutine();
                break;
            case 7:
                SwapInSmallEnemyGraphic("victorian flut_angry");
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "It’s the emo. We shall not pay him any mind.";
                Coroutine();
                break;
            case 8:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "But he could join our band!";
                Coroutine();
                break;
            case 9:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "Yeah, and then it would be an EMO band.";
                Coroutine();
                break;
            case 10:
                typingWait = base_typingWait;
                dialog = "Come on. We’re close to the devil. With my flute we’ll win the devil over no problem.";
                Coroutine();
                break;
            case 11:
                SwapInEmpty();
                txt.color = col_emo;
                font = Resources.Load<Font>("Fonts/old evils");
                dialog = "The Devil… is not easily won over.";
                Coroutine();
                break;
            case 12:
                dialog = "Many times I have tried but no mind is payed to me.";
                Coroutine();
                break;
            case 13:
                dialog = "I must suffer. Eternally.";
                Coroutine();
                break;
            case 14:
                SwapInSmallEnemyGraphic("victorian flut_angry");
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "Jeez, now we’ve woken him up.";
                Coroutine();
                break;
            case 15:
                SwapInSmallEnemyAudio(Resources.Load<AudioClip>("emotheme") as AudioClip);
                SwapInEmpty();
                txt.color = col_emo;
                font = Resources.Load<Font>("Fonts/old evils");
                typingWait = base_typingWait;
                dialog = "Too many days I’ve suffered here in the gates of Hell…";
                Coroutine();
                break;
            case 16:
                typingWait = base_typingWait;
                dialog = "Why must I still suffer? For aren’t I supposed to rest in peace?";
                Coroutine();
                break;
            case 17:
                typingWait = base_typingWait;
                dialog = "But alas, no rest is given to me… My only solace in my synth…";
                Coroutine();
                break;
            case 18:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                typingWait = base_typingWait;
                dialog = "You got a synth?";
                Coroutine();
                break;
            case 19:
                SwapInSmallEnemyGraphic("victorian flut_angry");
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "NO! Whatever thou art thinking, stop thinking it.";
                Coroutine();
                break;
            case 20:
                SwapInSmallEnemyGraphic("SynthGuy_Angry");
                txt.color = col_emo;
                font = Resources.Load<Font>("Fonts/old evils");
                typingWait = base_typingWait;
                dialog = "Yes… I have my synth and it is the only friend i can count on in this rotten world… I mean underworld…";
                Coroutine();
                break;
            case 21:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                typingWait = base_typingWait;
                dialog = "Would you like to join our band to make an impression on the devil to let me go?";
                Coroutine();
                break;
            case 22:
                txt.color = col_emo;
                font = Resources.Load<Font>("Fonts/old evils");
                typingWait = base_typingWait * 0.5f; 
                dialog = "Impression on the devil?";
                Coroutine();
                break;
            case 23:
                typingWait = base_typingWait * 0.5f;
                dialog = "...that’s what I want to do, too.";
                Coroutine();
                break;
            case 24:
                typingWait = base_typingWait ;
                dialog = "But I don’t think I can trust you.";
                Coroutine();
                break;
            case 25:
                typingWait = base_typingWait * 0.8f; 
                dialog = "I can’t trust you to be good enough at this.";
                Coroutine();
                break;
            case 26:
                typingWait = base_typingWait * 0.8f;
                dialog = "I can’t even trust you to be mediocre.";
                Coroutine();
                break;
            case 27:
                typingWait = base_typingWait*0.7f;
                dialog = "For so long it has been just me and my synth, I wonder…";
                Coroutine();
                break;
            case 28:
                SwapInSmallEnemyGraphic("victorian flut_angry");
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait;
                dialog = "Jeez, if you really want to do this, let’s just start playing, before he goes on any more. ";
                Coroutine();
                break;






            case 29:
                SceneSwitcher.instance.LoadSceneFancy(6);   //load fightscene agains emo
                break;
            case 30:
                Debug.LogWarning("overextending dialogue!");
                break;
        }
    }
    public override void Initialise()
    {
        base.Initialise();
        e_sprite = Resources.Load<Sprite>("victorian flut_happy") as Sprite;

        if (GameObject.Find("Frame_Enemy").TryGetComponent<Image>(out Image SR))
        {
            SR.sprite = e_sprite;
        }
    }
}
