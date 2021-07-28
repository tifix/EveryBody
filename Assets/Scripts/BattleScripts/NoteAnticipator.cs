using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAnticipator : MonoBehaviour
{
    public static NoteAnticipator instance;
    public Transform A_pos;
    public Transform S_pos;
    public Transform K_pos;
    public Transform L_pos;
    public GameObject anticip_note;

    public void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }


    public static GameObject SpawnANote(Note sibling_note) 
    {
        return instance.SpawnAnticipationNote(instance.anticip_note, instance.A_pos, sibling_note);
    }
    public static GameObject SpawnSNote(Note sibling_note)
    {
        return instance.SpawnAnticipationNote(instance.anticip_note, instance.S_pos, sibling_note);
    }
    public static GameObject SpawnKNote(Note sibling_note)
    {
        return instance.SpawnAnticipationNote(instance.anticip_note, instance.K_pos, sibling_note);
    }
    public static GameObject SpawnLNote(Note sibling_note)
    {
        return instance.SpawnAnticipationNote(instance.anticip_note, instance.L_pos, sibling_note);
    }



    public GameObject SpawnAnticipationNote(GameObject note_prefab, Transform transf,Note sibling) 
    {
        //Debug.Log("spawning anticip");
        GameObject anticip_note = GameObject.Instantiate(note_prefab,transf.position,Quaternion.identity);
        anticip_note.transform.SetParent(instance.transform);
        anticip_note.transform.localScale = new Vector3(3000 * sibling.duration*SongReciever.instance.beat_interval, 324, 0);
        anticip_note.GetComponent<MoveAndDie>().sibling_note = sibling;

        return anticip_note;
    }


}
