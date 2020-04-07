﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Menu controller
 */
public class Menu : MonoBehaviour {

	public static bool IsPaused = false;
	public GameObject pauseUI;

	public void Pause()
	{
		pauseUI.SetActive(true);
		Time.timeScale = 0f;
		IsPaused = true;
	}

	public void Resume()
	{
		pauseUI.SetActive(false);
		Time.timeScale = 1f;
		IsPaused = false;
	}

	public void Settings()
	{
		Debug.Log("Settings");
	}

	public void LoadMenu()
	{
		Debug.Log("Menu");
	}

	/**
	 * Change scene to tutorial
	 */
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	/**
	 * Quit the game
	 */
	public void QuitGame()
	{
		Debug.Log("Quit");
		Application.Quit();
	}

}
