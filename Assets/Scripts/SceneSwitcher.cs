using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher instance;

    [Header("game parameters")]
    public bool is_debugging = false;
    public bool hardmode = false;
    [Space]
    public Animator anim;
    [HideInInspector] public bool scene_transitioning = false;
    public static float score = 0;
    [HideInInspector] public DialogueTyperBase cur_dialogue;
    [HideInInspector] public Text DialogueDisplayer;

    [Header("scores")]
    public int highscore_victoria = 0;
    public int highscore_emo = 0;
    public int highscore_devil = 0;
    public int highscore_final = 0;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(this); }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //utilities
        // if (is_debugging && Input.GetKeyDown(KeyCode.Space)) new Note().play(); //SpawnAnticipationNote(anticip_note, new Transform[] { A_pos, S_pos, K_pos, L_pos }[Random.Range(0, 4)],new Note(4));
        if (is_debugging && Input.GetKeyDown(KeyCode.LeftShift)) Time.timeScale = 0.25f;
        if (is_debugging && Input.GetKeyUp(KeyCode.LeftShift)) Time.timeScale = 1;
        if (is_debugging && Input.GetKeyDown(KeyCode.LeftAlt)) anim.SetTrigger("TriggerCrossfade");
    }


    public IEnumerator ScneFancyLoadeorum(int scene_number)
    {
        if (!scene_transitioning)
        {
            scene_transitioning = true;

            switch (scene_number)
            {
                case (4):
                    {
                        instance.anim.SetTrigger("TriggerCircle");
                        break;
                    }
                case (5):
                    {
                        instance.anim.SetTrigger("TriggerVictoria");
                        break;
                    }
                case (6):
                    {
                        instance.anim.SetTrigger("TriggerEmo");
                        break;
                    }
                case (7):
                    {
                        instance.anim.SetTrigger("TriggerDevil");
                        break;
                    }
                default:
                    {
                        instance.anim.SetTrigger("TriggerCrossfade");
                        break;
                    }
            }
            
            yield return new WaitForSeconds(0.95f);
            instance.anim.speed = 0.1f;
            AsyncOperation async = SceneManager.LoadSceneAsync(scene_number, LoadSceneMode.Single);
            while (!async.isDone) yield return null;
            instance.anim.speed = 1f;
            instance.anim.SetTrigger("SceneReady");
            yield return new WaitForSeconds(0.95f);
            scene_transitioning = false;
        }
    }

    public IEnumerator DialoguePreperer(string dialogue)
    {
        if (!scene_transitioning)
        {
            scene_transitioning = true;

            int scene_number = 2;
            if (dialogue == "outro") { scene_number = 3; instance.anim.SetTrigger("TriggerFlash");AudioHandler.PlaySFX(Resources.Load<AudioClip>("Explosion") as AudioClip); }
            else { instance.anim.SetTrigger("TriggerCrossfade"); }

            
            yield return new WaitForSeconds(0.95f);
            instance.anim.speed = 0.1f;
            AsyncOperation async = SceneManager.LoadSceneAsync(scene_number, LoadSceneMode.Single);
            while (!async.isDone) yield return null;
            instance.anim.speed = 1f;

            BakeDialogue(dialogue);

            instance.anim.SetTrigger("SceneReady");
            yield return new WaitForSeconds(0.95f);
            scene_transitioning = false;
        }
    }


    public static void LoadScene(int scene_number)
    {
        SceneManager.LoadScene(scene_number);
    }
    public void LoadSceneFancy(int scene_number)
    {
        StartCoroutine(ScneFancyLoadeorum(scene_number));
    }

    public void LoadSceneDialogue(string dialogue)
    {
        StartCoroutine(DialoguePreperer(dialogue));
    }

    private void BakeDialogue(string dialogue)
    {
        DialogueDisplayer = GameObject.Find("TextMain").GetComponent<Text>();    //Highly unstable, ensure the text displayer has the proper name
        switch (dialogue)
        {
            case "victorian_inter":
                cur_dialogue = DialogueDisplayer.gameObject.AddComponent(typeof(DialogueVictorInter)) as DialogueVictorInter;      //typeof(DialogueVictorInter)) as DialogueTyperBase;
                cur_dialogue.Awake();
                cur_dialogue.Initialise();
                score = 0;
                break;
            case "victorian_outro":
                if (score > highscore_victoria) highscore_victoria = Mathf.FloorToInt(score);
                cur_dialogue = DialogueDisplayer.gameObject.AddComponent(typeof(DialogueVictorOutroWL)) as DialogueVictorOutroWL;      //typeof(DialogueVictorInter)) as DialogueTyperBase;
                cur_dialogue.Awake();
                cur_dialogue.Initialise();
                break;
            case "emo_intro":
                cur_dialogue = DialogueDisplayer.gameObject.AddComponent(typeof(DialogueEmoIntro)) as DialogueEmoIntro;      //typeof(DialogueVictorInter)) as DialogueTyperBase;
                cur_dialogue.Initialise();
                score = 0;
                break;
            case "emo_outro":
                if (score > highscore_emo) highscore_emo = Mathf.FloorToInt(score);
                cur_dialogue = DialogueDisplayer.gameObject.AddComponent(typeof(DialogueEmoOutroWL)) as DialogueEmoOutroWL;      //typeof(DialogueVictorInter)) as DialogueTyperBase;
                cur_dialogue.Initialise();
                break;
            case "devil_intro":
                cur_dialogue = DialogueDisplayer.gameObject.AddComponent(typeof(DialogueDevilIntro)) as DialogueDevilIntro;      //typeof(DialogueVictorInter)) as DialogueTyperBase;
                cur_dialogue.Initialise();
                score = 0;
                break;
            case "devil_outro":
                if(score> highscore_devil) highscore_devil = Mathf.FloorToInt(score);
                cur_dialogue = DialogueDisplayer.gameObject.AddComponent(typeof(DialogueDevilOutroWL)) as DialogueDevilOutroWL;      //typeof(DialogueVictorInter)) as DialogueTyperBase;
                cur_dialogue.Initialise();
                score = 0;
                break;
            case "outro":
                if (score > highscore_final) highscore_final = Mathf.FloorToInt(score);
                break;
        }
    }

    public void CloseGame() 
    {
        Application.Quit();
    }
}
