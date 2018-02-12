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

				Destroy (b.gameObject);

		}
    }


}