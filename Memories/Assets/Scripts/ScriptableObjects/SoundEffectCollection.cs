using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Memories/SoundEffectCollection")]
public class SoundEffectCollection : ScriptableObject
{
    [SerializeField] List<AudioClip> sounds;
    [SerializeField, Range(0,2)] float pitch = 1f;
    [SerializeField, Range(0,2)] float pitchVariation = 0f;
    [SerializeField, Range(0,2)] float volume = 1f;
    [SerializeField, Range(0,2)] float volumeVariation = 1f;

    public void play( ref AudioSource audioSource){
        audioSource.pitch = pitch + Random.Range(-pitchVariation,pitchVariation);
        audioSource.volume = volume + Random.Range(-volumeVariation,volumeVariation);
        int randomIndex = Random.Range(0,sounds.Count - 1);
        audioSource.clip = sounds[randomIndex];
        audioSource.Play();
    }
}
