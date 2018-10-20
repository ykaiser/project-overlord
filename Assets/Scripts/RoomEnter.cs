using UnityEngine;
using System.Collections;

public class RoomEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PhotonNetwork.Instantiate("RoomPlayer", Vector3.zero, Quaternion.identity, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
