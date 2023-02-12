using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonAudio : MonoBehaviour
{

    public AudioSource sonido;

    public void ButtonSound()
    {
        sonido.Play();
    }
}
