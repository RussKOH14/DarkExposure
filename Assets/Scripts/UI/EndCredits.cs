using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{

    public float targetTime = 60.0f;

    public void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }

    void timerEnded()
    {
        SceneManager.LoadScene("Shop");
    }


}
