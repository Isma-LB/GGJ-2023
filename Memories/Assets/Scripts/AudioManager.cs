using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource normalSong;
    [SerializeField] AudioSource chaseSong;
    [SerializeField] AudioSource changeEffect;
    [SerializeField, Range(0,2)] float fadeSpeed = 1;
    bool isChasing = false;

    public bool IsChasing { 
        get => isChasing;
        set {
            if(value != isChasing){
                isChasing = value;
                if(isChasing){
                    StartCoroutine(fadeOut(normalSong));
                    changeEffect.Play();
                    StartCoroutine(fadeIn(chaseSong));
                }
                else{
                    StartCoroutine(fadeOut(chaseSong));
                    StartCoroutine(fadeIn(normalSong));
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fadeIn(normalSong));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)){
            this.IsChasing = !this.isChasing;
        }
    }

    IEnumerator fadeIn(AudioSource audioSource){
        float volume = 0;
        while(volume < 1f){
            volume += Time.unscaledDeltaTime * fadeSpeed;
            audioSource.volume = volume;
            yield return null;
        }
        audioSource.volume = 1f;
    }
    IEnumerator fadeOut(AudioSource audioSource){
        float volume = 1;
        while(volume > 0){
            volume -= Time.unscaledDeltaTime * fadeSpeed;
            audioSource.volume = volume;
            yield return null;
        }
        audioSource.volume = 0f;
    }
}
