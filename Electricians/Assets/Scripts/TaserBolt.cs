using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserBolt : MonoBehaviour {

    public Attacker origin;

    public void OnTriggerEnter2D (Collider2D collision) {
        Attacker a = collision.gameObject.GetComponent<Attacker>();
		Debug.Log (collision.gameObject.name);
        if (a == null || a != origin) {
            Destroy(gameObject);
        }
    }
}
