using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEventManager : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] EnemyManager enemyManager;
    StageTimer stageTimer;
    int eventIndexer;

    private void Awake()
    {
        stageTimer = GetComponent<StageTimer>();
    }
    private void Update()
    {

        if (eventIndexer >= stageData.stageEvent.Count)
        {
            return;
        }

        if (stageTimer.time > stageData.stageEvent[eventIndexer].time)
        {
            Debug.Log(stageData.stageEvent[eventIndexer].message);

            for(int i = 0; i < stageData.stageEvent[eventIndexer].count; i++)
            {
                enemyManager.SpawnEnemy();
            }
            
            eventIndexer += 1;
        }
    }

}
