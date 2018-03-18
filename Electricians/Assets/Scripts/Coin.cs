using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	public GameObject destination;
	public Vector2 vel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dst = (Vector2)destination.transform.position;
		transform.position = (Vector2)transform.position * 0.9f + dst * 0.1f + vel;
		vel *= 0.95f;
		if (Vector2.Distance (transform.position, dst) < 0.5f) {
			Destroy (gameObject);
		}
	}
}
