using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TutorialLevelWaveSystem : MonoBehaviour
{
    public float delay = 0.05f;
    public string[] deathDialogue;
    public string currentText;
    private TMP_Text tmpText;
    private int currentLayer = 0;
    private int charCounter = 0;
    public AudioClip typeSound;
    public AudioSource audioSource;
    private bool isTyping = true;

    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        StartCoroutine(ShowText());
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                StopCoroutine(ShowText());
                tmpText.text = deathDialogue[currentLayer];
                isTyping = false;
            }
            else
            {
                deathDialogue[currentLayer].Remove(currentLayer);
                currentLayer++;

                if (currentLayer < deathDialogue.Length)
                {
                    tmpText.text = "";
                    isTyping = true;
                    DisplayText();
                }
                else
                {
                    
                }
            }
        }
    }
    void DisplayText()
    {
        if (isTyping)
        {
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText()
    {
        charCounter = 0;
        while (charCounter < deathDialogue[currentLayer].Length && isTyping)
        {
            currentText = deathDialogue[currentLayer].Substring(0, charCounter + 1);
            tmpText.text = currentText;

            if (charCounter % 2 == 0)
            {
                audioSource.PlayOneShot(typeSound);
            }

            charCounter++;

            yield return new WaitForSeconds(delay);
        }

        isTyping = false;
    }
}
