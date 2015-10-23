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
        score = 0;
        highscore = 0;
		currentScore.text = "" + score;
		hiscore.text = "" + highscore;
	}
	
	// Update is called once per frame
	void Update () {
        if (!GetComponent<AudioSource>().isPlaying) {
            GameObject.Find("Player").GetComponent<PlayerController>().gameStart = true;
            GameObject.Find("Ball").GetComponent<BallController>().gameStart = true;
        }
		currentScore.text = "" + score;
		if (score > highscore) {
			hiscore.text = "" + score;
		}
	}
}
