using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator animator;
    private AudioSource audioSource;
    private Rigidbody2D rb2D;
    private float ballSpeedMult;
    private float nextFire;
    public float fireRate;
    public AudioClip paddleHit;
    public AudioClip paddleStick;
    public AudioClip paddleLaser;
    public float speed;
    public GameObject laser;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public Sprite leftDefault;
    public Sprite rightDefault;
    public Sprite leftLaser;
    public Sprite rightLaser;
    public string state;
    public bool gameStart;

    // Use this for initialization
    void Start() {
        nextFire = 0f;
        ballSpeedMult = 0.75f;
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        animator.SetInteger("State", -1);
    }

    // Update is called once per frame
    void Update() {
        if (gameStart) {
            float push = Input.GetAxis("Horizontal");
            rb2D.velocity = new Vector3(push * speed, 0, 0);
        }
        if (state != "expand") {
            GameObject.Find("paddle_expand").GetComponent<BoxCollider2D>().enabled = false;
        } else {
            GameObject.Find("paddle_expand").GetComponent<BoxCollider2D>().enabled = true;
        }
        if (state == "laser" && Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            audioSource.PlayOneShot(paddleLaser);
            GameObject tmp = Instantiate(laser, new Vector3(transform.position.x - 0.17f, -2.7f, 1), Quaternion.identity) as GameObject;
            tmp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
            tmp = Instantiate(laser, new Vector3(transform.position.x + 0.17f, -2.7f, 1), Quaternion.identity) as GameObject;
            tmp.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        string prevState = state;
        string tag = coll.gameObject.tag;
        if (tag != "ball" && tag != "Untagged") {
            Destroy(coll.gameObject);
        }
        switch (tag) {
            case "break":
                GameObject.Find("exit").GetComponent<Animator>().enabled = true;
                //exit sprite enabled and wall collision disabled via animation component
                break;
            case "catch":
                state = "catch";
                break;
            case "expand":
                animator.SetInteger("State", 1);
                state = "expand";
                break;
            case "laser":
                leftPaddle.GetComponent<SpriteRenderer>().sprite = leftLaser;
                rightPaddle.GetComponent<SpriteRenderer>().sprite = rightLaser;
                state = "laser";
                print("laser");
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
                GameObject newBall = Instantiate(currBall) as GameObject;
                //makes sure all generated balls are named "Ball" because I have a lot of scripts hardcoded to look for "Ball" like an idiot
                newBall.name = "Ball";
                newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 2);
                newBall = Instantiate(currBall) as GameObject;
                newBall.name = "Ball";
                newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 1);
                state = "multi";
                break;
            case "life":
                GameObject.Find("Canvas").GetComponent<Scoreboard>().lives++;
                break;
        }
        //revert size if any other powerup
        if (animator.GetInteger("State") == 1 && coll.gameObject.layer == 8 && tag != "expand") {
            animator.SetInteger("State", 2);
        }
        //revert speed if new powerup != slow
        if (prevState == "slow" && state != "slow") {
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            for (int i = 0; i < balls.Length; i++) {
                balls[i].GetComponent<Rigidbody2D>().velocity /= ballSpeedMult;
            }
        }
        //revert paddle side sprites if not laser
        if (state != "laser") {
            leftPaddle.GetComponent<SpriteRenderer>().sprite = leftDefault;
            rightPaddle.GetComponent<SpriteRenderer>().sprite = rightDefault;
        }
        if (state == "catch" && coll.gameObject.tag == "ball") {
            //play stick sound
            audioSource.PlayOneShot(paddleStick);
            coll.gameObject.GetComponent<BallController>().ballInPlay = false;
        } else if (coll.gameObject.tag == "ball") {
            audioSource.PlayOneShot(paddleHit);
        }

    }
}
