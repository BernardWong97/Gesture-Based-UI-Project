using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    private Text scoreUI;
    private float score;

    private void Start()
    {
        scoreUI = GameObject.Find("Points").GetComponent<Text>();
    }

    private void OnMouseDown()
    {
        score = Convert.ToInt32(scoreUI.text);
        score += 10;
        scoreUI.text = score.ToString();
        Destroy(this.gameObject);
    }
}
