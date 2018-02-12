using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamFollow : MonoBehaviour {

	/// Smooth controller properties for camera
	public float smoothTime = 0.01f;
	private Vector3 velocity = Vector3.zero;


	
	/// FixedUpdate used for Ortho camera controller to pan in/out between players.
	void FixedUpdate () 
	{	


		Vector3 midPoint = (GameManager.instance.playerBlue.transform.position + GameManager.instance.playerYellow.transform.position) / 2;
		Vector3 desPos = midPoint;
		desPos.z = transform.position.z;

		transform.position = Vector3.SmoothDamp (transform.position,desPos,ref velocity,smoothTime);
		float distance = Vector3.Distance (GameManager.instance.playerBlue.transform.position,GameManager.instance.playerYellow.transform.position);
		float calSize = (distance / 25) * 8+4;
		Camera.main.orthographicSize = calSize;
		 
	
			

	}


}
