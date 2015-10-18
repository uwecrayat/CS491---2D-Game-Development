using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Animator animator;
    private AudioSource audioSource;
	private Rigidbody2D rb2D;
	public float speed;
    public AudioClip paddleHit;
    public AudioClip paddleStick;

	public int state;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponentInChildren<Animator> ();
		animator.SetInteger ("State", -1);
	}
	
	// Update is called once per frame
	void Update () {
        
		float push = Input.GetAxis ("Horizontal");
		rb2D.velocity = new Vector3 (push * speed, 0, 0);
	if (Input.GetKeyDown(KeyCode.RightShift)) {
			ChangeState("large");
	}

	if (Input.GetKeyDown(KeyCode.LeftShift)) {
			ChangeState("revert");
		}
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ball")
        {
            audioSource.PlayOneShot(paddleHit);
        }

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
