using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTestForScriptableObject : MonoBehaviour
{
    [SerializeField] SoundEffectCollection soundEffect;
    [SerializeField] AudioSource audioSource;


    // Update is called once per frame
    void Update()
    {
        if(soundEffect && Input.GetKeyDown(KeyCode.B)){
            soundEffect.play(ref audioSource);
        }    
    }
}
