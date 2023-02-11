using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_FadeSquare : MonoBehaviour
{
    public float fadeSpeed = 1.0f;
    private SpriteRenderer spriteRenderer;
    private float targetAlpha;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetAlpha = spriteRenderer.color.a;
        FadeOut();
    }

    void Update()
    {
        Color curColor = spriteRenderer.color;
        float alphaDiff = Mathf.Abs(curColor.a - targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeSpeed * Time.deltaTime);
            spriteRenderer.color = curColor;
        }
    }

    public void FadeOut()
    {
        targetAlpha = 0.0f;
    }

    public void FadeIn()
    {
        targetAlpha = 1.0f;
    }
}
