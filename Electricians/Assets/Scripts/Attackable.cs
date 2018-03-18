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
		Knockback kb = other.GetComponent<Knockback>();
        PlayerMovement pm = GetComponent<PlayerMovement>();

		if (kb != null) {
            if (pm.grounded) {
				transform.position = spawn.transform.position;

            } else {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(kb.force, kb.force / 2));
				StartCoroutine(respawn ());
            }
		}
	}

	IEnumerator respawn() {
		enabled = false;
		yield return new WaitForSeconds (2);
		enabled = true;
	}
}
