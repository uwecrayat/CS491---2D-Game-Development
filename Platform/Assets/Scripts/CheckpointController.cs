using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
	public Sprite passed;
	void OnTriggerEnter2D(Collider2D coll) {
		GetComponent<SpriteRenderer> ().sprite = passed;
		GetComponent<BoxCollider2D> ().enabled = false;
		coll.gameObject.GetComponent<PlayerController> ().respawnPoint = new Vector2(transform.position.x, transform.position.y - 0.6f);
	}
}
