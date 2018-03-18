using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserBolt : MonoBehaviour {

    public Attacker origin;

    public void OnTriggerEnter2D (Collider2D collision) {
        Attacker a = collision.gameObject.GetComponent<Attacker>();
        if (a == null || a != origin) {
            //origin.taserShooting = false;
            Destroy(gameObject);
        }
    }
}
