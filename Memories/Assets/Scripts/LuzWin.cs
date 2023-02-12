using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LuzWin : MonoBehaviour
{
    [SerializeField] Light2D luz;
    public float fadeSpeed = 0.7f;
    private float intensidad;

    // Start is called before the first frame update
    void Start()
    {
        intensidad = luz.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        float alphaDiff = Mathf.Abs(luz.intensity - intensidad);
        if (alphaDiff > 0.001f)
        {
            luz.intensity = Mathf.Lerp(luz.intensity, intensidad, fadeSpeed * Time.deltaTime);
        }
    }
    
    public void FaidIn()
    {
        intensidad = 0.7f;
    }
}
