using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public GameObject[] powerUps;
    public int difficulty;
    public float delay;
    float timeFromSpawn;
    public float[] spawnPoints;

    System.Random rand = new System.Random();

    void Start()
    {
        timeFromSpawn = Time.fixedTime;
    }

    
    void Update()
    {
        if (GameHandler.GameSpeed == 4)
        {
            delay = 3;
        }
        if (GameHandler.GameSpeed == 2)
        {
            delay = 6;
        }
        if (timeFromSpawn >= delay)
        {
            if (rand.Next(0,1000) <= difficulty)
            {
                Instantiate(powerUps[rand.Next(0, powerUps.Length)], new Vector2(transform.position.x, spawnPoints[rand.Next(0, spawnPoints.Length)]), transform.rotation);
                timeFromSpawn = 0;
            }
        }
        timeFromSpawn += Time.deltaTime;
    }
}
 