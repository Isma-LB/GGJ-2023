using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{

    AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

    }
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        audioManager?.PlayClickEffect();
    }

    public void Salir()
    {
        audioManager?.PlayClickEffect();
        Debug.Log("Salir...");
        Application.Quit();
    }
}
