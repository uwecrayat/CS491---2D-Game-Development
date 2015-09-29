using UnityEngine;
using System;
using System.Collections;

public class ButtonController : MonoBehaviour {
	public Sprite neutralSprite;
	public Sprite pressedSprite;
	public AudioClip clip;
//	private AudioSource audioSource;
	public float timeBetweenButtonFlash;
	public bool canClick = true;
	// Use this for initialization

	public IEnumerator FlashColor() {
//		yield return new WaitForSeconds(2f);
		PressSprite (true);
		yield return new WaitForSeconds(timeBetweenButtonFlash);
		PressSprite (false);
//		GameObject.Find ("/buttonRed").GetComponent<ButtonController> ().canClick = true;
//		GameObject.Find ("/buttonGreen").GetComponent<ButtonController> ().canClick = true;
//		GameObject.Find ("/buttonBlue").GetComponent<ButtonController> ().canClick = true;
//		GameObject.Find ("/buttonYellow").GetComponent<ButtonController> ().canClick = true;
	}

	public void PressSprite(bool pressed) {
		GetComponent<SpriteRenderer> ().sprite = pressed ? pressedSprite : neutralSprite;
	}

	public void OnMouseDown() {
		if (canClick) {
			PressSprite (true);
			Debug.Log ("ButtonController: " + this.name);
			// add button clicked to player moves array in GameController
		}
	}

	public void OnMouseUp() {
		if (canClick) {
			PressSprite (false);
			GameObject.Find ("/Main Camera").GetComponent<GameController> ().AddMovesPlayer (this);

		}
//		GetComponent<SpriteRenderer> ().sprite = neutralSprite;
	}

}
