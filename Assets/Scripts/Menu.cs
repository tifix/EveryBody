using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu instance;

    public GameObject cretits_panel;
    public GameObject levelselect_panel;
    public GameObject hs_panel;
    [Space]
    public Button victoria_button;
    public Button emo_button;
    public Button devil_button;
    public Button final_button;
    [Space]
    public Text vic_score_disp;
    public Text emo_score_disp;
    public Text dev_score_disp;
    public Text fin_score_disp;
    [Space]
    public Text board_vic;
    public Text board_emo;
    public Text board_dev;
    public Text board_fin;
    [Space]
    public InputField nickname_reciever;
    public AudioClip button_press_sfx;
    public AudioClip ambience_music;
    
    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void ToggleCredits() 
    {
        AudioHandler.PlaySFX(button_press_sfx);
        cretits_panel.SetActive(!cretits_panel.activeInHierarchy);
        if (levelselect_panel.activeInHierarchy) levelselect_panel.SetActive(false);
        if (hs_panel.activeInHierarchy) hs_panel.SetActive(false);
    }
    public void ToggleLevelSelect()
    {
        AudioHandler.PlaySFX(button_press_sfx);
        levelselect_panel.SetActive(!levelselect_panel.activeInHierarchy);
        if (cretits_panel.activeInHierarchy) cretits_panel.SetActive(false);
        if (hs_panel.activeInHierarchy) hs_panel.SetActive(false);
    }
    public void ToggleHighScores()
    {
        AudioHandler.PlaySFX(button_press_sfx);
        if (!hs_panel.activeInHierarchy) SceneSwitcher.instance.gameObject.GetComponent<HighScores>().UpdateHSDisplay(); 

        hs_panel.SetActive(!hs_panel.activeInHierarchy);
        if (levelselect_panel.activeInHierarchy) levelselect_panel.SetActive(false);
        if (cretits_panel.activeInHierarchy) cretits_panel.SetActive(false);
    }

    public void StartTheGame()
    {
        AudioHandler.PlaySFX(button_press_sfx);
        SceneSwitcher.instance.LoadSceneFancy(1);
    }

    public void SelectVictorian()
    {
        SceneSwitcher.score = 0;
        AudioHandler.PlaySFX(button_press_sfx);
        SceneSwitcher.instance.LoadSceneFancy(5);
    }
    public void SelectEmo()
    {
        SceneSwitcher.score = 0;
        AudioHandler.PlaySFX(button_press_sfx);
        SceneSwitcher.instance.LoadSceneFancy(6);
    }
    public void SelectDevil()
    {
        SceneSwitcher.score = 0;
        AudioHandler.PlaySFX(button_press_sfx);
        SceneSwitcher.instance.LoadSceneFancy(7);
    }
    public void SelectFinale()
    {
        SceneSwitcher.score = 0;
        AudioHandler.PlaySFX(button_press_sfx);
        SceneSwitcher.instance.LoadSceneFancy(8);
    }

    public void Start()
    {
        //Disable level selects if the player hasn't beaten that character yet.
        if (!SceneSwitcher.instance.is_debugging) 
        {
            if (SceneSwitcher.instance.highscore_victoria < 1) { victoria_button.interactable = false; vic_score_disp.text = "Undefeated"; }
            else { victoria_button.interactable = true; vic_score_disp.text = "HS: " + SceneSwitcher.instance.highscore_victoria; }

            if (SceneSwitcher.instance.highscore_emo < 1) { emo_button.interactable = false; emo_score_disp.text = "Undefeated"; }
            else {emo_button.interactable = true; emo_score_disp.text = "HS: " + SceneSwitcher.instance.highscore_emo;}

            if (SceneSwitcher.instance.highscore_devil < 1) { devil_button.interactable = false; dev_score_disp.text = "Undefeated"; }
            else { devil_button.interactable = true; dev_score_disp.text = "HS: " + SceneSwitcher.instance.highscore_devil;}

            if (SceneSwitcher.instance.highscore_final < 1) { final_button.interactable = false; fin_score_disp.text = "Undefeated"; }
            else { final_button.interactable = true; fin_score_disp.text = "HS: " + SceneSwitcher.instance.highscore_final; }
        }

        AudioHandler.PlayMusic(ambience_music, true);
    }



    public void PointlessButton()
    {
        AudioHandler.PlaySFX(button_press_sfx);
        SceneSwitcher.instance.gameObject.GetComponent<HighScores>().PointlessButton();
    }

    public void RecieveLeaderboardSubmission()
    {
        string nickname = nickname_reciever.textComponent.text;
        Debug.Log(nickname);
        SceneSwitcher.instance.gameObject.GetComponent<HighScores>().SendPlayerDataToServer(nickname);
    }
}
