using UnityEngine;
using System.Collections;

public class Charge : Skill {

	public float speed;
	public float acceleration;
	float accumulator;
	public ParticleSystem particles;
	
	public override void OnInit() {
	}

	public override void OnUse() {
		accumulator = speed;
		particles.Play ();
	}


	public override void OnActivatedUpdate() {
		character.GetController().SetForcedSpeed(character.GetCharacs().moveSpeed + accumulator);
		//character.GetCharacs().AddMoveSpeed(accumulator);
		accumulator += acceleration;
	}

	public override void OnEndUse() {
		character.GetController().ResetForcedSpeed();
		//character.GetCharacs().AddMoveSpeed(0);
		particles.Stop ();
	}
}