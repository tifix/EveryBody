using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Devil_ting : MonoBehaviour
{
    void Ting()
    {
        if (GameObject.Find("Frame_Enemy").TryGetComponent<Image>(out Image SR))
        {
            SR.color = new Color(1, 1, 1, 1);
            SR.sprite = Resources.Load<Sprite>("Devil_Triangle")as Sprite;
        }
    }
    private void Start()
    {
        Invoke("Ting", 48.5f);
    }

}
