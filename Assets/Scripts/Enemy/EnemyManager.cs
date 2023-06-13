using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject easiestEnemy;
    [SerializeField] int numberOfEasiestEnemy = 01;
    
    [SerializeField] GameObject harderEnemies;
    [SerializeField] int numberOfHarderEnemy = 01;
    public bool spawningHarderEnemies=false;

    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer = 0f;
    [SerializeField] GameObject player;
    public float delay = 5f;
    public float longerDelay = 5f;


    public float decreaseInterval = 20f; 
    public int numberToDecrease = -1;
    
    private void Awake()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        
        if (delay >1)
        {
            spawnTimer += Time.deltaTime; // Increase the timer with the elapsed time
            if (spawnTimer >= decreaseInterval)
            {
                // Increase the number
                delay += numberToDecrease;

                // Reset the timer by subtracting the increase interval multiple times
                spawnTimer -= decreaseInterval * (int)(spawnTimer / decreaseInterval);
            }
        }
        if (delay == 1 && !spawningHarderEnemies)
        {
            SpawnHarderEnemy();
            spawningHarderEnemies = true;
        }
       
    }


    public void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        for (int i = 0; i < numberOfEasiestEnemy; i++) 
        {
            GameObject easiestEnemy = Instantiate(this.easiestEnemy);
            easiestEnemy.transform.position = position;
            easiestEnemy.GetComponent<Enemy>().SetTarget(player);
            easiestEnemy.transform.parent = transform;
            

        }
        Invoke("SpawnEnemy", delay);
    }
    public void SpawnHarderEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        for (int i = 0; i < numberOfHarderEnemy; i++) 
        {
            GameObject harderEnemies = Instantiate(this.harderEnemies);
            harderEnemies.transform.position = position;
            harderEnemies.GetComponent<Enemy>().SetTarget(player);
            harderEnemies.transform.parent = transform;
            

        }
        Invoke("SpawnHarderEnemy", longerDelay);
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if(UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
            position.x = spawnArea.x * f;

        }
        position.z = 0;

        return position;
    }
}
