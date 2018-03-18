using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	Vector2 destination;
	public Vector2 vel;

	// Use this for initialization
	void Start () {
		destination = new Vector2 (5, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = (Vector2)transform.position * 0.97f + (Vector2)destination * 0.03f + vel;
		vel *= 0.95f;
		if (Vector2.Distance (transform.position, destination) < 0.1f) {
			Destroy (gameObject);
		}
	}
}
