using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class GameCharacter : MonoBehaviour {

	/* Delai d'auto attaque */
	private float autoAttackDelay;
	/* Est-il entrain d'auto-attack ? */
	public bool autoAttacking;

	/* Les caractéristiques */
	protected Characteristics characs;

	/* Les compétences */
	public Skill[] skills = new Skill[4];

	/* */
	protected GameManager gameManager;
	/* */
	protected NetworkManager networkManager;
	/* Le script de controle du joueur */
	protected TPSController controller;
	/* Le manager des animations */
	protected Animator animator;
	/* */
	protected PhotonView photonView;
	/* */
	protected NetworkCharacter netChar;
	/* */
	public RectTransform healthBar;

	/* Gestion du stun */
	public float currentStunDelay;
	public bool stunned;

	/* Base characs */
	public float moveSpeed = 5f;
	public float damages = 10f;
	public float health = 20f;
	

	/* Le joueur peut-il auto-attaquer ? */
	bool canAutoAttack = true;

	/* Les deaths/kills */
	protected int kills = 0;
	protected int deaths = 0;

	void Awake () {
		characs = (Characteristics) GetComponent<Characteristics>();
		controller = (TPSController) GetComponentInParent<TPSController>();
		animator = (Animator) GetComponentInParent<Animator>();
		photonView = (PhotonView) GetComponentInParent<PhotonView>();
		netChar = (NetworkCharacter) GetComponentInParent<NetworkCharacter>();
		SetupCharacteristics();
		networkManager = GameObject.Find("_SCRIPTS").GetComponent<NetworkManager>();
		gameManager = GameObject.Find("_SCRIPTS").GetComponent<GameManager>();
		autoAttackDelay = characs.autoAttackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if(!photonView.isMine)
			return;

		currentStunDelay -= Time.deltaTime;
		
		if(currentStunDelay <= 0) {
			currentStunDelay = 0;
			stunned = false;
		}

		autoAttacking = false;
		autoAttackDelay-= Time.deltaTime;

		if(autoAttackDelay <= 0 && (Input.GetAxis("Attack") == -1f || Input.GetButton("Fire")) && canAutoAttack) {
			AutoAttack();

			autoAttackDelay = 1f / characs.autoAttackSpeed;
			autoAttacking = true;
			photonView.RPC("DefaultAutoAttack", PhotonTargets.All);
		}

		for(int i = 0; i < 4; i++) {
			if((Input.GetButton("Skill" + (i + 1)) || Input.GetAxis("Skill" + (i + 1)) == 1f) && skills[i].IsAvailable()){
				photonView.RPC("UseSkill", PhotonTargets.All, i);
			}
		}
	}

	[RPC]
	public void UseSkill(int i) {
		skills[i].Use();
	}

	[RPC]
	public void DefaultAutoAttack() {
		animator.SetTrigger("AutoAttacking");
		photonView.RPC ("AutoAttack", PhotonTargets.All);
	}

	/* Infliger des dommages au joueur
	 * d = quantité 
	 */
	[RPC]
	public void Damage(float d, DamageSource source = null){
		Debug.Log (GetComponent<PhotonView>().owner + " took damages");
		this.characs.health -= d;

		if(this.characs.health <= 0){
			this.characs.health = 0;
		}

		if(this.characs.health == 0) {
			//TODO: Die scripts
			Die(source);
		}
		OnDamagesTaken(d);
	}

	public void Die(DamageSource source){
		gameManager.gamemode.OnPlayerDied(this, source);
	}

	/* Stun le joueur
	 * duration = durée
	 */
	public void Stun(float duration) {
		this.currentStunDelay = duration;
		this.stunned = true;
	}

	/* Ejecte le joueur 
	 * force = la puissance
	 * origin = origine de l'ejection
	 */
	public void Eject(float force, Vector3 origin) {
		Vector3 distance = this.controller.gameObject.transform.position - origin;
		this.controller.gameObject.GetComponent<Rigidbody>().AddForce(distance.normalized * force);
	}

	/* Effectue les deux actions précédentes */
	public void StunAndEject(float stunDuration, float ejectForce, Vector3 ejectorPosition) {
		Stun (stunDuration);
		Eject (ejectForce, ejectorPosition);
	}

	public void SetCanAutoAttack(bool b){
		canAutoAttack = b;
	}

	public Characteristics GetCharacs() {
		return characs;
	}

	public TPSController GetController() {
		return controller;
	}
	
	public abstract void SetupCharacteristics();
	public abstract void AutoAttack();
	public abstract void OnDamagesTaken(float damages);

}
