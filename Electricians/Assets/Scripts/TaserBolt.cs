using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaserBolt : MonoBehaviour {

    public Attacker origin;

    public void OnCollisionEnter2D (Collision2D collision) {
        origin.taserShooting = false;
        Destroy(gameObject);
    }
}
