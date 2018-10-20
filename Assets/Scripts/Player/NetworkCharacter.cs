using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
	private Vector3 correctPlayerPos;
	private Quaternion correctPlayerRot;
	private Animator anim;
	public bool autoattacking;
	public float maxSpeedBeforeTP = 10f;

	void Start(){
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if(photonView == null)
			return;
		if (!photonView.isMine)
		{

			Vector3 direction = transform.position - this.correctPlayerPos;
			float speed = (direction.magnitude >= 0.1) ? direction.magnitude : 0;

			if(speed < maxSpeedBeforeTP) {
				transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, 0.1f);
				transform.rotation = Quaternion.Lerp(transform.rotation, this.correctPlayerRot, 0.1f);
			} else {
				transform.position = this.correctPlayerPos;
				transform.rotation = this.correctPlayerRot;
			}

			if(anim != null) {
				anim.SetFloat("Speed", speed);
			}
		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else
		{
			this.correctPlayerPos = (Vector3)stream.ReceiveNext();
			this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
		}
	}
}
