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
        enemyManager.SpawnEnemy();

        if (eventIndexer >= stageData.stageEvent.Count)
        {
            return;
        }

        if (stageTimer.time > stageData.stageEvent[eventIndexer].time)
        {
            switch (stageData.stageEvent[eventIndexer].eventType)
            {
                //case StageEventType.SpawnEnemy:
                //    for (int i = 0; i < stageData.stageEvent[eventIndexer].count; i++)
                //    {
                //        enemyManager.SpawnEnemy();
                //    }
                //    break;
                //case StageEventType.SpawnObject:

                //    break;
            }
            Debug.Log(stageData.stageEvent[eventIndexer].message);
            eventIndexer += 1;
        }
    }

}
