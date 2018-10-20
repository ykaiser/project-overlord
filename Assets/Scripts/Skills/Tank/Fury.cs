using UnityEngine;
using System.Collections;

public class Fury : Skill {

	public ParticleSystem RFury;
	public ParticleSystem BFury;

	public override void OnInit() {
	}
	
	public override void OnUse() {
		character.GetCharacs().AddResistance(5);
		character.GetCharacs().AddBaseDamages(10);
		character.GetCharacs().AddAutoAttackSpeed(1);
		RFury.Play ();
		BFury.Play ();
	}
	
	public override void OnActivatedUpdate() {
	}
	
	public override void OnEndUse() {
		character.GetCharacs().AddResistance(0);
		character.GetCharacs().AddBaseDamages(0);
		character.GetCharacs().AddAutoAttackSpeed(0);
		RFury.Stop ();
		BFury.Stop ();
	}

	public override bool IsAvailable() {
		return character.GetCharacs().fury >= 100 && available;
	}
}
