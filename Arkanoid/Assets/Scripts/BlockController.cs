using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class BlockController : MonoBehaviour {
    public int points;
    public GameObject[] powerups;
    private int numHitsToBreak;
    private int numHits;
    private Animator animator;
    public Animation anim;

    // Use this for initialization
    void Start() {
        Random.Range(0, 6);
        numHits = 0;
        if (this.name.Contains("steel")) {
            numHitsToBreak = 2;
            animator = GetComponent<Animator>();
        } else {
            numHitsToBreak = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        numHits++;
        //prevent powerups if multiball
        if (FindGameObjectsWithLayer(9).Length == 1) {
            if (Random.Range(0, 8) == 0) {
                Instantiate(powerups[Random.Range(0, 6)], transform.position, Quaternion.identity);
            }
        }
        if (name.Contains("steel") && numHits < numHitsToBreak) {
            animator.enabled = true;
        }
        if (numHits >= numHitsToBreak) {
            GameObject.Find("Canvas").GetComponent<Scoreboard>().score += points;
            Destroy(this.gameObject);

        }
    }

    GameObject[] FindGameObjectsWithLayer(int layer) {
        GameObject[] goArray = FindObjectsOfType<GameObject>();
        List<GameObject> goList = new List<GameObject>();
        for (int i = 0; i < goArray.Length; i++) {
            if (goArray[i].layer == layer) {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0) {
            return null;
        }
        return goList.ToArray();
    }

    void DisableAnimator() {
        animator.enabled = false;
    }
}
