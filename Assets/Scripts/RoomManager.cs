using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoomManager : Photon.MonoBehaviour {

	//public int countdownStart = 60;
	//private float countdownCurrent;

	//public RoomSlot[] slotsRebels;
	public GameObject rebels;
	private int rebelCount = 0;
	//public RoomSlot[] slotsScientists;
	public GameObject scientists;
	private int scientistsCount = 0;

	//public Button launchButton;

	// Use this for initialization
	/*
	 * GERER LA DECONNEXION
	 * */

	void Start() {
		PhotonNetwork.isMessageQueueRunning = true;
		photonView.RPC("OnPlayerJoined", PhotonTargets.All, PhotonNetwork.player.name);
		GameObject.Find ("LaunchButton").SetActive(PhotonNetwork.isMasterClient);
	}

	[RPC]
	void OnPlayerJoined(string playerUsername) {
		if(PhotonNetwork.isMasterClient) {
			int team = GetAvailableTeam();

			photonView.RPC("AddPlayer", PhotonTargets.AllBuffered, playerUsername, team);
		}
	}

	[RPC]
	void AddPlayer(string username, int team) {
		GameObject go = PhotonNetwork.Instantiate("RoomPlayer", Vector3.zero, Quaternion.identity, 0);
		if(team == 0) {
			//slotsRebels[rebelCount++].Setup(username);
			go.transform.SetParent(rebels.transform);
			go.GetComponent<RoomSlot>().Setup(username, PunTeams.Team.red);

			rebelCount++;
		} else {
//			slotsScientists[scientistsCount++].Setup(username);go.transform.parent = rebels;
			go.transform.SetParent(scientists.transform);
			go.GetComponent<RoomSlot>().Setup(username, PunTeams.Team.blue);
			scientistsCount++;
		}
	}

	int GetAvailableTeam(){
		if(rebelCount > scientistsCount) {
			return 1;
		} else if (scientistsCount > rebelCount) {
			return 0;
		} else {
			return Random.Range(0, 2);
		}
	}
	
//	void Start() {
//		countdownCurrent = countdownStart;
//		GameObject go = PhotonNetwork.Instantiate("RoomPlayer", Vector3.zero, Quaternion.identity, 0);
//
//		if(PhotonNetwork.player.isMasterClient)
//			photonView.RPC("AddPlayer", PhotonTargets.AllBufferedViaServer, PhotonNetwork.player.name, 0);
//
//		launchButton.gameObject.SetActive(PhotonNetwork.player.isMasterClient);
//	}

//	void OnPhotonPlayerConnected(PhotonPlayer p) {
//		if(rebelCount <= scientistsCount)
//			photonView.RPC("AddPlayer", PhotonTargets.AllBufferedViaServer, p.name, 0);
//		else
//			photonView.RPC("AddPlayer", PhotonTargets.AllBufferedViaServer, p.name, 1);
//	}

//	[RPC]
//	void AddPlayer(string playerName, int team){
//		//Debug.Log ("CALLED WITH TEAM " + team);
//		if(team == 0 && rebelCount <= scientistsCount) {
//			//Debug.Log ("REBEL");
//			slotsRebels[rebelCount].Setup(playerName);
//			rebelCount++;
//			//Debug.Log (rebelCount);
//		} else {
//			//Debug.Log ("SCIENTIST");
//			slotsScientists[scientistsCount].Setup(playerName);
//			scientistsCount++;
//		}
//	}

//	// Update is called once per frame
//	void Update () {
//		countdownCurrent -= Time.deltaTime;
//		if(countdownCurrent <= 0) {
//			//Select Random Player
//			//StartGame();
//		}
//	
//	}

	public void StartGame() {
		photonView.RPC ("LaunchGame", PhotonTargets.All);
	}

	[RPC]
	public void LaunchGame() {
		if(PhotonNetwork.player.isMasterClient){
			PhotonNetwork.room.open = false;
		}

		PhotonNetwork.LoadLevel(4);
	}
//
//	void OnLevelWasLoaded (int level) {
//		Debug.Log ("Woohoo");
//	}
}
