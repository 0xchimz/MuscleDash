using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{

	public static GameController instance;

	public int score;
	public Text scoreText;

	void Awake ()
	{
		instance = this;
	}

	void Start ()
	{
		
	}

	public void AddScore (int amount)
	{
		Debug.Log ("score: " + score.ToString ());

		score += amount;
		scoreText.text = "Score: " + score.ToString ();
	}
}
