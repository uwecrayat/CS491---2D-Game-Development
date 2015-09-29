using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public ButtonController[] buttons;
	private List<ButtonController> pattern;
	private List<ButtonController> playerMoves;
	public float timeBetweenButtonDisplay;
	public float speedMult;
	private AudioSource audioSource;
	public AudioClip failure;
	public GUIText text;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		pattern = new List<ButtonController> ();
		playerMoves = new List<ButtonController> ();
		Debug.Log (pattern.ToString());
		StartCoroutine(AddAndDisplayPattern());
	}

	void Update() {

	}

	IEnumerator AddAndDisplayPattern() {
		//disable buttons while displaying pattern
		buttons [0].canClick = false;
		buttons [1].canClick = false;
		buttons [2].canClick = false;
		buttons [3].canClick = false;

		//pick a random button to add to pattern list
		int ri = UnityEngine.Random.Range (0, 3);
		Debug.Log ("button is " + ri);
		pattern.Add (buttons [ri]);

		//display pattern
		yield return new WaitForSeconds (2f);
		for (int i = 0; i < pattern.Count; i++) {
			//play sound
			audioSource.PlayOneShot(pattern[i].clip);
			StartCoroutine(pattern[i].FlashColor());
			yield return new WaitForSeconds(timeBetweenButtonDisplay);
		}
		//increase speed between button displays
		timeBetweenButtonDisplay *= speedMult;
		buttons [0].timeBetweenButtonFlash *= speedMult;
		buttons [1].timeBetweenButtonFlash *= speedMult;
		buttons [2].timeBetweenButtonFlash *= speedMult;
		buttons [3].timeBetweenButtonFlash *= speedMult;

		//enable buttons after displaying pattern
		buttons [0].canClick = true;
		buttons [1].canClick = true;
		buttons [2].canClick = true;
		buttons [3].canClick = true;
	}

	public void AddMovesPlayer(ButtonController button) {
		Debug.Log ("GameController: " + button.name);
		playerMoves.Add (button);
		if (!CheckMove ()) {
			//play game over sound
			audioSource.PlayOneShot (failure);
			Debug.Log ("invalid");
			buttons[0].canClick = false;
			buttons[1].canClick = false;
			buttons[2].canClick = false;
			buttons[3].canClick = false;
			return;
		} else {
			audioSource.PlayOneShot(button.clip);
		}

		if (playerMoves.Count == pattern.Count) {
			playerMoves = new List<ButtonController>();
			StartCoroutine(AddAndDisplayPattern());
		}
	}

	public bool CheckMove() {
	
		return playerMoves [playerMoves.Count-1].name == pattern [playerMoves.Count-1].name;
	}



}
