using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float timeExisting = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeExisting += Time.deltaTime;
		if(timeExisting >= 2f)
			Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision) {
		//TODO: Check if it's a player, then apply damages !
		DestroyObject(gameObject);
	}
}
