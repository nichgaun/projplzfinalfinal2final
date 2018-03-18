using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class Attacker : MonoBehaviour {
	public GameObject meleeWeapon;
	public GameObject cannonReticule;
	public GameObject cannonBeam;
    public GameObject taser;

	public float active_time = 1f;
	public float cannonActiveTime = 1f;
	public float cannonAimSpeed = 2f;
    public float taserCoolDown = 2f;
    public float taserSpeed = 10f;

	private bool cannonAiming;
    public bool taserShooting;

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

		if (GetComponent<ControllerController> ().controller != null && GetComponent<ControllerController>().controller.RightTrigger.IsPressed) {
            fireTaser();
        }

		if (Input.GetKeyDown("q") && !meleeWeapon.activeInHierarchy) {
			StartCoroutine(fireWeapon ());
		}
		bool canCannon = GetComponent<Capturer>().outlets >= 2;
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
		Physics2D.IgnoreCollision (meleeWeapon.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		meleeWeapon.SetActive (true);
		yield return new WaitForSeconds(active_time);
		meleeWeapon.SetActive (false);
	}

    public void fireTaser () {
        if (!taserShooting) {
            taserShooting = true;
            Vector2 direction_raw = GetComponent<ControllerController>().controller.RightStick;
            Vector3 direction = new Vector3(direction_raw.x, direction_raw.y, 0);
            Debug.Log(transform.position);
            GameObject tb = Instantiate(taser, transform.position, Quaternion.identity);
            Physics2D.IgnoreCollision(tb.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            tb.GetComponent<Rigidbody2D>().velocity = direction * taserSpeed;
            tb.GetComponent<TaserBolt>().origin = this;
            StartCoroutine(taserCool());
        }
    }

    IEnumerator taserCool () {
        yield return new WaitForSeconds(taserCoolDown);
        taserShooting = false;
    }

	IEnumerator fireCannon() {
		cannonBeam.transform.position = new Vector2(cannonReticule.transform.position.x, cannonBeam.transform.localScale.y / 2);
		cannonBeam.SetActive (true);
		Physics2D.IgnoreCollision (cannonBeam.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		yield return new WaitForSeconds(cannonActiveTime);
		cannonBeam.SetActive (false);
	}
}
