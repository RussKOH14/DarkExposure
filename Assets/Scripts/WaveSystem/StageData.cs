using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum StageEventType
{
    SpawnEnemy,
    SpawnObject
}
[Serializable]
public class StageEvent
{
    public StageEventType eventType;
    public float time;
    public string message;
    public Enemy enemyToSpawn;
    public GameObject objectToSpawn;
    public int count;
}

[CreateAssetMenu]
public class StageData : ScriptableObject
{
   public  List<StageEvent> stageEvent;
}
