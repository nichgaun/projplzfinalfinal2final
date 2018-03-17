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
		bool canCannon = true || GetComponent<Capturer>().outlets >= 2;
		bool nextCannonAiming = canCannon && Input.GetKey ("r") && !cannonBeam.activeInHierarchy;
		if (cannonAiming) {
			if (!nextCannonAiming) {
				if (canCannon) {
					StartCoroutine (fireCannon ());
				}
			} else {
				if (Input.GetKey ("d")) {
					cannonReticule.transform.position = new Vector2(cannonReticule.transform.position.x + cannonAimSpeed, cannonReticule.transform.localScale.y / 2);
				}
				if (Input.GetKey ("a")) {
					cannonReticule.transform.position = new Vector2(cannonReticule.transform.position.x - cannonAimSpeed, cannonReticule.transform.localScale.y / 2);
				}
			}
		} else if (nextCannonAiming) {
			cannonReticule.transform.position = new Vector2(gameObject.transform.position.x, cannonReticule.transform.localScale.y / 2);
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
		cannonBeam.transform.position = new Vector2(cannonReticule.transform.position.x, cannonBeam.transform.localScale.y / 2);
		cannonBeam.SetActive (true);
		Physics2D.IgnoreCollision (cannonBeam.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		yield return new WaitForSeconds(cannonActiveTime);
		cannonBeam.SetActive (false);
	}
}
