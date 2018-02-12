using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	/// Function called from ui button to load "1.GamePlay" scene.
	public void LoadLevel()
	{
		SceneManager.LoadSceneAsync (1);
	}


}
