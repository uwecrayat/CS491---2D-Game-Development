using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Animator animator;
	private Rigidbody2D rb2D;
	private float push;

	public int state;
	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponentInChildren<Animator> ();
		animator.SetInteger ("State", -1);
//		transform.position = new Vector3 (-1.55f, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		push = Input.GetAxis ("Horizontal");
	if (Input.GetKeyDown(KeyCode.Space)) {
			ChangeState("large");
	}

	if (Input.GetKeyDown(KeyCode.LeftShift)) {
			ChangeState("revert");
		}
	}

	void FixedUpdate() {
		print (push * 10);
		rb2D.AddForce(new Vector2(push * 10, 0));
	}

	void ChangeState(string state) {
		switch (state) {
		case "large":
			//play animation to enlarge paddle
			animator.SetInteger("State", 1);
			break;
		case "revert": 
			//change sprite to laser and give laser ability
			animator.SetInteger("State", 2);
			break;
		}
	}
}
