using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelEvents : MonoBehaviour
{
    public TutorialUI tutorialUI;
    public GameObject lvl1Gems;

    private int number = 0;

    void Start()
    {
        tutorialUI = FindObjectOfType<TutorialUI>();
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
            Invoke("PlayText", 2);
        }
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
