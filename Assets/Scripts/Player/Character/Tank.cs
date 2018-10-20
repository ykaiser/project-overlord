using UnityEngine;
using System.Collections;

public class Tank : GameCharacter {

	public AudioClip autoAttackSound;

	/* La colliderbox pour les punchs */
	public GameObject autoAttackCollisionBox;

	/* Utilisation du sort 'charge' ? */
	public bool charging;

	/* La durée d'un stun d'un enemi en cas de contact pdt la charge */
	public float stunDuration = 3f;
	/* De meme mais, force "d'éjection" */
	public float ejectForce = 10f;

	public override void SetupCharacteristics() {
		characs.defAutoAttackSpeed = 1f;
		characs.defMoveSpeed = moveSpeed;
		characs.defBaseDamages = damages;
		characs.defHealth = health;
	}

	[RPC]
	public override void AutoAttack() {
		AudioSource.PlayClipAtPoint(autoAttackSound, transform.position);
	}

	public override void OnDamagesTaken(float damages) {

	}
}