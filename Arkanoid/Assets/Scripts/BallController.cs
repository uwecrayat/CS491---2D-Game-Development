using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	private Rigidbody2D rb2D;
	private bool ballInPlay;
	private Vector2 initVel;
	public GameObject player;
	private Vector2 velocity;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		initVel = new Vector2 (3f, 6f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && !ballInPlay) {
			ballInPlay = true;
			rb2D.velocity = (initVel);
		}
		if (!ballInPlay) {
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, 0);
		}
	}

	void FixedUpdate() {
		velocity = rb2D.velocity;
	}

	void OnCollisionEnter2D(Collision2D coll) {
//		print (coll.gameObject.GetComponentInChildren<BoxCollider2D>().name);
		print (coll.contacts [0].normal);
		print ("vel before: " + rb2D.velocity);
		velocity = Vector2.Reflect(velocity, coll.contacts[0].normal);
		rb2D.velocity = velocity;
		print ("vel after: " + rb2D.velocity);
	}
}
