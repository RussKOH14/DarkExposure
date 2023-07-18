using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public float delay = 0.1f;
    public string[] fullTexts;
    private string currentText = "";
    private TMP_Text tmpText;
    private int currentLayer = -1; // Initialize with -1 to indicate no current layer
    public AudioClip typeSound;
    public AudioSource audioSource;

    private bool isTyping = false;

    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
        audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        List<int> remainingLayers = new List<int>();
        for (int i = 0; i < fullTexts.Length; i++)
        {
            remainingLayers.Add(i);
        }

        while (remainingLayers.Count > 0)
        {
            isTyping = true;
            int randomIndex = Random.Range(0, remainingLayers.Count);
            currentLayer = remainingLayers[randomIndex];
            remainingLayers.RemoveAt(randomIndex);

            for (int i = 0; i < fullTexts[currentLayer].Length; i++)
            {
                currentText = fullTexts[currentLayer].Substring(0, i);
                tmpText.text = currentText;
                audioSource.PlayOneShot(typeSound);
                yield return new WaitForSeconds(delay);
            }

            isTyping = false;
            yield return new WaitUntil(() => isTyping); // Wait until user interaction or event triggers the next text
            currentText = "";
            tmpText.text = currentText;
        }

        currentLayer = -1; // Reset current layer after all texts have been shown
    }

    // Call this method to progress to the next text
    public void NextText()
    {
        if (!isTyping)
            isTyping = true;
    }
}
