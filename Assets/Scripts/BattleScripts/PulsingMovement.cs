using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PulsingMovement : MonoBehaviour
{
    public float scale = 0.1f;
    public float frequency = 1;
    public Color color;

    // Update is called once per frame
    public virtual void Update()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.localScale = (Mathf.Abs(Mathf.Sin(Time.time * frequency)) * scale + 1) * Vector3.one;
        if (TryGetComponent<Text>(out Text txt)) txt.color = color;
    }
}
