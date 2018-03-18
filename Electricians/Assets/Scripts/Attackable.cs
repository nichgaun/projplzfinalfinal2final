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
		deathObj.GetComponent<SpriteRenderer> ().sortingOrder = 2;
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
		if (pm.grounded || kb.myType != Knockback.KillType.Melee) {
			if (kb.myType == Knockback.KillType.Melee) {
				deathSe.sr.sprite = meleeDeathSprite;
			} else if (kb.myType == Knockback.KillType.Gun) {
				deathSe.sr.sprite = gunDeathSprite;
			} else {
				deathSe.sr.sprite = cannonDeathSprite;
			}
			deathSe.transform.position = (Vector2)transform.position + new Vector2(0f, 0.2f);
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
		yield return new WaitForSeconds (3);
		transform.position = spawn.transform.position;
		GetComponent<SpriteRenderer>().enabled = true;
		GetComponent<Attacker> ().meleeWeapon.GetComponent<SpriteRenderer>().enabled = true;
		GetComponent<Collider2D> ().enabled = true;
		dead = false;
	}
}
