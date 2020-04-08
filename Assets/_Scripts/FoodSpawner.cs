using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    private float maxTime = 5;
    private float minTime = 1;
    private float time;
    private float spawnTime;
    public static bool isIncrease = false;
    private bool pauseSpawn = false;
    public GameObject[] foods;

    private GameObject foodNow;

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (time >= spawnTime && !pauseSpawn)
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

    private void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void Spawn()
    {
        Instantiate(foodNow, transform.position, transform.rotation);
    }
}
