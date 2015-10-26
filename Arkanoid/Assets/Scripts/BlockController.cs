using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class BlockController : MonoBehaviour {
	public int points;
    public GameObject[] powerups;
    private int numHitsToBreak;
    private int numHits;

	// Use this for initialization
	void Start () {
        Random.Range(0, 6);
        numHits = 0;
        if (this.tag != "block") {
            numHitsToBreak = 2;
        } else {
            numHitsToBreak = 1;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll) {
        numHits++;
        print(coll.gameObject.layer);
      if(FindGameObjectsWithLayer(9).Length == 1) {
          if (Random.Range(0, 8) == 0) {
              Instantiate(powerups[Random.Range(0, 6)], transform.position, Quaternion.identity);
          }
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
}
