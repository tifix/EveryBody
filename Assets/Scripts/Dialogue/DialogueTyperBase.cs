using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTyperBase : MonoBehaviour
{
    public Color col_player= Color.white;
    public Color col_devil = new Color(0.50f,0.28f,0.85f);
    public Color col_emo = new Color(0.48f, 0.48f, 0.48f); //Color.black;
    public Color col_victoria = new Color(0.88f,0.66f,0f);

    public GameObject textBox; //this is here in case the text box's visibility needs to be toggled on/off.
                               //Just drop the textbox image here in the inspector

    protected string dialog; //the dialogue
    public Text txt; //the text that displays the dialogue in UI
    public Font font;

    public bool canSkip; //determines if we are in the middle of typing the text and thus can skip it
    protected bool runCoroutine; //we need this so that the coroutine doesn't try to run every frame

    protected int i = 0; //this is used to get dialogue onwards with switch case

    public float typingWait = 0.05f; //how much time passes between the letters typed
    public float base_typingWait = 0.05f; //how much time passes between the letters typed

    //setting the font
    public virtual void Awake()
    {
        if (txt != null && font != null) txt.font = font;
    }

    public void Update()
    {
        TheDialogueLogic();
        Dialogue();
    }

    public void TheDialogueLogic() //advancing the dialogue and determining if we can skip it
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!canSkip)
            {
                i++;
                runCoroutine = false;
            }
            else
            {
                StopAllCoroutines();
                txt.text = dialog;
                canSkip = false;
            }
        }
    }

    public virtual void Dialogue() //the dialogue itself
    {
        switch (i) 
        {
            case 0:
                dialog = "This is a switch case statement.";
                Coroutine();
                break;
            case 1:
                dialog = "We can forward the dialogue with as many cases as we need..";
                Coroutine();
                break;
            case 2:
                dialog = "It's pretty neet.";
                Coroutine();
                break;
        }
    }

    public void Coroutine() //running the coroutine
    {
        if (!runCoroutine)
        {
            StartCoroutine(Typer());
            runCoroutine = true;
        }
    }

    public IEnumerator Typer() //typing the text
    {
        if(font!=null) txt.font = font;
        for (int i = 0; i < (dialog.Length + 1); i++)
        {
            canSkip = true;
            txt.text = dialog.Substring(0, i);
            yield return new WaitForSeconds(typingWait);
        }
        txt.text = dialog;
        canSkip = false;
    }

    public void Initialise() 
    {
        if (textBox == null) textBox = gameObject;
        if (txt == null) txt = gameObject.GetComponent<Text>();
    }
}
