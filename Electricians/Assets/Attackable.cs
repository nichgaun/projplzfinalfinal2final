﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour {
	float invuln;

	void OnEnable() {
		invuln = 0;
	}

	void OnTriggerStay2D(Collider2D other) {
		Knockback kb = other.GetComponent<Knockback>();
		if (kb != null) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(kb.force, -kb.force));
		}
	}

    void Update() {
		if (Input.GetKeyDown("space")) {
			StartCoroutine(fireWeapon());
		}
    }

	IEnumerator fireWeapon() {
		yield return new WaitForSeconds(1);
	}
}