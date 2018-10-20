using UnityEngine;
using System.Collections;

public class MainMenuButton : MonoBehaviour {
	
	public GameObject target;

	void Start() {
	}

	void OnMouseEnter() {
		float dist = Camera.main.transform.position.z - this.transform.position.z;
		if(Mathf.Sqrt (dist * dist) < 70f)
			GetComponent<MeshRenderer>().material.color = Color.red;
			//mesh.color = Color.red;
	}

	void OnMouseExit() {
		GetComponent<MeshRenderer>().material.color = Color.white;
	}

	void OnMouseDown() {
		float dist = Camera.main.transform.position.z - this.transform.position.z;
		if(Mathf.Sqrt (dist * dist) < 70f && target != null)
			MoveTo (target);
	}

	public void MoveTo(GameObject go) {
		CamControl cc = Camera.main.GetComponent<CamControl>();
		cc.setMount(go);
	}
}
