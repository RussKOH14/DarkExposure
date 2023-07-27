using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string[] fullTexts;
    private string currentText = "";
    private TMP_Text tmpText;
    private int currentLayer = 0;
    private int charCounter = 0;
    public AudioClip typeSound;
    public AudioSource audioSource;

   

    void Start()
    {
        
        tmpText = GetComponent<TMP_Text>();
        StartCoroutine(ShowText());
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    IEnumerator ShowText()
    {
        while (currentLayer < fullTexts.Length)
        {
            charCounter = 0;

            while (charCounter < fullTexts[currentLayer].Length)
            {
                currentText = fullTexts[currentLayer].Substring(0, charCounter + 1);
                tmpText.text = currentText;

                
                if (charCounter % 2 == 0)
                {
                    audioSource.PlayOneShot(typeSound);
                }

                charCounter++;

                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(3f);
            currentText = "";
            tmpText.text = currentText;
            currentLayer++;
        }
    }
}
