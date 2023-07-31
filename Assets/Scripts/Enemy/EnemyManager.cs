using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Golem")]
    [SerializeField] GameObject golem;
    [SerializeField] int numberOfGolem = 01;
    public float delay = 1f;

    [Header("Knight")]
    [SerializeField] GameObject knight;
    [SerializeField] int numberOfKnights = 01;
    public bool spawningKnights=false;
    public float longerDelay = 2f;

    [Header("Fairies")]
    [SerializeField] GameObject Fairies;
    [SerializeField] int numberOfFairies = 01;
    public bool spawningFairies = false;
    public float delayForFairies = 3f;
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
        if (delay <= 0.8 && !spawningKnights)
        {
            SpawnHarderEnemy();
            spawningKnights = true;
        }
        
        if (delay <= 0.5 && !spawningFairies)
        {
            SpawnDonCheedle();
            spawningFairies = true;
        }
       
    }


    public void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;

        for (int i = 0; i < numberOfGolem; i++) 
        {
            GameObject easiestEnemy = Instantiate(this.golem);
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

        for (int i = 0; i < numberOfKnights; i++) 
        {
            GameObject harderEnemies = Instantiate(this.knight);
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

        for (int i = 0; i < numberOfFairies; i++) 
        {
            GameObject donCheedle = Instantiate(this.Fairies);
            donCheedle.transform.localScale = prefabSize;
            donCheedle.transform.position = position;
            donCheedle.GetComponent<Enemy>().SetTarget(player);
            donCheedle.transform.parent = transform;


        }
        Invoke("SpawnDonCheedle", delayForFairies);
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
