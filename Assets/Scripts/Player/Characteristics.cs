using UnityEngine;
using System.Collections;

public class Characteristics : MonoBehaviour {

	/* Default */
	public float defHealth;
	public float defBaseDamages;
	public float defMoveSpeed;
	public float defAutoAttackSpeed;
	public int defResistance;
	public int defFury;
	public int defEnergy;

	/* Bonus */
	public float bonusHealth;
	public float bonusBaseDamages;
	public float bonusMoveSpeed;
	public float bonusAutoAttackSpeed;
	public int bonusResistance;
	public int bonusFury;
	public int bonusEnergy;

	/* Total */
	public float health;
	public float baseDamages;
	public float moveSpeed;
	public float autoAttackSpeed;
	public int resistance;
	public int fury;
	public int energy;

	// Use this for initialization
	void Start () {
		health = 100f;
		baseDamages = 1;
		moveSpeed = 1f;
		autoAttackSpeed = 1f;
		resistance = 0;
		fury = 0;
		energy = 0;
		health = defHealth + bonusHealth;
	}
	
	// Update is called once per frame
	void Update () {
		baseDamages = defBaseDamages + bonusBaseDamages;
		moveSpeed = defMoveSpeed + bonusMoveSpeed;
		autoAttackSpeed = defAutoAttackSpeed + bonusAutoAttackSpeed;
		resistance = defResistance + bonusResistance;
		fury = defFury + bonusFury;
		energy = defEnergy + bonusEnergy;
	}

	public void AddHealth(int health){
		this.bonusHealth += health;
	}

	public void AddBaseDamages(int baseDamages){
		this.bonusBaseDamages += baseDamages;
	}

	public void AddMoveSpeed(float moveSpeed){
		this.bonusMoveSpeed = moveSpeed;
	}

	public void AddAutoAttackSpeed(float autoAttackSpeed){
		this.bonusAutoAttackSpeed = autoAttackSpeed;
	}

	public void AddResistance(int resistance){
		this.bonusResistance = resistance;
	}

	public void AddFury(int fury){
		this.bonusFury = fury;
	}

	public void AddEnergy(int energy){
		this.bonusEnergy = energy;
	}
}
