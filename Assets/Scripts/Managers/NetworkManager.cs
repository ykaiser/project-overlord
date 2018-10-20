using UnityEngine;
using System.Collections;

public class NetworkManager : Photon.MonoBehaviour {

	/* Camera de stand-by, avant de spawn le joueur si il y'a de la latence... */
	public GameObject standByCamera;
	/* Camera du jeu, placée derrière le joueur pendant la partie */
	public GameObject mainCamera;
	/* Prefab du joueur */
	public GameObject playerPrefab;
	/* Est-ce qu'on joue en ligne ? */
	public bool offlineMode;
	/* */
	GameManager gameManager;

	void Start () {
		gameManager = GetComponent<GameManager>();

		SpawnMyPlayer();
	}

	void OnGUI() {
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnPhotonPlayerConnected(PhotonPlayer other) {
		gameManager.AddPlayer(other);
	}

	//TODO: Let the game manager do this ! But for now it's fine
	void SpawnMyPlayer() {
		string spawnName = "";

		if(PhotonNetwork.player.GetTeam() == PunTeams.Team.red){
			spawnName = "SPAWN_REBELS";
		} else {
			spawnName = "SPAWN_SCIENTISTS";
		}

		GameObject go = Instanciate(playerPrefab, "Player" + GameInfos.GetPlayerClassName() + GameInfos.GetPlayerTeamName(), GameObject.Find (spawnName).transform.position/*new Vector3(115, 20, 77)*/, Quaternion.identity, 0);
		//TEMP

		if(offlineMode){
			go.GetComponent<PhotonView>().enabled = false;
		}

		go.SetActive(true);
		SwapCameras();

		go.GetComponent<TPSController>().enabled = true;
		go.GetComponent<Animator>().enabled = true;
		((TPSCameraController)mainCamera.GetComponent("TPSCameraController")).player = go.transform;
		((TPSCameraController)mainCamera.GetComponent("TPSCameraController")).Start();

		gameManager.SetOwnedGameCharacter(go.GetComponent<GameCharacter>());
		gameManager.OnPlayerSpawned(go.GetComponent<GameCharacter>());
		if(!offlineMode){
			gameManager.AddPlayer(PhotonNetwork.player);
		}
	}

	/* Changer de caméra, on passe à la caméra de jeu */
	void SwapCameras() {
		standByCamera.SetActive(false);
		mainCamera.SetActive(true);
	}

	/* Instanciation dynamique via le réseau */
	public GameObject Instanciate(GameObject go, string name, Vector3 position, Quaternion rotation, int group) {
		if(offlineMode) {
			return (GameObject) GameObject.Instantiate(go, position, rotation);
		} else {
			return PhotonNetwork.Instantiate(name, position, rotation, group);
		}
	}

}
