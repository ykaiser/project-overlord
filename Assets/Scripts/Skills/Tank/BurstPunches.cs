using UnityEngine;
using System.Collections;

public class BurstPunches : Skill {

	float speed;
	public ParticleSystem[] particles;

	public override void OnInit() {
	}

	public override void OnUse() {
		speed = character.GetCharacs().autoAttackSpeed;
		character.GetCharacs().AddAutoAttackSpeed(speed * 0.5f);
		foreach(ParticleSystem ps in particles)
		{
			ps.Play();
		}
	}

	public override void OnActivatedUpdate() {

	}

	public override void OnEndUse() {
		character.GetCharacs().AddAutoAttackSpeed(0);
		foreach(ParticleSystem ps in particles)
		{
			ps.Stop();
		}
	}
}