using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
	public GameObject meleeWeapon;
	public GameObject cannonReticule;
	public GameObject cannonBeam;

	public float active_time = 1f;
	public float cannonActiveTime = 1f;

	void Start() {
		meleeWeapon = Instantiate (meleeWeapon, gameObject.transform, false);
		cannonReticule = Instantiate (cannonReticule);
		cannonBeam = Instantiate (cannonBeam);
		meleeWeapon.SetActive (false);
		cannonReticule.SetActive (false);
		cannonBeam.SetActive (false);
	}

    void Update() {
		if (Input.GetKeyDown("q") && !meleeWeapon.activeInHierarchy) {
			StartCoroutine(fireWeapon ());
		}
		cannonReticule.SetActive(Input.GetKey("e") && !cannonReticule.activeInHierarchy);
		if (Input.GetKeyUp ("e") && !cannonBeam.activeInHierarchy) {
			StartCoroutine (fireCannon ());
		}
    }

	IEnumerator fireWeapon() {
		meleeWeapon.SetActive (true);
		yield return new WaitForSeconds(active_time);
		meleeWeapon.SetActive (false);
	}

	IEnumerator fireCannon() {
		cannonBeam.SetActive (true);
		yield return new WaitForSeconds(cannonActiveTime);
		cannonBeam.SetActive (false);
	}
}
