using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI inputScore;
    [SerializeField]
    private TMP_InputField inputName;

   // TimerUI timer;

    public UnityEvent<string, int> submitScoreEvent;

    //private void Awake()
    //{
    //    timer = GetComponent<TimerUI>();
    //}
    //private void Start()
    //{
    //    inputScore.text = timer.text.ToString()
    //}
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}
