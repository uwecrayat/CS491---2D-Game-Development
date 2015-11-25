using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float oomph;
	public float jumpHeight;
	private bool isGrounded;
	public Vector2 respawnPoint; //respawn point is (flag.transform.x, flag.transform.y - 0.6f)
	public Transform GroundCheck; // Put the prefab of the ground here
	public LayerMask groundLayer; // Insert the layer here.
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = Physics2D.OverlapCircle (GroundCheck.position, 0.9f, groundLayer);
		print (isGrounded);
		float horizontal = Input.GetAxis ("Horizontal");
		if (isGrounded) {
			rb2d.AddForce (new Vector2 (horizontal * oomph, rb2d.velocity.y));
		} else {
			//more air mobility
			rb2d.AddForce (new Vector2 (horizontal * oomph * 1, rb2d.velocity.y));

		}

		if (isGrounded && Input.GetButtonDown ("Jump")) {
			rb2d.velocity = new Vector2(rb2d.velocity.x, jumpHeight);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.layer != LayerMask.NameToLayer ("Floor")) {
			Respawn();
		}
	}

	void Respawn() {
		rb2d.velocity = Vector2.zero;
		rb2d.angularVelocity = 0f;
		rb2d.transform.rotation  = Quaternion.identity;
		transform.position = respawnPoint;
	}
}
