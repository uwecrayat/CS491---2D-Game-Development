using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoreboard : MonoBehaviour {
	public Text currentScore;
	public Text hiscore;
	public int score;
	private int highscore;
	// Use this for initialization
	void Start () {
		currentScore.text = "" + score;
		hiscore.text = "" + highscore;
	}
	
	// Update is called once per frame
	void Update () {
		currentScore.text = "" + score;
		if (score > highscore) {
			hiscore.text = "" + score;
		}
	}
}
