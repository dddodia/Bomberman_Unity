using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	//Both player controller script refeernce
	public Move playerBlue, playerYellow;

	//This instance to access throughout gameplay.
	public static GameManager instance;

	public Text blueLife, yellowLife,yellowBomb,blueBomb;

	public float GameTimer = 300f;
	bool isGameOn = true;
	public GameObject gameTimerObj;

	/// GameManager instance reference 
	void Awake () 
	{
		instance = this;


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


	public void GameOver()
	{
		isGameOn = false;
		Time.timeScale = 0f;

		if (playerYellow.life >0 && playerBlue.life==0) {
			Debug.Log ("player yellow win");
		} else if (playerBlue.life >0 && playerYellow.life == 0) {
			Debug.Log ("player blue win");
		} else {
			Debug.Log ("game is draw");
		}
	}
		
}
