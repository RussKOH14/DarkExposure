using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelEvents : MonoBehaviour
{
    public TutorialUI tutorialUI;
    public GameObject lvl1Gems;

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

        if (!lvl1Gems)
        {
            tutorialUI.currentLayer++;

            if (tutorialUI.currentLayer < tutorialUI.fullTexts.Length)
            {
                tutorialUI.tmpText.text = "";
                tutorialUI.isTyping = true;
                tutorialUI.DisplayText();
            }
        }
    }
}
