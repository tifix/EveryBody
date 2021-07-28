using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject cretits_panel;
    public GameObject levelselect_panel;
    public Button victoria_button;
    public Button emo_button;
    public Button devil_button;
    public Button final_button;

    public Text vic_score_disp;
    public Text emo_score_disp;
    public Text dev_score_disp;
    public Text fin_score_disp;

    public void ToggleCredits() 
    {
        cretits_panel.SetActive(!cretits_panel.activeInHierarchy);
    }
    public void ToggleLevelSelect()
    {
        levelselect_panel.SetActive(!levelselect_panel.activeInHierarchy);
    }

    public void StartTheGame() 
    {
        SceneSwitcher.instance.LoadSceneFancy(1);
    }

    public void SelectVictorian() 
    {
        SceneSwitcher.instance.LoadSceneFancy(5);
    }
    public void SelectEmo()
    {
        SceneSwitcher.instance.LoadSceneFancy(6);
    }
    public void SelectDevil()
    {
        SceneSwitcher.instance.LoadSceneFancy(7);
    }
    public void SelectFinale()
    {
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

    }

}
