using UnityEngine;
using System.Collections;

public class BombDrop : MonoBehaviour 
{
	//bombPrefab refernce to drop bomb from both players.
    public GameObject bombPrefab;

	//To check whether a player has placed bomb already or not
	private bool isPlacedBomb;



	void Update () 
	{
		//Using Space key to drop bomp for blue bomberman player
		if (Input.GetKeyDown (KeyCode.Space) && transform.name.Contains ("Blue")) 
		{
			if (GameManager.instance.playerBlue.bombCount == 0 || isPlacedBomb)
				return;
			isPlacedBomb = true;
			Vector2 pos = transform.position;
			pos.x = Mathf.Round (pos.x);
			pos.y = Mathf.Round (pos.y);



			Instantiate (bombPrefab, pos, Quaternion.identity);
			GameManager.instance.playerBlue.bombCount--;


			Invoke ("BombBlasted_blue", 3f);
		
		}

		//Using Tab key to drop bomp for blue bomberman player
		if (Input.GetKeyDown (KeyCode.Tab) && transform.name.Contains ("Yellow")) 
		{
			if (GameManager.instance.playerYellow.bombCount == 0 || isPlacedBomb)
				return;
			isPlacedBomb = true;
			Vector2 pos = transform.position;
			pos.x = Mathf.Round(pos.x);
			pos.y = Mathf.Round(pos.y);




			Instantiate (bombPrefab, pos, Quaternion.identity);
			GameManager.instance.playerYellow.bombCount--;

			Invoke ("BombBlasted_yellow", 3f);
		}
	}
	//Will fire this event at bomb blast of blue player
	void BombBlasted_blue()	
	{
		isPlacedBomb = false;;
	
	}
	//Will fire this event at bomb blast of yellow player
	void BombBlasted_yellow()	
	{
		isPlacedBomb = false;
	}
}
