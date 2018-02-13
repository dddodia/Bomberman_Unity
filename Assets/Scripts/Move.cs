using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Move : MonoBehaviour {
	

	///Player amenities:Player life & Player bomb counts
	public  int life = 100,bombCount = 10;

	///Player moving speed.
    public float speed = 0.06f;

	///Player animation controller
    Animator anim;

	public float powerUp1Timer = 10f;

	public float powerUp3Timer = 10f;


	public bool isPowerUp1 = false;
	public bool isPowerUp2 = false;
	public bool isPowerUp3 = false;


	public GameObject timer1, timer2;


    void Start() 
	{
        anim = GetComponent<Animator>();

		life = 100;
    }


	/// <summary>
	/// Player moving controller on keypad
	/// </summary>
	void FixedUpdate () 
	{


		//Power Up 1 for speedy move..
		if (isPowerUp1) 
		{
			speed = 0.15f;

			timer1.SetActive (true);
			timer1.GetComponent<Image> ().fillAmount = powerUp1Timer / 10;
			powerUp1Timer -= Time.deltaTime;
			if (powerUp1Timer < 0) 
			{
				timer1.SetActive (false);
				timer1.GetComponent<Image> ().fillAmount = 1;
				powerUp1Timer = 10f;
				isPowerUp1 = false;
				speed = 0.06f;
			}
		}
		//Power Up 2 for bomb count..
		if (isPowerUp2) 
		{

			bombCount += 3;
			isPowerUp2 = false;
			//			powerUp2Timer -= Time.deltaTime;
			//			if (powerUp2Timer < 0) 
			//			{
			//				powerUp2Timer = 10f;
			//				isPowerUp2 = false;
			//			}
		}
		//Power Up 3 for Biggger Bomb Explosion..
		if (isPowerUp3) 
		{
			timer2.SetActive (true);
			timer2.GetComponent<Image> ().fillAmount = powerUp3Timer / 10;
			powerUp3Timer -= Time.deltaTime;
			if (powerUp3Timer < 0) 
			{
				timer2.SetActive (false);
				timer2.GetComponent<Image> ().fillAmount = 1;
				powerUp3Timer = 10f;
				isPowerUp3 = false;
			}
		}


        Vector2 dir = Vector2.zero;

		if (transform.name.Contains ("Blue")) 
		{
			if (Input.GetKey (KeyCode.UpArrow)) {
				anim.SetInteger ("Direction", 0);
				dir.y = speed;
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				anim.SetInteger ("Direction", 1);
				dir.x = speed;
			} else if (Input.GetKey (KeyCode.DownArrow)) {
				anim.SetInteger ("Direction", 2);
				dir.y = -speed;
			} else if (Input.GetKey (KeyCode.LeftArrow)) {
				anim.SetInteger ("Direction", 3);
				dir.x = -speed;
			} else {
				// idle
				anim.SetInteger ("Direction", 4);
			}
		} 
		else
		{
			if (Input.GetKey (KeyCode.W)) {
				anim.SetInteger ("Direction", 0);
				dir.y = speed;
			} else if (Input.GetKey (KeyCode.D)) {
				anim.SetInteger ("Direction", 1);
				dir.x = speed;
			} else if (Input.GetKey (KeyCode.S)) {
				anim.SetInteger ("Direction", 2);
				dir.y = -speed;
			} else if (Input.GetKey (KeyCode.A)) {
				anim.SetInteger ("Direction", 3);
				dir.x = -speed;
			} else {
				// idle
				anim.SetInteger ("Direction", 4);
			}
		}


        transform.Translate(dir);

 



    }


	/// <summary>
	/// Get this event calls when player trigger with other objects
	/// </summary>
	void OnTriggerEnter2D(Collider2D collider)	
	{
		

			life -= 10;
			if (life <= 0) 
			{
			Debug.Log ("Game ends with death of "+transform.name);
			GameManager.instance.GameOver ();
				//isDead = true;
			}


	}

	/// <summary>
	/// Will called this function for a player  which is within the range of explosion.
	/// </summary>
	public void BombExplosion( )	
	{
		life = 0;
		GameManager.instance.GameOver ();
	}


}