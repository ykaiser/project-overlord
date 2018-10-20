using UnityEngine;
using System.Collections;

public class TankRes : Skill {
	
	public override void OnInit() {
	}

	public override void OnUse() {
		character.GetCharacs().AddResistance(10);
	}
	
	public override void OnActivatedUpdate() {
	}

	public override void OnEndUse() {
		character.GetCharacs().AddResistance(0);
	}
}