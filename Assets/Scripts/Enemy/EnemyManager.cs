using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Knights")]
    [SerializeField] GameObject easiestEnemy;
    [SerializeField] int numberOfEasiestEnemy = 01;
    public float delay = 1f;

    [Header("Fairies")]
    [SerializeField] GameObject harderEnemies;
    [SerializeField] int numberOfHarderEnemy = 01;
    public bool spawningHarderEnemies=false;
    public float longerDelay = 2f;

    [Header("DonCheedle")]
    [SerializeField] GameObject donCheedle;
    [SerializeField] int numberOfDonCheedle = 01;
    public bool spawningDonCheedle = false;
    public float delayForCheedle = 3f;
    public Vector3 prefabSize;

    [Header("Other stats")]
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer = 0f;
    [SerializeField] GameObject player;
    public float decreaseInterval = 20f; 
    public float numberToDecrease = -0.1f;
    
    private void Awake()
    {
        SpawnEnemy();
    }

    private void Update()
    {
        
        if (delay >0.2)
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
        if (delay <= 0.8 && !spawningHarderEnemies)
        {
            SpawnHarderEnemy();
            spawningHarderEnemies = true;
        }
        
        if (delay <= 0.5 && !spawningDonCheedle)
        {
            SpawnDonCheedle();
            spawningDonCheedle = true;
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
    
    public void SpawnDonCheedle()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        for (int i = 0; i < numberOfDonCheedle; i++) 
        {
            GameObject donCheedle = Instantiate(this.donCheedle);
            donCheedle.transform.localScale = prefabSize;
            donCheedle.transform.position = position;
            donCheedle.GetComponent<Enemy>().SetTarget(player);
            donCheedle.transform.parent = transform;


        }
        Invoke("SpawnDonCheedle", delayForCheedle);
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
