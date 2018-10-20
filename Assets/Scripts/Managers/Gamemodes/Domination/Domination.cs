using UnityEngine;
using System.Collections;

public class Domination : Gamemode {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnGameStart() {
	}
	public override void OnGameEnd() {
	}
	public override void OnGameUpdate() {
	}
	public override void OnPlayerDied(GameCharacter killed, DamageSource killerSource) {
		if(killerSource == null) {
			
		}
	}
}
