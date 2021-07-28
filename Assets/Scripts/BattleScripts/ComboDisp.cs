using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboDisp : PulsingMovement
{
    public override void Update()
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


        base.Update();

        //applying display effects
        GetComponent<Text>().text = "combo "+ PlayerInput.instance.streak.ToString();
    }

}
