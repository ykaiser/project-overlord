using UnityEngine;
using System.Collections;

public class TPSController : MonoBehaviour {

	/* Tout est dans le nom */
	public float moveSpeed = 3.0f;
	public float jumpForce = 3.0f;
	
	/* Pas utilisé */
	//public float maxSlopeAngle = 80f;

	/* L'animation à jouer */
	Animator anim;
	/* La classe du personnage */
	GameCharacter character;

	/* La vitesse forcée (en cas de furie ou charge par exemple */
	protected float forcedSpeed = 0f;
	/* Le controleur de jeu */
	CharacterController cont;

	/* Vecteur de mouvement */
	private Vector3 movement = Vector3.zero;

	private bool paused;
	public GameObject menu;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		character = GetComponentInChildren<GameCharacter>();
		cont = GetComponent<CharacterController>();
		paused = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!character.stunned && !paused) {
			moveSpeed = character.GetCharacs().moveSpeed;
			if(forcedSpeed == 0f) {
				float h = Input.GetAxis("Horizontal") + Input.GetAxis("JRight");
				float v = Input.GetAxis("Vertical") + Input.GetAxis("JForward");
				Vector3 direction = new Vector3(h, 0, v);

				if(anim != null)
					anim.SetFloat("Speed", direction.magnitude);

				direction = transform.TransformDirection(direction);
				direction *= moveSpeed;
				movement.x = direction.x;
				movement.z = direction.z;
			} else {
				Vector3 forwardWithSpeed = transform.forward * forcedSpeed;
				movement.x = forwardWithSpeed.x;
				movement.z = forwardWithSpeed.z;

				if(anim != null)
					anim.SetFloat("Speed", forwardWithSpeed.magnitude);
			}
			//direction.y = rigidbody.velocity.y / moveSpeed / forcedSpeed;

			//transform.position += direction * Time.deltaTime * moveSpeed;

			//rigidbody.AddForce(direction * moveSpeed * forcedSpeed * 5f, ForceMode.Force);
			//rigidbody.velocity = direction * moveSpeed * forcedSpeed;

			//if(canJump && Input.GetButtonDown("Jump")) {
				/*direction.y = direction.y + *///rigidbody.AddForce(Vector3.up * jumpForce);
				//rigidbody.velocity += Vector3.up * jumpForce;
			//	canJump = false;
			//}
			if(cont.collisionFlags == CollisionFlags.Above)
			{
				movement.y = 0;    
			}

			if(cont.isGrounded){
				//rigidbody.AddForce(gameObject.transform.up * -10000000f, ForceMode.Impulse);
				if(Input.GetButtonDown("Jump"))
					movement.y = jumpForce;
			} else {
				movement.y += Physics.gravity.y * Time.deltaTime;
			}

			cont.Move(movement * Time.deltaTime);

			//Debug.Log ("TRANSFORM.POSITION = " + transform.position);
		}
		
		if(Input.GetKeyDown(KeyCode.Escape)){
			paused = !paused;
			menu.SetActive (paused);
		}
	}

	public void SetForcedSpeed(float sp) {
		this.forcedSpeed = sp;
	}

	public void ResetForcedSpeed() {
		this.forcedSpeed = 0f;
	}

	private float Snap(float f) {
		if(f > 0) {
			return 1f;
		} else if (f < 0) {
			return -1f;
		} else {
			return 0;
		}
	}

//	void OnCollisionEnter(Collision collision) {
//		canJump = false;
//		Debug.Log(collision + "" + Time.frameCount);
//		foreach(ContactPoint cp in collision.contacts) {
//			if(Vector3.Dot(cp.normal, Vector3.up) >= Mathf.Sin (maxSlopeAngle * Mathf.Deg2Rad)) {
//				canJump = true;
//			}
//		}
//		//Debug.Log ("COLL");
//	}
//
//	void OnCollisionLeave(Collision collision) {
//		canJump = false;
//	}
}