using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BlockController : MonoBehaviour {
	public int points;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		GameObject.Find ("Canvas").GetComponent<Scoreboard>().score += points;
		Destroy (this.gameObject);
	}
}
