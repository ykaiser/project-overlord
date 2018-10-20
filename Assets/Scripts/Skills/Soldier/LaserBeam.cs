using UnityEngine;
using System.Collections;

public class LaserBeam : Skill {

	public GameObject laserBeam;
	GameObject currentLaserBeam;

	public override void OnInit() {
		//laserBeam.SetActive(false);
	}

	public override void OnUse() {
		character.SetCanAutoAttack(false);
		currentLaserBeam = (GameObject) Instantiate(laserBeam);
		currentLaserBeam.SetActive(true);
		//Debug.Log (character);
	}
	
	public override void OnActivatedUpdate() {
		currentLaserBeam.transform.position = gameObject.transform.position + Vector3.up * 2f;
		currentLaserBeam.transform.forward = Camera.main.transform.forward;
		currentLaserBeam.transform.RotateAround(currentLaserBeam.transform.position, currentLaserBeam.transform.right, 90);
		RaycastHit hit;
		if(Physics.Raycast(gameObject.transform.position, Camera.main.transform.forward, out hit)){
			//Debug.DrawLine(gameObject.transform.position, hit.transform.position);
			currentLaserBeam.transform.localScale = new Vector3(0.2f, Vector3.Distance(gameObject.transform.position, hit.transform.position), 0.2f);
		} else {
			currentLaserBeam.transform.localScale = new Vector3(0.2f, 20f, 0.2f);
		}
	}

	public override void OnEndUse() {
		character.SetCanAutoAttack(true);
		Destroy(currentLaserBeam);
	}
}
