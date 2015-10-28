using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using System.Collections;

public class Scoreboard : MonoBehaviour {
    public Text currentScore;
    public Text hiscore;
    public Text lifeCount;
    public Text round;
    private int highscore;
    public int score;
    public int lives;
    public string nextLevel;
    public string gameOverScene;
    private int lvlNum;

    void Awake() {
        if (!PlayerPrefs.HasKey("highscore")) {
            PlayerPrefs.SetInt("highscore", 0);
        }
    }

    // Use this for initialization
    void Start() {
        score = 0;
        lives = 3;
        highscore = PlayerPrefs.GetInt("highscore");
        currentScore.text = "" + score;
        hiscore.text = "" + highscore;
        lvlNum = Int32.Parse(Regex.Match(Application.loadedLevelName, @"\d+$").Value);
        round.text = "ROUND " + lvlNum;
    }

    // Update is called once per frame
    void Update() {
        if (!GetComponent<AudioSource>().isPlaying) {
            GameObject.Find("Player").GetComponent<PlayerController>().gameStart = true;
            GameObject.Find("Ball").GetComponent<BallController>().gameStart = true;
            round.enabled = false;
        } else {
            round.enabled = true;
        }
        if (score > highscore) {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        currentScore.text = "" + score;
        hiscore.text = "" + PlayerPrefs.GetInt("highscore");
        lifeCount.text = "LIVES: " + lives;

        WinLoseCondition();
    }

    void WinLoseCondition() {
        //win condition
        if (GameObject.FindGameObjectsWithTag("block").Length == 0) {
            Application.LoadLevel("Level" + (lvlNum + 1));
        }
        //lose condition
        if (lives <= 0) {
            Application.LoadLevel("gameOver");
        }
    }
}
