using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour {
	public GameObject spawn;

	float invuln;

	void OnEnable() {
		invuln = 0;
	}

	void OnTriggerEnter2D(Collider2D other) {
		Knockback kb = other.GetComponent<Knockback> ();
		if (kb != null) {
			StartCoroutine (knockback (kb));
		}
	}

	IEnumerator knockback(Knockback kb) {
		yield return new WaitForFixedUpdate ();
		PlayerMovement pm = GetComponent<PlayerMovement>();
		if (pm.grounded) {
			transform.position = spawn.transform.position;
            StartCoroutine(respawn());
        } else {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(kb.force, kb.force / 2));
		}
	}

	IEnumerator respawn() {
		enabled = false;
		yield return new WaitForSeconds (2);
		enabled = true;
	}
}
