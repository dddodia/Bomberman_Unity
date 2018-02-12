using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	//After time to destroy blast particle
    public float time = 2.0f;

	//Will destroy itslef after given seconds.
    IEnumerator Start() {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
