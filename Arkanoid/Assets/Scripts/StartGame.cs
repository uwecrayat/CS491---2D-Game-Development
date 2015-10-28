using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {
	public Text highScore;

	// Use this for initialization
	void Start () {
		highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt ("highscore");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel ("Level 1");
		}
	}
}
