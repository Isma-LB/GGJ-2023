using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource normalSong;
    [SerializeField] AudioSource chaseSong;
    [SerializeField] AudioSource changeEffect;
    [SerializeField] AudioSource effectsSource;
    [SerializeField] SoundEffectCollection footsteps;
    [SerializeField] SoundEffectCollection pickItem;
    [SerializeField] SoundEffectCollection winEffect;
    [SerializeField] SoundEffectCollection gameOverEffect;
    [SerializeField] SoundEffectCollection clickButton;
    [SerializeField, Range(0,1)] float musicVolume = 0.5f;
    [SerializeField, Range(0,2)] float fadeSpeed = 1;
    [SerializeField, Range(0,2)] float footstepsPeriod = 1;
    bool isChasing = false;
    float nextFootstep = 0;

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

    public bool IsWaling {
    set{
        if(value == true){
            nextFootstep -= Time.deltaTime;
            if(nextFootstep < 0){
                footsteps.play(ref effectsSource);
                nextFootstep = footstepsPeriod;
            }
        }
    } 
    }

    public void PlayStep(){
        footsteps?.play(ref effectsSource);
    }
    public void PlayPickEffect(){
        pickItem?.play(ref effectsSource);
    }
    public void PlayWinEffect(){
        winEffect?.play(ref effectsSource);
    }
    public void PlayGameOverEffect(){
        gameOverEffect?.play(ref effectsSource);
    }
    public void PlayClickEffect(){
        clickButton?.play(ref effectsSource);
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
        while(volume < musicVolume){
            volume += Time.unscaledDeltaTime * fadeSpeed;
            audioSource.volume = volume;
            yield return null;
        }
        audioSource.volume = musicVolume;
    }
    IEnumerator fadeOut(AudioSource audioSource){
        float volume = musicVolume;
        while(volume > 0){
            volume -= Time.unscaledDeltaTime * fadeSpeed;
            audioSource.volume = volume;
            yield return null;
        }
        audioSource.volume = 0f;
    }
}
