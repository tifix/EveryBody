using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Devil_ting : MonoBehaviour
{
    public static Devil_ting instance;
    public void Awake()
    {
        instance = this;
    }

    public  void Ting()
    {
        if (GameObject.Find("Frame_Enemy").TryGetComponent<Image>(out Image SR))
        {
            SR.color = new Color(1, 1, 1, 1);
            SR.sprite = Resources.Load<Sprite>("Devil_Triangle")as Sprite;
        }
    }


}
