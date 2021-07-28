using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnyKeyKill : MonoBehaviour
{
    public float warmup_time = 1;

    public void Start()
    {
        try { transform.GetChild(0).gameObject.SetActive(false); }
        catch { }
        Invoke("ZaWordo", warmup_time);
    }

    void Update()
    {
        if (Input.anyKeyDown) 
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
        

    }
    public void ZaWordo() 
    {
        try { transform.GetChild(0).gameObject.SetActive(true); }
        catch { }
        Time.timeScale = 0.01f;
    }
}
