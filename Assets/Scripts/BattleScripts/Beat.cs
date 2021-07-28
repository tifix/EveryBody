using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Beat
{
    [HideInInspector]public string name = "Beat";
    [Tooltip("Beats are made out of notes (4 by default)")]
    public List<Note> notes = new List<Note>();

    public string Name { get => name; set => name = value; }
}
