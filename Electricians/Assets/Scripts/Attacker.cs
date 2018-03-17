using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
	public GameObject weapon;

	void OnEnable() {
		weapon = Instantiate(weapon, gameObject.transform, false);
		weapon.GetComponent<BoxCollider2D>().enabled = false;
	}

    void Update() {
		if (Input.GetKeyDown("q")) {
			StartCoroutine(fireWeapon());
		}
    }

	IEnumerator fireWeapon() {
		weapon.GetComponent<BoxCollider2D>().enabled = true;
		yield return new WaitForSeconds(1);
		weapon.GetComponent<BoxCollider2D>().enabled = false;
	}
}
