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
            for (int i = 0; i < fullTexts[currentLayer].Length; i++)
            {
                currentText = fullTexts[currentLayer].Substring(0, i);
                tmpText.text = currentText;
                audioSource.PlayOneShot(typeSound);
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(3f);
            currentText = "";
            tmpText.text = currentText;
            currentLayer++;
        }
    }
}
