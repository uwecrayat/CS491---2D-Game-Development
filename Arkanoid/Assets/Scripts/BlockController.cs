using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class BlockController : MonoBehaviour {
	public int points;
	public Text score;
	public Text hiscore;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		print ("IT HIT");
		score.text = "" + (Int32.Parse (score.text) + points);
		if (Int32.Parse (score.text) > Int32.Parse (hiscore.text)) {
			hiscore.text = score.text;
		}
		Destroy (this.gameObject);
	}
}
