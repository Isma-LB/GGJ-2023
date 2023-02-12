using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectosWin : MonoBehaviour
{
    [SerializeField] SpriteRenderer niebla;
    public float fadeSpeed = 0.7f;
    private float targetAlpha;

    // Start is called before the first frame update
    void Start()
    {
        targetAlpha = niebla.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        Color curColor = niebla.color;
        float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
            niebla.color = curColor;
        }
    }

    public void FadeOut()
    {
        targetAlpha = 0.0f;
    }

}
