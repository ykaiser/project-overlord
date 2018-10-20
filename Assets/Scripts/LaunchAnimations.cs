using UnityEngine;
using System.Collections;

public class LaunchAnimations : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 speed = GetComponent<Rigidbody>().velocity;
		speed.Set(speed.x, 0, speed.z);
		anim.SetFloat("Speed", speed.magnitude);
	}
}
