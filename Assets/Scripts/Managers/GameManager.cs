using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;

public class GameManager : Photon.MonoBehaviour {

	public Gamemode gamemode;
	public RectTransform healthBar;
	public List<GameCharacter> gameCharacters;
	public GameObject pauseMenu;


	private GameCharacter ownedGameCharacter;

	// Use this for initialization
	void Start () {
		gamemode.OnGameStart();
		PhotonPeer.RegisterType(typeof(DamageSource), (byte)'D', SerializeDamageSource, DeserializeDamageSource);
	}
	
	// Update is called once per frame
	void Update () {
		gamemode.OnGameUpdate();
	}

	public void OnPlayerSpawned(GameCharacter character) {
		character.healthBar = healthBar;
		character.GetController().menu = pauseMenu;
	}

	public void AddPlayer(PhotonPlayer other) {
		this.gameCharacters.Add(GetGameCharacterFromPlayer(other));
	}

	public void SetOwnedGameCharacter(GameCharacter character) {
		this.ownedGameCharacter = character;
	}

	public GameCharacter GetOwnedGameCharacter() {
		return ownedGameCharacter;
	}

	public GameCharacter GetGameCharacterFromPlayer(PhotonPlayer player) {
		//Debug.Log(player.ID + " ;" + PhotonView.Find(player.ID * 1000 + 1));
		return PhotonView.Find (player.ID * 1000 + 1).gameObject.GetComponent<GameCharacter>();
	}

	private static byte[] SerializeDamageSource(object customObject) {
		DamageSource damageSource = (DamageSource) customObject;
		
		byte[] bytes = new byte[2 * 4];
		int index = 0;
		if(damageSource.type == DamageSource.DamageSourceType.SUICIDE)
			Protocol.Serialize(0, bytes, ref index);
		else
			Protocol.Serialize(1, bytes, ref index);
		
		Protocol.Serialize(damageSource.damagerID, bytes, ref index);
		return bytes;
	}
	
	private static object DeserializeDamageSource(byte[] bytes)
	{
		int index = 0;
		
		int type = 0;
		int damagerID = -1;
		
		Protocol.Deserialize(out type, bytes, ref index);
		Protocol.Deserialize(out damagerID, bytes, ref index);
		
		if(type == 0) {
			return DamageSource.SourceAsSuicide();
		} else {
			return DamageSource.SourceAsPlayer(damagerID);
		}
	}
}
