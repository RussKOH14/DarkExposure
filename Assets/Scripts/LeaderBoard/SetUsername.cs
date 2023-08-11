using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetUsername : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        DontDestroyOnLoad(inputField);
        string playerName =  PlayerPrefs.GetString("Player Name");
        inputField.text = playerName;
        inputField.characterLimit = 10;
    }

    void Update()
    {
        PlayerPrefs.SetString("Player Name", inputField.text);
        PlayerPrefs.Save();
    }
}
