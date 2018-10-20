using UnityEngine;
using System.Collections;

public class FootSound : MonoBehaviour {

	public AudioClip sound;
	public float delay;
	public float count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;
	}

	void OnTriggerEnter(Collider coll) {
		if(count >= delay)
		{
			AudioSource.PlayClipAtPoint(sound, transform.position);
			count = 0;
		}
	}
}
