using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
	public GameObject meleeWeapon;
	public GameObject cannonReticule;
	public GameObject cannonBeam;

	public float active_time = 1f;
	public float cannonActiveTime = 1f;
	public float cannonAimSpeed = 2f;

	private bool cannonAiming;

	void Start() {
		meleeWeapon = Instantiate (meleeWeapon, gameObject.transform, false);
		cannonReticule = Instantiate (cannonReticule);
		cannonBeam = Instantiate (cannonBeam);
		meleeWeapon.SetActive (false);
		cannonReticule.SetActive (false);
		cannonBeam.SetActive (false);
		cannonAiming = false;
	}

    void Update() {
		if (Input.GetKeyDown("q") && !meleeWeapon.activeInHierarchy) {
			StartCoroutine(fireWeapon ());
		}
		bool nextCannonAiming = Input.GetKey ("e") && !cannonBeam.activeInHierarchy;
		if (cannonAiming) {
			if (!nextCannonAiming) {
				StartCoroutine (fireCannon ());
				cannonReticule.SetActive (false);
			} else {
				if (Input.GetKey ("d")) {
					cannonReticule.transform.position = new Vector2(cannonReticule.transform.position.x + cannonAimSpeed, 0);
				}
				if (Input.GetKey ("a")) {
					cannonReticule.transform.position = new Vector2(cannonReticule.transform.position.x - cannonAimSpeed, 0);
				}
			}
		} else if (nextCannonAiming) {
			cannonReticule.transform.position = new Vector2(gameObject.transform.position.x, 0);
		}
		cannonAiming = nextCannonAiming;
		cannonReticule.SetActive (cannonAiming);
    }

	IEnumerator fireWeapon() {
		meleeWeapon.SetActive (true);
		yield return new WaitForSeconds(active_time);
		meleeWeapon.SetActive (false);
	}

	IEnumerator fireCannon() {
		cannonBeam.transform.position = cannonReticule.transform.position;
		cannonBeam.SetActive (true);
		yield return new WaitForSeconds(cannonActiveTime);
		cannonBeam.SetActive (false);
	}
}
