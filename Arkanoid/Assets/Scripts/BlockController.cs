using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlockController : MonoBehaviour {
	public int points;
    public GameObject[] powerups;


	// Use this for initialization
	void Start () {
        Random.Range(0, 6);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject.Find ("Canvas").GetComponent<Scoreboard>().score += points;
		Destroy (this.gameObject);
	}
}
