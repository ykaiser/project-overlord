using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToMainMenu : MonoBehaviour {

	public InputField field;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GoToMainMenu(){
		PhotonNetwork.player.name = field.text;
		PhotonNetwork.ConnectUsingSettings("0.1");
	}

	void OnJoinedLobby() {
		Debug.Log ("JOINED LOBBY");
		PhotonNetwork.LoadLevel(2);
	}
}
