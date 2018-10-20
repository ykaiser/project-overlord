using UnityEngine;
using System.Collections;

public abstract class Objective : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		OnTriggerEnter(collider.GetComponent<GameCharacter>());
	}
	void OnTriggerStay(Collider collider) {
		OnTriggerStay(collider.GetComponent<GameCharacter>());
	}
	void OnTriggerExit(Collider collider) {
		OnTriggerExit(collider.GetComponent<GameCharacter>());
	}

	public abstract void OnTriggerEnter(GameCharacter player);
	public abstract void OnTriggerStay(GameCharacter player);
	public abstract void OnTriggerExit(GameCharacter player);
}
/*
 * */
