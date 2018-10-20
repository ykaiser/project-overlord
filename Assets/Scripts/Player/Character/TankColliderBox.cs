using UnityEngine;
using System.Collections;

public class TankColliderBox : MonoBehaviour {

	private Tank tank;



	// Use this for initialization
	void Start () {
		tank = GetComponentInParent<Tank>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider collider) {
		GameCharacter colliderChar = collider.GetComponent<GameCharacter>();
		if(tank.autoAttacking) {
			if(collider.gameObject.tag == "Player" && !colliderChar.GetComponent<PhotonView>().isMine) {
				Debug.Log (collider);
				collider.GetComponent<PhotonView>().RPC("Damage", 
				               PhotonTargets.All, 
				               tank.GetCharacs().baseDamages, DamageSource.SourceAsPlayer(PhotonNetwork.player.ID));
			}
		} else if (tank.charging) {
			if(collider.gameObject.tag == "Player" && !colliderChar.GetComponent<PhotonView>().isMine) {
				GameCharacter gc = collider.gameObject.GetComponentInChildren<GameCharacter>();
				gc.StunAndEject(tank.stunDuration, tank.ejectForce, tank.transform.position);
			}
		}
	}
}
