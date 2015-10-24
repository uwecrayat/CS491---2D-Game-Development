using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {
    public GameObject player;
    public AudioClip blockHit;
    public AudioClip blockMultiSound;
    private AudioSource audioSource;
    private Rigidbody2D rb2D;
    public bool ballInPlay;
    private Vector2 initVel;
    private Vector2 velocity;
    private LineRenderer lr;
    private int count;
    private bool blockMultiHit;
    private float ballOffset;
    public bool gameStart;
    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
        rb2D = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        initVel = new Vector2(1f, 3f);
        count = 1;
        ballOffset = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!ballInPlay) {
            rb2D.velocity = new Vector2(0, 0);
            transform.position = new Vector3(player.transform.position.x - ballOffset, -2.55f, 0);
            lr.SetPosition(0, transform.position);
        }
    }

    void FixedUpdate() {
        velocity = rb2D.velocity;

        if (gameStart && Input.GetKeyDown(KeyCode.Space) && !ballInPlay) {
            ballInPlay = true;
            print("firing " + initVel);
            rb2D.velocity = (initVel);
        }

        // debug path drawing
        //if (ballInPlay) {
        //    count++;
        //    lr.SetVertexCount(count);
        //    lr.SetPosition(count - 1, transform.position);
        //}
    }


    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "block") {
            if (blockMultiHit) {
                blockMultiHit = false;
                audioSource.PlayOneShot(blockMultiSound);
            } else {
                audioSource.PlayOneShot(blockHit);
                blockMultiHit = true;
            }
        }
        ballOffset = player.transform.position.x - coll.contacts[0].point.x;

        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        velocity = Vector2.Reflect(velocity, coll.contacts[0].normal);
        velocity *= 1.02f;
        initVel = velocity;
        rb2D.velocity = velocity;
        StartCoroutine(CollisionFix());
    }

    IEnumerator CollisionFix() {
        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
    }

}
