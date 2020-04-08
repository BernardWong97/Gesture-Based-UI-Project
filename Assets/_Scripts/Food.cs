using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    private Text scoreUI;
    private float score;
    public static bool isMenu = true;

    private void Start()
    {
        if(!isMenu)
            scoreUI = GameObject.Find("Points").GetComponent<Text>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject() && isMenu)
            return;

        score = Convert.ToInt32(scoreUI.text);
        score += 10;
        scoreUI.text = score.ToString();
        Destroy(this.gameObject);
    }
}
