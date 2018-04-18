using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturable : MonoBehaviour {

    Capturer owner;
	public GameObject coin;

    public enum ResourceType {Computer, Outlet};
    public ResourceType myType;

    public ResourceType GetResource () {
        return myType;
    }

    //Debugging so that I can uncapture things without other players
    private void Update () {
		if (Input.GetKeyDown (KeyCode.V)) {
			if (owner != null)
				owner.Uncapture (gameObject);
			GetUncaptured ();
		}
		if (myType == ResourceType.Computer) {
			if (owner != null) {
				float rate;
				if (Object.FindObjectOfType<RotateSurgeSpikes>().is_surging)
					rate = 0.01f;
				else
					rate = 0.05f;
				float prevBitcoin = owner.bitcoin;
				owner.bitcoin += Time.deltaTime * rate;
				if (prevBitcoin % 0.01 > owner.bitcoin % 0.01) {
					GameObject c = Instantiate (coin);
					c.transform.position = (Vector2) transform.position + new Vector2 (Random.Range (-0.5f, 0.5f), Random.Range (-0.5f, 0.5f));
					Coin cn = c.GetComponent<Coin> ();
					cn.vel = new Vector2 (Random.Range (-0.1f, 0.1f), Random.Range (-0.1f, 0.1f)).normalized * 0.05f;
					cn.destination = owner.gameObject;
					c.SetActive (true);
				}
			}
		}

    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.GetComponent<Capturer> () != null)
            other.GetComponent<Capturer>().CanCapture(gameObject, true);
    }

    void OnTriggerExit2D (Collider2D other) {
        if (other.GetComponent<Capturer>() != null)
            other.GetComponent<Capturer>().CanCapture(gameObject, false);
    }

    //Gets captured by a player
    public void GetCaptured (Capturer other) {
        if (owner != null && other != owner)
            owner.Uncapture(gameObject);

        owner = other;
        //Debug.Log(c);
		if (myType == ResourceType.Outlet) {
			GetComponent<SpriteRenderer> ().sprite = owner.capSprite;
		} else {
			GetComponent<SpriteRenderer> ().sprite = owner.compSprite;
		}
		//GetComponent<SpriteRenderer>().enabled = true;
    }

    //Only for debugging
    public void GetUncaptured () {
        owner = null;
		//GetComponent<SpriteRenderer> ().enabled = false;
    }
}
