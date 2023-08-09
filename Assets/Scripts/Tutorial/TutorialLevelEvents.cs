using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelEvents : MonoBehaviour
{
    public TutorialUI tutorialUI;
    public GameObject lvl1Gems;

    private int number = 0;

    public GameObject character;
    TutorialEnemySpawn tutorialEnemySpawn;

    public GameObject swordButton;
    public GameObject wandButton;
    
    
    public GameObject ManualWeapon;
    public GameObject upgradePanel;


    void Start()
    {
        tutorialUI = FindObjectOfType<TutorialUI>();
        tutorialEnemySpawn = FindObjectOfType<TutorialEnemySpawn>();
    }

    
    void Update()
    {
        if(!tutorialUI.isTyping && lvl1Gems != null && lvl1Gems.activeInHierarchy == false)
        {
            lvl1Gems.SetActive(true);
            Debug.Log("gems");
            
        }

        if(!lvl1Gems && number == 0)
        {
            number+=1;
            print("collided");
            Invoke("PlayText", 0.5f);
        }
    }
 
    public void Sword()
    {
        character.GetComponent<WeaponManager>().enabled = true;
        Invoke("Golem", 5);
    }

    public void Wand()
    {
        ManualWeapon.SetActive(true);
        Invoke("PlayText", 0.5f);
        Invoke("DestroyUpgradePanel", 2);
    }

    public void DestroyUpgradePanel()
    {
        Destroy(upgradePanel);
    }

    public void UsingWand()
    {
        if (number == 1)
        {
            number += 1;
            Invoke("PlayText", 0.5f);
        }
    }

    public void Golem()
    {
        tutorialEnemySpawn.SpawnEnemy();
        PlayText();
        swordButton.SetActive(false);
        wandButton.SetActive(true);
    }

    public void PlayText()
    {
        if (tutorialUI.currentLayer < tutorialUI.fullTexts.Length)
        {
            tutorialUI.currentLayer++;
            tutorialUI.tmpText.text = "";
            tutorialUI.isTyping = true;
            tutorialUI.DisplayText();

        }
    }
}
