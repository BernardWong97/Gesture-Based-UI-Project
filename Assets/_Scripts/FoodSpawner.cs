using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private float maxTime = 2;
    private float minTime = 0.2f;
    private float time;
    private float spawnTime;
    private float foodIndex;
    public GameObject[] foods;

    private GameObject foodNow;

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            foodNow = foods[Random.Range(0, foods.Length - 1)];
            Debug.Log("Time to spawn: " + foodNow.name);
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

    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        Debug.Log("Next food spawn in " + spawnTime + " seconds.");
    }

    

    private void Spawn()
    {
        Instantiate(foodNow, transform.position, transform.rotation);
    }
}
