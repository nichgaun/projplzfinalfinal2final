using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
	public GameObject weapon;

	public float active_time = 1f;

	void Start() {
		weapon = Instantiate(weapon, gameObject.transform, false);
		weapon.SetActive (false);
	}

    void Update() {
		if (Input.GetKeyDown("q")) {
			StartCoroutine(fireWeapon());
		}
    }

	IEnumerator fireWeapon() {
		weapon.SetActive (true);
		yield return new WaitForSeconds(active_time);
		weapon.SetActive (false);
	}
}
