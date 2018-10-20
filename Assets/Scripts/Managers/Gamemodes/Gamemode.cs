using UnityEngine;
using System.Collections;

public abstract class Gamemode : MonoBehaviour {

	public SpawnPoint[] spawnPoints;
	public Objective[] objectives;

	public abstract void OnGameStart();
	public abstract void OnGameEnd();
	public abstract void OnGameUpdate();
	public abstract void OnPlayerDied(GameCharacter killed, DamageSource killerSource);

}

/* OnGameStart() : called when game starts (before countdown)
 * OnGameEnd() : called when game is ending (after time-out or victory)
 * OnGameUpdate(): called every game update
 * OnPlayerDied(GameCharacter killed, GameCharacter killer): called when a player dies
 * 
 * Fields :
 * SpawnPoint[] spawns
 * 
 * */