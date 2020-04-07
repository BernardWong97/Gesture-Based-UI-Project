using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Main menu controller
 */
public class MainMenu : MonoBehaviour {
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
