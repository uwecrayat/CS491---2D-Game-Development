using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockController : MonoBehaviour {
	public int points;
    public GameObject[] powerups;
    private int numHitsToBreak;
    private int numHits;

	// Use this for initialization
	void Start () {
        Random.Range(0, 6);
        numHits = 0;
        if (this.tag != "block") {
            numHitsToBreak = 2;
        } else {
            numHitsToBreak = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
        numHits++;
        if (numHits >= numHitsToBreak) {
            GameObject.Find("Canvas").GetComponent<Scoreboard>().score += points;
            Destroy(this.gameObject);
        }
	}
}
