using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int state;
	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown(KeyCode.Space)) {

		}
	}

	void ChangeState(string state) {
		switch (state) {
		case "large":
			//play animation to enlarge paddle
			break;
		case "laser": 
			//change sprite to laser and give laser ability
			break;
		}
	}
}
