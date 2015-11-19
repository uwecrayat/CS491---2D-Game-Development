using UnityEngine;
using System.Collections;

public class MouseAim : MonoBehaviour
{
	private Vector3 mousePos;
	public bool dir;
	private float angle;
	// Use this for initialization
	void Start ()
	{
		dir = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);


		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);	
		if (dir) {
			angle = Mathf.Atan2 (mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
		} else {
			angle = -Mathf.Atan2 (transform.position.y - mousePos.y, transform.position.x - mousePos.x) * Mathf.Rad2Deg;
		}
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);	

		//			transform.rotation = Quaternion.Inverse (transform.rotation);
	}
}

