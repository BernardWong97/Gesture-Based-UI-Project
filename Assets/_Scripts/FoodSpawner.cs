using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 *  Food spawner class controlling the spawning of the foods.
 */
public class FoodSpawner : MonoBehaviour
{
    private float maxTime = 5;
    private float minTime = 1;
    private float time;
    private float spawnTime;
    public static bool isIncrease = false;
    public GameObject[] foods;
    private GameObject foodNow;

    void FixedUpdate()
    {
        time += Time.deltaTime;

        // if spawn time reach, spawn a random food and reset timer.
        if (time >= spawnTime)
        {
            foodNow = foods[Random.Range(0, foods.Length - 1)];
            Spawn();
            SetRandomTime();
            time = 0;
        }

    }
    
    private void Start()
    {
        SetRandomTime();
        time = 0;
    }

    /**
     * Set a random time to spawn food.
     */
    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    /**
	 * Spawn a food.
	 */
    private void Spawn()
    {
        Instantiate(foodNow, transform.position, transform.rotation);
    }
}
