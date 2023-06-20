using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weaponParent;
    [HideInInspector] public StageTimer stageTimer;
    public GameObject world;

    private void Awake()
    {
        stageTimer = world.GetComponent<StageTimer>();
    }
    public void GameOver()
    {
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true);
        weaponParent.SetActive(false);
        stageTimer.timeRunning = false;
    }
}
