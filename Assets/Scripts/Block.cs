using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	//For checking whether block is destroyable or not
    public bool destroyable;


	/// <summary>
	/// Check for argument vector2 position if is there block or null
	/// </summary>
	/// <returns>The <see cref="Block"/>.</returns>
	/// <param name="x">The x coordinate of checking Vector2.</param>
	/// <param name="y">The y coordinate of checking Vector2.</param>
    public static Block getBlockAt(float x, float y) 
	{
        Block[] blocks = FindObjectsOfType<Block>();
        foreach (Block b in blocks) {
            if (b.transform.position.x == x &&
                b.transform.position.y == y)
                return b;
        }
        return null;
    }


	/// <summary>
	/// Destroy block at argument position
	/// </summary>
	/// <param name="x">The x coordinate of given vector2.</param>
	/// <param name="y">The y coordinate of given vector2.</param>
    public static void destroyBlockAt(float x, float y) {
        Block b = getBlockAt(x, y);
		if (b != null && b.destroyable) 
		{
			if (Random.Range (0, 10) > 6 && b.transform.GetComponent<SpriteRenderer> ().color == Color.white) {
				//	b.destroyable = false;
				int randomPowerUp = Random.Range (0, 3);
				switch (randomPowerUp) {
				case 0:
					b.transform.GetComponent<SpriteRenderer> ().color = Color.green;
					break;
				case 1:
					b.transform.GetComponent<SpriteRenderer> ().color = Color.blue;
					break;
				case 2:
					b.transform.GetComponent<SpriteRenderer> ().color = Color.yellow;
					break;

				}
			} else 
			{
				Destroy (b.gameObject);
			}

		}
    }



	void OnCollisionEnter2D(Collision2D col)
	{
		if (transform.name.Contains ("block_destroyable") && transform.GetComponent<SpriteRenderer> ().color != Color.white) {
			if (transform.GetComponent<SpriteRenderer> ().color == Color.green) 
			{
				if(col.transform.GetComponent<Move>()!=null)
				{
					col.transform.GetComponent<Move> ().isPowerUp1 = true;	
				}
				Destroy (transform.gameObject);
			}
			else if (transform.GetComponent<SpriteRenderer> ().color == Color.blue) 
			{
				if(col.transform.GetComponent<Move>()!=null)
				{
					col.transform.GetComponent<Move> ().isPowerUp2 = true;	
				}
				Destroy (transform.gameObject);
			}
			else if (transform.GetComponent<SpriteRenderer> ().color == Color.yellow) 
			{
				if(col.transform.GetComponent<Move>()!=null)
				{
					col.transform.GetComponent<Move> ().isPowerUp3 = true;	
				}
				Destroy (transform.gameObject);
			}

		}

	}


}