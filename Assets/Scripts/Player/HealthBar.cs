using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	private GameManager gameManager;
	private GameCharacter gameCharacter;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("_SCRIPTS").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameCharacter == null && gameManager.GetOwnedGameCharacter() != null){
			gameCharacter = gameManager.GetOwnedGameCharacter();
		}
		if(gameCharacter != null){
			float totHealth = gameCharacter.GetCharacs().defHealth + gameCharacter.GetCharacs().bonusHealth;
			this.transform.localScale = new Vector2(gameCharacter.GetCharacs().health / totHealth, 1);
		}
	}
}
