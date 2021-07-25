using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboDisp : MonoBehaviour
{

    public float scale = 0.1f;
    public float frequency=1;
    public Color color;

    public void Update()
    {
        if (PlayerInput.instance.multiplier <2) 
        {
            color = Color.white;
            frequency = 1;
        }
        else if (PlayerInput.instance.multiplier <4)
        {
            color = Color.yellow;
            frequency = 2;
        }
        else if (PlayerInput.instance.multiplier >3)
        {
            color = Color.red;
            frequency = 5;
        }



        //applying display effects
        RectTransform rt = GetComponent<RectTransform>();
        rt.localScale = (Mathf.Abs( Mathf.Sin(Time.time*frequency)) * scale  + 1) * Vector3.one;
        GetComponent<Text>().color = color;
        GetComponent<Text>().text = "combo "+ PlayerInput.instance.streak.ToString();
    }

}
