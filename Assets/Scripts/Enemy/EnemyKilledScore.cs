using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyKilledScore : MonoBehaviour
{
    public int enemiesKilled;
    public TextMeshProUGUI enemiesKilledText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesKilledText.text = enemiesKilled.ToString();
    }
}
