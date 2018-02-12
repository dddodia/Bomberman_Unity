using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
	
	//Both player controller script refeernce
	public Move playerBlue, playerYellow;

	//This instance to access throughout gameplay.
	public static GameManager instance;





	/// GameManager instance reference 
	void Awake () 
	{
		instance = this;


	}



	// Update is called once per frame
	void Update()	
	{
		
	}
		
}
