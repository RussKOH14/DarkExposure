using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameplay()
    {
        LoadData();
        if(ShopGameManager.Instance.dataContainer.tutorial != 0)
        {
            SceneManager.LoadScene("TestScene");
            Time.timeScale = 1f;
        }
        else if (ShopGameManager.Instance.dataContainer.tutorial == 0)
        {
            SceneManager.LoadScene("Tutorial");
            Time.timeScale = 1f;
        }

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
    private void LoadData()
    {
        ShopGameManager.Instance.LoadData();
    }

    private void SaveData()
    {
        ShopGameManager.Instance.SaveData();
    }
}
