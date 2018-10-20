using UnityEngine;
using System.Collections;

public class LaunchGame : MonoBehaviour {

	void Start() {
	}

	// Use this for initialization
	void OnMouseDown() {
		float dist = Camera.main.transform.position.z - this.transform.position.z;
		if(Mathf.Sqrt (dist * dist) < 70f){
			PhotonNetwork.JoinRandomRoom();
		}
	}

	void OnPhotonRandomJoinFailed()
	{
		RoomOptions ro = new RoomOptions(){ maxPlayers = 10 };
		PhotonNetwork.CreateRoom(null, ro, TypedLobby.Default);
	}

	void OnJoinedRoom()
	{
		PhotonNetwork.isMessageQueueRunning = false;
		Debug.Log ("JOINED ROOM");
		Application.LoadLevel(3);
	}
}
