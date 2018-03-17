using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturable : MonoBehaviour {

    Capturer owner;

    public enum ResourceType {Computer, Outlet};
    public ResourceType myType;

    public ResourceType GetResource () {
        return myType;
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.GetComponent<Capturer> () != null)
            other.GetComponent<Capturer>().CanCapture(gameObject, true);
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.GetComponent<Capturer>() != null)
            other.GetComponent<Capturer>().CanCapture(gameObject, false);
    }

    public void GetCaptured (Capturer other) {
        if (owner != null && other != owner)
            owner.Uncapture(gameObject);

        owner = other;
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void GetUncaptured(Capturer other) {
        owner = null;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
