using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEmitter : MonoBehaviour {
	public GameObject coin;
	int timer = 0;

	// Use this for initialization
	void Start () {
		coin.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("t")) {
			emitMany();
		}
		if (timer > 0) {
			GameObject c = Instantiate (coin);
			c.transform.position = (Vector2) transform.position + new Vector2 (Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.5f));
			c.GetComponent<Coin>().vel = new Vector2 (Random.Range (-0.1f, 0.1f), Random.Range (-0.1f, 0.1f)).normalized * 0.05f;
			c.SetActive (true);
			timer -= 1;
		}
	}

	public void emitOne() {
		timer = 1;
	}

	public void emitMany() {
		timer = 60;
	}
}
