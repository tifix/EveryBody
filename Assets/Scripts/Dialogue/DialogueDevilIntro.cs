using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDevilIntro : DialogueTyperBase
{
    public override void Dialogue() //the dialogue itself
    {
        switch (i)
        {
            case 0:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait * 1.3f;
                dialog = "Have you ever heard of “the leap of faith?”";
                Coroutine();
                break;
            case 1:
                txt.color = col_player;
                typingWait = base_typingWait * 0.8f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "Yes, I know the concept.";
                Coroutine();
                break;
            case 2:
                txt.color = col_emo;
                typingWait = base_typingWait * 1.3f;
                font = Resources.Load<Font>("Fonts/old evils");
                dialog = "I once…";
                Coroutine();
                break;
            case 3:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait * 0.75f;
                dialog = "I think this is the time for it. ";
                Coroutine();
                break;
            case 4:
                txt.color = col_player;
                typingWait = base_typingWait * 1.2f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "Leap of faith?";
                Coroutine();
                break;
            case 5:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait * 2f;
                dialog = "YES.";
                Coroutine();
                break;
            case 6:
                txt.color = col_player;
                typingWait = base_typingWait * 1f;
                font = Resources.Load<Font>("Fonts/Love Taking");
                dialog = "Have either of you ever seen the devil?";
                Coroutine();
                break;
            case 7:
                txt.color = col_emo;
                typingWait = base_typingWait * 1.3f;
                font = Resources.Load<Font>("Fonts/old evils");
                dialog = "From the sidelines… ";
                Coroutine();
                break;
            case 8:
                txt.color = col_emo;
                typingWait = base_typingWait * 1.5f;
                font = Resources.Load<Font>("Fonts/old evils");
                dialog = "More lovely and more temperate than the summer’s day…";
                Coroutine();
                break;
            case 9:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait * 1f;
                dialog = "On my first week in hell. Haven’t been let in her chambers since.";
                Coroutine();
                break;
            case 10:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                typingWait = base_typingWait;
                dialog = "What did you do in your first week in hell?";
                Coroutine();
                break;
            case 11:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait * 0.5f;
                dialog = "...We should go over our setlist.";
                Coroutine();
                break;
            case 12:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                typingWait = base_typingWait;
                dialog = "We have no setlist.";
                Coroutine();
                break;
            case 13:
                txt.color = col_devil;
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait*1.7f;
                dialog = "Go over what?";
                Coroutine();
                break;
            case 14:
                txt.color = col_emo;
                typingWait = base_typingWait * 3f;
                font = Resources.Load<Font>("Fonts/old evils");
                dialog = "Your…";
                Coroutine();
                break;
            case 15:
                txt.color = col_victoria;
                typingWait = base_typingWait * 2.5f;
                font = Resources.Load<Font>("Fonts/Olondon_");
                dialog = "Thy majesty… I am sorry…";
                Coroutine();
                break;
            case 16:
                txt.color = col_emo;
                typingWait = base_typingWait * 1f;
                font = Resources.Load<Font>("Fonts/old evils");
                dialog = "I have written you a poem… ";
                Coroutine();
                break;
            case 17:
                typingWait = base_typingWait * 0.8f;
                dialog = "or maybe it is more about you than to you…";
                Coroutine();
                break;
            case 18:
                typingWait = base_typingWait * 0.6f;
                dialog = "I have 10 000 of them in fact...";
                Coroutine();
                break;
            case 19:
                txt.color = col_devil;
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait;
                dialog = "What do we have going on here?";
                Coroutine();
                break;
            case 20:
                /*
                 * 
                 * 
                 * phone ringing
                 * 
                 * 
                 * 
                 */
                typingWait = base_typingWait;
                dialog = "Sorry, I gotta take this.";
                Coroutine();
                break;
            case 21:
                font = Resources.Load<Font>("Fonts/WrathStyles");
                typingWait = base_typingWait*0.8f;
                dialog = "DON’T GO ANYWHERE.";
                Coroutine();
                break;
            case 22:
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait;
                dialog = "I want to know why you are making such a fuss in my backyard.";
                Coroutine();
                break;
            case 23:
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait * 1.2f;
                dialog = "Yes, I know…";
                Coroutine();
                break;
            case 24:
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait * 1.1f;
                dialog = "Hell has been overcrowded for centuries now but we’ve made it work…";
                Coroutine();
                break;
            case 25:
                font = Resources.Load<Font>("Fonts/WrathStyles");
                typingWait = base_typingWait * 0.84f;
                dialog = "NO I do NOT want to ask for help from “upstairs”! It’s bad enough that they keep sending a card every Christmas, so humiliating…";
                Coroutine();
                break;
            case 26:
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait * 0.75f;
                dialog = "Some baboons have found their way to my yard, anyway, so maybe we’ll cut a bit of my yard… Seems to be space, I didn’t remember..";
                Coroutine();
                break;
            case 27:
                font = Resources.Load<Font>("Fonts/WrathStyles");
                typingWait = base_typingWait * 0.9f;
                dialog = "Or go underground? Check if we can go lower.";
                Coroutine();
                break;
            case 28:
                font = Resources.Load<Font>("Fonts/WrathStyles");
                typingWait = base_typingWait * 1f;
                dialog = "Okay, okay, do that. Call me if anything new pops up.";
                Coroutine();
                break;
            /*
             * 
             * 
             * phonecall ended
             * 
             * 
             * 
             */
            case 29:
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait * 1.2f;
                dialog = "Something new always pops up…";
                Coroutine();
                break;
            case 30:
                font = Resources.Load<Font>("Fonts/WrathStyles");
                typingWait = base_typingWait;
                dialog = "So, punks. What are you doing here? Be quick. Time is sins and misery.";
                Coroutine();
                break;
            case 31:
                txt.color = col_player;
                font = Resources.Load<Font>("Fonts/Love Taking");
                typingWait = base_typingWait * 1.7f;
                dialog = "I woke up here after… well… death… and--";
                Coroutine();
                break;
            case 32:
                txt.color = col_victoria;
                font = Resources.Load<Font>("Fonts/Olondon_");
                typingWait = base_typingWait * 0.92f;
                dialog = "We want to sing thee a song!";
                Coroutine();
                break;
            case 33:
                txt.color = col_emo;
                font = Resources.Load<Font>("Fonts/old evils");
                typingWait = base_typingWait * 0.92f;
                dialog = "...or a hundred songs.";
                Coroutine();
                break;
            case 34:
                txt.color = col_devil;
                font = Resources.Load<Font>("Fonts/AngerStyles");
                typingWait = base_typingWait * 1.1f;
                dialog = "No one ever plays in hell.";
                Coroutine();
                break;
            case 35:
                dialog = "Let’s hear it.";
                Coroutine();
                break;


            case 36:
                SceneSwitcher.instance.LoadSceneFancy(7);   //load fightscene agains the Devil, the hot, overworked waifu.
                break;
            case 37:
                Debug.LogWarning("overextending dialogue!");
                break;
        }
    }
}
