using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLevelEvents : MonoBehaviour
{
    TutorialUI tutorialUI;
    public GameObject gems;

    void Start()
    {
        tutorialUI = FindObjectOfType<TutorialUI>();
    }

    
    void Update()
    {
        if(tutorialUI.isTyping && gems != null && gems.activeInHierarchy == false)
        {
            gems.SetActive(true);
            Debug.Log("gems");
        }
    }
}
