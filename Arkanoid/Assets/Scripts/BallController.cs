using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
	private Rigidbody2D rb2D;
	private bool ballInPlay;
	private Vector2 initVel;
	public GameObject player;
	private Vector2 velocity;
	private LineRenderer lr;
	private int count;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		lr = GetComponent<LineRenderer> ();
		initVel = new Vector2 (3f, 6f);
		count = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		velocity = rb2D.velocity;

		if (Input.GetKeyDown (KeyCode.Space) && !ballInPlay) {
			ballInPlay = true;
			print("firing " + initVel);
			rb2D.velocity = (initVel);
		}
		if (!ballInPlay) {
			rb2D.velocity = new Vector2(0,0);
			transform.position = new Vector3 (player.transform.position.x, transform.position.y, 0);
			lr.SetPosition(0, transform.position);
		}
		// debug path drawing
//		if (ballInPlay) {
//			count++;
//			lr.SetVertexCount (count);
//			lr.SetPosition (count - 1, transform.position);
//		}
	}
	

	void OnCollisionEnter2D(Collision2D coll) {
		string hitName = coll.gameObject.GetComponentInChildren<BoxCollider2D> ().name;
		print (hitName);
		velocity = Vector2.Reflect (velocity, coll.contacts [0].normal);
		
		print ("contacts[0] " + coll.contacts [0].point);
		print ("paddle position " + player.transform.position);
		print (velocity);
		initVel = velocity;
		rb2D.velocity = velocity;
//		if (hitName == "paddle") {
//			ballInPlay = false;
//			initVel.y = Mathf.Abs(initVel.y);
//			print ("paddle hit " + velocity);
//		}	
	}
}
