using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher instance;
    public bool is_debugging = false;
    public Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) { instance = this; DontDestroyOnLoad(this); }
        else Destroy(this);
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

    public static void LoadScene(int scene_number) 
    {
        SceneManager.LoadScene(scene_number);
    } 
}
