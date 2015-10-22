using UnityEngine;
using System.Collections;

public class DestroyThisOnHit : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll) {
        Destroy(this.gameObject);
    }
}
