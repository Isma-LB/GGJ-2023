using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent onWinGame; 
    [SerializeField] UnityEvent onGameOver;
    bool gano = false;
    bool perdio = false;
    AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            restartGame();
        }

        if (Input.GetKeyDown(KeyCode.V) )
        {
            winGame();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameOver();
        }
    }
    public void gameOver(){
        if(gano == false)
        {
            audioManager?.PlayGameOverEffect();
            onGameOver.Invoke();
            perdio = true;
        }
    }
    public void winGame(){
        if(perdio == false)
        {
            audioManager?.PlayWinEffect();
            onWinGame.Invoke();
            gano = true;
        }
    }
    void restartGame(){
        Debug.Log("Restart game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
