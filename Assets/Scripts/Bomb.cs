using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    // Time after which the bomb explodes
    float time = 3.0f;

	// Worm game objects, needed to destroy the worms after being hit 
	public GameObject worm1;
	public GameObject worm2;
	public GameObject worm3;
	//  Both player refernce
	public GameObject bombarman1;
	public GameObject bombarman2;

    // Explosion Prefab
    public GameObject explosion;
	public bool isPowerOn = false;

	//Bomb explosion range positions in Vector2
	private Vector2 roundedPos;
	private Vector2 rangeUp;
	private Vector2 rangeRight;
	private Vector2 rangeDown;
	private Vector2 rangeLeft; 
	private Vector2 player1PosRounded;
	private Vector2 player2PosRounded;

	void Start ()
	{
		
		Vector2 pos = transform.position;
		pos.x = Mathf.Round (pos.x);
		pos.y = Mathf.Round (pos.y);
		roundedPos = new Vector2 (pos.x, pos.y);
		 

		if (!isPowerOn) {
			rangeUp = new Vector2 (pos.x, pos.y + 1); // Explosion covers 1 unit up
			rangeRight = new Vector2 (pos.x + 1, pos.y); // Explosion covers 1 unit right
			rangeDown = new Vector2 (pos.x, pos.y - 1); // Explosion covers 1 unit down
			rangeLeft = new Vector2 (pos.x - 1, pos.y); // Explosion covers 1 unit left
		} else {
			rangeUp = new Vector2 (pos.x, pos.y + 2); // Explosion covers 2 unit up
			rangeRight = new Vector2 (pos.x + 2, pos.y); // Explosion covers 2 unit right
			rangeDown = new Vector2 (pos.x, pos.y - 2); // Explosion covers 2 unit down
			rangeLeft = new Vector2 (pos.x - 2, pos.y); // Explosion covers 2 unit left
		}

		




		// Call the Explode function after a few(given) seconds
        Invoke("Explode", time);
    }
    
    void Explode()
	{
        // Remove Bomb from game
        Destroy(gameObject);

        // Spawn Explosion
        Instantiate(explosion,
                    transform.position,
                    Quaternion.identity);
		// Destroy stuff
		Vector2 pos = transform.position;


		if (isPowerOn) 
		{
			Block.destroyBlockAt(pos.x,   pos.y);   // same
			Block.destroyBlockAt(pos.x,   pos.y+1); // top
			Block.destroyBlockAt(pos.x,   pos.y+2); // top1
			Block.destroyBlockAt(pos.x+1, pos.y);   // right
			Block.destroyBlockAt(pos.x+2, pos.y);   // right1
			Block.destroyBlockAt(pos.x,   pos.y-1); // bottom
			Block.destroyBlockAt(pos.x,   pos.y-2); // bottom1
			Block.destroyBlockAt(pos.x-1, pos.y);   // left
			Block.destroyBlockAt(pos.x-2, pos.y);   // left1

		} else {
			Block.destroyBlockAt(pos.x,   pos.y);   // same
			Block.destroyBlockAt(pos.x,   pos.y+1); // top
			Block.destroyBlockAt(pos.x+1, pos.y);   // right
			Block.destroyBlockAt(pos.x,   pos.y-1); // bottom
			Block.destroyBlockAt(pos.x-1, pos.y);   // left
		}
			

     
     

		//Call to destory other stuff within range of explosion
		destroyBomber ();
    }


	// Checks if the bomb explosion ranges to Bomberman position. Also checks if bomb hits worm. 
	void destroyBomber()
	{
		if (bombarman1 == null)
			bombarman1 = GameManager.instance.playerYellow.gameObject;
		if (bombarman2 == null)
			bombarman2 = GameManager.instance.playerBlue.gameObject;


		float tempX = Mathf.Round(bombarman1.transform.position.x);
		float tempY = Mathf.Round(bombarman1.transform.position.y);
		player1PosRounded = new Vector2 (tempX, tempY);


		tempX = Mathf.Round(bombarman2.transform.position.x);
		tempY = Mathf.Round(bombarman2.transform.position.y);
		player2PosRounded = new Vector2 (tempX, tempY);



		//If bomb explode within range of player 1...
		if (player1PosRounded == roundedPos ||player1PosRounded == rangeUp
			|| player1PosRounded == rangeLeft || player1PosRounded == rangeRight
			|| player1PosRounded== rangeDown) 
		{
			Debug.Log ("Yellow bomberman explosion");
			bombarman1.GetComponent<Move> ().BombExplosion ();

		}

		//If bomb explode within range of player 2......
		if (player2PosRounded == roundedPos ||player2PosRounded == rangeUp
			|| player2PosRounded == rangeLeft || player2PosRounded == rangeRight
			|| player2PosRounded== rangeDown) 
		{
			Debug.Log ("Blue bomberman explosion");
			bombarman2.GetComponent<Move> ().BombExplosion ();

		}


		if (GetPosition.roundedWormPos1 == roundedPos || GetPosition.roundedWormPos1 == rangeUp 
			|| GetPosition.roundedWormPos1 == rangeLeft || GetPosition.roundedWormPos1 == rangeRight
			|| GetPosition.roundedWormPos1 == rangeDown)
		{

			if(worm1 == null){
				worm1 = GameObject.Find ("Worm1");
				Destroy (worm1.gameObject);}
		}

		if (GetPosition.roundedWormPos2 == roundedPos || GetPosition.roundedWormPos2 == rangeUp 
			|| GetPosition.roundedWormPos2 == rangeLeft || GetPosition.roundedWormPos2 == rangeRight
			|| GetPosition.roundedWormPos2 == rangeDown) {
			if (worm2 == null){
				worm2 = GameObject.Find ("Worm2");
				Destroy (worm2.gameObject);}
		}

		if (GetPosition.roundedWormPos3 == roundedPos || GetPosition.roundedWormPos3 == rangeUp 
			|| GetPosition.roundedWormPos3 == rangeLeft || GetPosition.roundedWormPos3 == rangeRight
			|| GetPosition.roundedWormPos3 == rangeDown)
		{
			if (worm3 == null){
				worm3 = GameObject.Find ("Worm3");
				Destroy (worm3.gameObject);}
		}

		
	}
}
