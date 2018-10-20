using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {

	public int characterID;

	public void ChangeCharacter(){
		GameInfos.playerClass = characterID;
		Debug.Log (characterID);
	}
}
