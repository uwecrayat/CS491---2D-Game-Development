using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb2D;
	private MouseAim mouseAim;
	private bool isGrounded;
	// Use this for initialization
	void Start (){
		rb2D = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update (){
		float push = Input.GetAxis ("Horizontal");
		if (push != 0) {
			rb2D.velocity = new Vector2 (push * 10, rb2D.velocity.y);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			rb2D.velocity = new Vector2(rb2D.velocity.x, 10);
		}
//		rb2D.AddForce (new Vector2(push * 10, rb2D.velocity.y));
	}
}
