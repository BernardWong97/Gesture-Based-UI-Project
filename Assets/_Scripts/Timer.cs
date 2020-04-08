using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 *  Control the countdown timer of the game.
 */
public class Timer : MonoBehaviour
{
    private TextMeshProUGUI tmp;
    public static float timer;
    private bool canCount = true;
    private bool doOnce = false;

    private void Start()
    {
        timer = 60;
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            tmp.text = Math.Round(timer, 0, MidpointRounding.AwayFromZero).ToString();
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            tmp.text = "0";
            timer = 0.0f;

            // game over
            SceneManager.LoadScene(2);
        }
    }
}
