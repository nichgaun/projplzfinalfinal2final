using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour {
	float invuln;

	void OnEnable() {
		invuln = 0;
	}

	void OnTriggerStay2D(Collider2D other) {
		Knockback kb = other.GetComponent<Knockback>();
        PlayerMovement pm = GetComponent<PlayerMovement>();

		if (kb != null) {
            if (pm.grounded) {
                Debug.Log("ded");
            } else {
                Debug.Log("zapped");
                GetComponent<Rigidbody2D>().AddForce(new Vector2(kb.force, kb.force / 2));
            }
		}
	}
}
