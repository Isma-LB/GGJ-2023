using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] UnityEvent onWinGame; 
    [SerializeField] UnityEvent onGameOver; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.F)){
            restartGame();
        }
    }
    public void gameOver(){
        Debug.Log("Game over!");
        onGameOver.Invoke();
    }
    public void winGame(){
        Debug.Log("You Win!");
        onWinGame.Invoke();
    }
    void restartGame(){
        Debug.Log("Restart game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
