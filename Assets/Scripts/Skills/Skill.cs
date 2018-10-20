using UnityEngine;
using System.Collections;

public abstract class Skill : MonoBehaviour {

	/* available = is possible to use */
	public bool available = false;
	/* activated = is being used by player */
	public bool activated = false;

	protected GameCharacter character;
	protected TPSController controller;
	public float cooldown;
	float currentCooldown;

	public float duration = 0;
	float durationCooldown;

	protected PhotonView photonView;

	// Use this for initialization
	void Start () {
		character = gameObject.GetComponent<GameCharacter>();
		controller = gameObject.GetComponentInParent<TPSController>();
		photonView = GetComponent<PhotonView>();
		currentCooldown = 0;
		durationCooldown = 0;

		OnInit();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!IsAvailable()) {
			currentCooldown -= Time.deltaTime;

			if(currentCooldown <= 0){
				currentCooldown = 0;
				available = true;
			}

			if(activated) {
				OnActivatedUpdate();

				durationCooldown -= Time.deltaTime;

				if(durationCooldown <= 0){
					durationCooldown = 0;
					activated = false;
					OnEndUse();
				}
			}
		}
	}

	public void Use(){
		available = false;
		activated = true;
		OnUse();
		currentCooldown = cooldown;
		durationCooldown = duration;
	}
	
	public virtual bool IsAvailable() {
		return available;
	}


	public abstract void OnInit();
	public abstract void OnUse();
	public abstract void OnEndUse();
	public abstract void OnActivatedUpdate();

	public void OnOtherSkillUse(Skill skill){
	}

	public void OnOtherSkillEndUse(Skill skill){
	}

	public void OnPlayerSpawn(){
	}

	public void OnPlayerKills(GameObject victim){
	}

	public void OnPlayerKilled(GameObject killer){
	}
}
