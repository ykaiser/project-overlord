using UnityEngine;
using System.Collections;

public class Soldier : GameCharacter {


	public GameObject bulletPrefab;
	public float bulletSpeed;

	public override void SetupCharacteristics() {
		characs.defAutoAttackSpeed = 1f;
		characs.defMoveSpeed = moveSpeed;
		characs.defBaseDamages = damages;
		characs.defHealth = health;
	}

	[RPC]
	public override void AutoAttack() {
//		GameObject bullet = networkManager.Instanciate(bulletPrefab, "Bullet", transform.position + transform.forward + transform.up * 1.5f, Quaternion.identity, 0);
//		bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
	}

	public override void OnDamagesTaken(float damages) {

	}
}