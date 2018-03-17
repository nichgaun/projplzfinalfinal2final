using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	Rigidbody2D rb;

    public float move_speed = 5f;
    public float acceleration = 35f;

	public float jump_height = 1f;
	public float jump_time = 1f;

	public bool grounded = false;
	bool jumping = false;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			jumping = true;
		}
	}

	void FixedUpdate () {

		//movement
		Vector2 DirectionalInput = Vector2.zero;
		if (Input.GetKey(KeyCode.D)) {
			DirectionalInput += new Vector2(1, 0);
		}
		if (Input.GetKey(KeyCode.S)) {
			DirectionalInput += new Vector2(0, 0);
		}
		if (Input.GetKey(KeyCode.A)) {
			DirectionalInput += new Vector2(-1, 0);
		}
		if (Input.GetKey(KeyCode.W)) {
			DirectionalInput += new Vector2 (0, 0);
		}
		float target_speed = DirectionalInput.x * move_speed;
		float diff = target_speed - rb.velocity.x;
		float step = Mathf.Sign (diff) * Mathf.Min (Mathf.Abs (diff), acceleration * Time.deltaTime);

		rb.velocity += new Vector2 (step, 0);

		//gravity and jump
		Vector2 velocity = rb.velocity;

		float jump_speed = 2 * jump_height / jump_time;
		float gravity = -2 * jump_height / (jump_time * jump_time);
		if (!Input.GetKey (KeyCode.Space) && velocity.y > 1e-3) {
			gravity *= 4;
		}
		velocity.y += gravity * Time.deltaTime;

		if (jumping && grounded) {
			velocity.y = jump_speed;
			jumping = false;
		}

		rb.velocity = velocity;

		grounded = false;
	}

	void OnCollisionStay2D (Collision2D collision) {
		if (collision.contacts [0].normal.y > 0.7) {
			grounded = true;
		}
	}
}
