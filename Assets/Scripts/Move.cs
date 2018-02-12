using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Move : MonoBehaviour {
	

	///Player amenities:Player life & Player bomb counts
	public  int life = 100,bombCount = 10;

	///Player moving speed.
    public float speed = 0.1f;

	///Player animation controller
    Animator anim;



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
				//isDead = true;
			}


	}

	/// <summary>
	/// Will called this function for a player  which is within the range of explosion.
	/// </summary>
	public void BombExplosion( )	
	{
		life = 0;
	}


}