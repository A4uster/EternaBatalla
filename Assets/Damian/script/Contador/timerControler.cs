using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerControler : MonoBehaviour
{
    public float timer = 0;
    public Text textoTimer;

    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text = "" + timer.ToString("f0");
        if (timer <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }
    }
}
