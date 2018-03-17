using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;

	public float move_speed = 1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector2 DirectionalInput = Vector2.zero;
		if (Input.GetKeyDown(KeyCode.D)) {
			DirectionalInput += new Vector2(1, 0);
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			DirectionalInput += new Vector2(0, 0);
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			DirectionalInput += new Vector2(-1, 0);
		}
		if (Input.GetKeyDown(KeyCode.W)) {
			DirectionalInput += new Vector2 (0, 0);
		}
		rb.AddForce (DirectionalInput * move_speed);

		Vector2 velocity = rb.velocity;
		rb.velocity = velocity;
	}
}
