using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour {
	public GameObject spawn;
	SpriteEffect deathSe;
	public Sprite meleeDeathSprite, gunDeathSprite, cannonDeathSprite;
	public bool dead;

	void Start() {
		GameObject deathObj = new GameObject ();
		deathSe = deathObj.AddComponent<SpriteEffect> ();
		dead = false;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (!dead) {
			Knockback kb = other.GetComponent<Knockback> ();
			if (kb != null) {
				StartCoroutine (knockback (kb));
			}
		}
	}

	IEnumerator knockback(Knockback kb) {
		yield return new WaitForFixedUpdate ();
		PlayerMovement pm = GetComponent<PlayerMovement>();
		if (pm.grounded) {
			deathSe.transform.position = transform.position;
			deathSe.sr.sprite = meleeDeathSprite;
			deathSe.show ();
			StartCoroutine (respawn());
        } else {
			GetComponent<Rigidbody2D>().AddForce(new Vector2(kb.force, kb.force / 2));
		}
	}

	IEnumerator respawn() {
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Attacker> ().meleeWeapon.GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D> ().enabled = false;
		dead = true;
		yield return new WaitForSeconds (2);
		transform.position = spawn.transform.position;
		GetComponent<SpriteRenderer>().enabled = true;
		GetComponent<Attacker> ().meleeWeapon.GetComponent<SpriteRenderer>().enabled = true;
		GetComponent<Collider2D> ().enabled = true;
		dead = false;
	}
}
