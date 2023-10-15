using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject shopLock;

    private void Update()
    {
        if (ShopGameManager.Instance.dataContainer.shopUnlocked >= 1)
        {
            shopLock.SetActive(false);
        }
        else
        {
            shopLock.SetActive(true);
        }
    }
    public void StartGameplay()
    {
        LoadData();
        if(ShopGameManager.Instance.dataContainer.tutorial != 0)
        {
            SceneManager.LoadScene("Villain1");
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
        
        if (ShopGameManager.Instance.dataContainer.keys >= 1|| ShopGameManager.Instance.dataContainer.shopUnlocked >=1)
        {
            SceneManager.LoadScene("Shop");
            Time.timeScale = 1f;
            
            if (ShopGameManager.Instance.dataContainer.shopUnlocked == 0)
            {
                shopLock.SetActive(false);
                print("unlocked");
                ShopGameManager.Instance.dataContainer.shopUnlocked ++;
                ShopGameManager.Instance.dataContainer.keys -= 1;
                SaveData();
            }
        }
        
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
