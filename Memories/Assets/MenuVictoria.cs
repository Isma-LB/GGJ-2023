using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuVictoria : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Martin");
    }
    public void Activar()
    {
        gameObject.SetActive(true);
    }
}
