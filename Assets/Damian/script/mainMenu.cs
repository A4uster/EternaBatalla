using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void newGame()
    {
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    { 
        Application.Quit();
        Debug.Log("Saliendo de la aplicacion");
    }
}
