using UnityEngine;
using System.Collections;

public class PowerBar : MonoBehaviour
{
	public float maxHealth;
	public float health;
	private float power;
	// Use this for initialization
	void Start ()
	{
		power = 0;
//		health = Mathf.Lerp (0, 100, 5);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (1)) {
			power+= 0.05f;
			health = Mathf.Abs (Mathf.Sin (power));
		} else {
			power = 0;
			health = 0;
		}
		transform.localScale = new Vector3 ((health * 100)/maxHealth, 1, 1);
	}
}
