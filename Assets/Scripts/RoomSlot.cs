using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomSlot : MonoBehaviour {

	public PunTeams.Team team;

	public void Setup(string playerName, PunTeams.Team team){
		Debug.Log ("Setup : " + playerName + " ; " + gameObject.name);
		GetComponentInChildren<Text>().text = playerName;

		if(PhotonNetwork.player.name.Equals (playerName))
		{
			//transform.GetChild(1).gameObject.SetActive(true);
			PhotonNetwork.player.SetTeam(team);
		}
	}
}
