using UnityEngine;
using System;
using System.Text.RegularExpressions;
using System.Collections;

public class LevelBreak : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D coll) {
		int lvlNum = System.Int32.Parse (Regex.Match (Application.loadedLevelName, @"\d+$").Value);
		Application.LoadLevel ("Level " + (lvlNum + 1));
	}
}
