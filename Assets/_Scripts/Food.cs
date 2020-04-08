using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


/**
 *  Food class controlling user interaction and properties of the foods.
 */
public class Food : MonoBehaviour
{
    private Text scoreUI;
    public static float score;
    public static bool isMenu = true;

    private void Start()
    {
        // if the game state is not in a menu but in game, get score UI
        if(!isMenu)
            scoreUI = GameObject.Find("Points").GetComponent<Text>();

        // get the current time of the countdown timer from Timer class.
        double timer = Math.Round(Timer.timer, 0, MidpointRounding.AwayFromZero);

        // For every 20 seconds, the velocity of the food dropping increases.
        if (timer <= 20)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.75f;
        } 
        else if (timer <= 40)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.25f;
        }
            
    }

    /**
	 * Add score and destroy current food when tapped.
	 */
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
