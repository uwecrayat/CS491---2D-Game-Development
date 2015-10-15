using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoreboard : MonoBehaviour {
	public Text score;
	public Text hiscore;
	// Use this for initialization
	void Start () {
		score.text = "0";
		hiscore.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
