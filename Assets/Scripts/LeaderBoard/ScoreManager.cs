using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI inputScore;
    //[SerializeField]
    //public TMP_InputField inputName;

    private void Start()
    {
        
    }

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        string inputName = PlayerPrefs.GetString("Player Name");
        submitScoreEvent.Invoke(inputName, int.Parse(inputScore.text));
    }
}
