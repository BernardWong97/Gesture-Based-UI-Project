using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    private Text scoreUI;
    public static float score;
    public static bool isMenu = true;

    private void Start()
    {
        if(!isMenu)
            scoreUI = GameObject.Find("Points").GetComponent<Text>();

        double timer = Math.Round(Timer.timer, 0, MidpointRounding.AwayFromZero);

        if (timer <= 20)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1.2f;
        } 
        else if (timer <= 40)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
        }
            
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() && isMenu)
            return;

        score = Convert.ToInt32(scoreUI.text);
        score += 10;
        scoreUI.text = score.ToString();
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.3f);
    }
}
