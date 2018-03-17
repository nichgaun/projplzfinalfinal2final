using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturable : MonoBehaviour {

    Capturer owner;

    void OnTriggerEnter2D (Collider2D other) {
        if (other.GetComponent<Capturer> () != null)
            other.GetComponent<Capturer>().CanCapture(gameObject, true);
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.GetComponent<Capturer>() != null)
            other.GetComponent<Capturer>().CanCapture(gameObject, false);
    }

    public void GetCaptured (Capturer other) {
        owner = other;
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void GetUncaptured(Capturer other) {
        owner = null;
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
