using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameplay()
    {
        SceneManager.LoadScene("TestScene");
        Time.timeScale = 1f;
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
