using System.Collections;
using System.Collections.Generic;
using TMPro;
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
		Food.isMenu = true;
		pauseUI.SetActive(true);
		Time.timeScale = 0f;
		IsPaused = true;
	}

	public void Resume()
	{
		Food.isMenu = false;
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
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}

	/**
	 * Change scene to tutorial
	 */
	public void PlayGame()
	{
		Food.isMenu = false;
		SceneManager.LoadScene(1);
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
