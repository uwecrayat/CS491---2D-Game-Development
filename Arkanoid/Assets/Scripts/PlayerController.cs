using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody2D rb2D;
    public float speed;
    public AudioClip paddleHit;
    public AudioClip paddleStick;

    public string state;
    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("State", -1);
    }

    // Update is called once per frame
    void Update() {

        float push = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector3(push * speed, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D coll) {

        string tag = coll.gameObject.tag;
        if (tag != "ball" && tag != "Untagged") {
            Destroy(coll.gameObject);
        }
        switch (tag) {
            case "catch":
                state = "catch";
                break;
            case "expand":
                animator.SetInteger("State", 1);
                state = "expand";
                break;
            case "laser":
                state = "laser";
                break;
            case "slow":
                state = "slow";
                break;
            case "multi":
                state = "multi";
                break;
            
        }
        //revert size if any other powerup
        if (animator.GetInteger("State") == 1 && tag != "expand") {
            animator.SetInteger("State", 2);
        }
        if (state == "catch" && coll.gameObject.tag == "ball") {
            //play stick sound
            coll.gameObject.GetComponent<BallController>().ballInPlay = false;
        } else if (coll.gameObject.tag == "ball") {
            audioSource.PlayOneShot(paddleHit);
        }

    }
}
