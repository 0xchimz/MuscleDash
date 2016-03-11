using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

	public static GameController instance;

	public int score;
	public Text scoreText;

	bool gameOver;
	public bool paused;

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
	}

	public void AddScore (int amount)
	{
//		Debug.Log ("score: " + score.ToString ());

		score += amount;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void GameOver ()
	{
		gameOver = true;
	}

	public bool IsGameOver ()
	{
		return gameOver;
	}

	public void Restart()
	{
		SceneManager.LoadScene ("Level 01");
	}
	public void OnApplicationPause(bool pauseStatus) {
		paused = pauseStatus;
	}
}
