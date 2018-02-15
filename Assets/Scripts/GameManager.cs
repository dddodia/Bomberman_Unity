using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	//Both player controller script reference
	public Move playerBlue, playerYellow;

	//This instance to access throughout gameplay.
	public static GameManager instance;

	//Displays text field of players
	public Text blueLife, yellowLife,yellowBomb,blueBomb;

	//Game play timer
	public float GameTimer = 300f;

	//bool to check is game on or paused?
	bool isGameOn = false;
	public GameObject gameTimerObj,gameOver;

	/// GameManager instance reference 
	void Awake () 
	{
		instance = this;
		isGameOn = true;
	}


	// Update is called once per frame
	void Update()	
	{
		blueLife.text = playerBlue.life.ToString ();
		yellowLife.text = playerYellow.life.ToString ();
		blueBomb.text = playerBlue.bombCount.ToString ();
		yellowBomb.text = playerYellow.bombCount.ToString ();
		
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (isGameOn) {
			GameTimer -= Time.deltaTime;
			gameTimerObj.GetComponent<Text> ().text = Mathf.RoundToInt(GameTimer).ToString()+"s";
			if (GameTimer < 0) 
			{
				GameOver ();
			}
		}
	}

	/// <summary>
	/// Game over functionality, displays game result
	/// </summary>
	public void GameOver()
	{
		isGameOn = false;
		Time.timeScale = 0f;
		GetComponent<AudioSource> ().Stop ();
		gameOver.SetActive (true);
		if (playerYellow.life >0 && playerBlue.life==0) 
		{
			Debug.Log ("player yellow win");
			gameOver.transform.GetChild (1).GetComponent<Text> ().text = "Congratulations,Mr.Yellow won!";
		} else if (playerBlue.life >0 && playerYellow.life == 0) {
			gameOver.transform.GetChild (1).GetComponent<Text> ().text = "Congratulations,Mr.Blue won!";
			Debug.Log ("player blue win");
		} else {
			gameOver.transform.GetChild (1).GetComponent<Text> ().text = "Game is draw!";
			Debug.Log ("game is draw");
		}
	}

	/// <summary>
	/// Calls function from UI button to reload game..
	/// </summary>
	public void OnPlayAgain()
	{
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (0);
		Time.timeScale = 1.0f;
	}
		
}
