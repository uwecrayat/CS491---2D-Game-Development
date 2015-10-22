using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody2D rb2D;
    public float speed;
    private float ballSpeedMult;
    public AudioClip paddleHit;
    public AudioClip paddleStick;
    public GameObject ball;
    public string state;
    // Use this for initialization
    void Start() {
        ballSpeedMult = 0.5f;
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
        string prevState = state;
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
                //slow down all balls in play
                GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
                for (int i = 0; i < balls.Length; i++) {
                    balls[i].GetComponent<Rigidbody2D>().velocity *= ballSpeedMult;
                }
                state = "slow";
                break;
            case "multi":
                GameObject currBall = GameObject.FindGameObjectWithTag("ball");
                Instantiate(currBall).GetComponent<Rigidbody2D>().velocity = new Vector2(1,2);
                Instantiate(currBall).GetComponent<Rigidbody2D>().velocity = new Vector2(2, 1);
                state = "multi";
                break;
            
        }
        //revert size if any other powerup
        if (animator.GetInteger("State") == 1 && tag != "expand") {
            animator.SetInteger("State", 2);
        }
        //revert speed if new powerup != slow
        if (prevState == "slow" && state != "slow") {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            for (int i = 0; i < balls.Length; i++) {
                balls[i].GetComponent<Rigidbody2D>().velocity /= ballSpeedMult;
            }
        }
        if (state == "catch" && coll.gameObject.tag == "ball") {
            //play stick sound
            coll.gameObject.GetComponent<BallController>().ballInPlay = false;
        } else if (coll.gameObject.tag == "ball") {
            audioSource.PlayOneShot(paddleHit);
        }

    }
}
