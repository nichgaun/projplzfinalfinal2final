using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour {

	public GameObject up_location;
	public GameObject down_location;

	void OnTriggerStay2D (Collider2D other) {
		StairWalker sw = other.gameObject.GetComponent<StairWalker> ();

		if (up_location != null && sw.going_up) {
			//move to uplocation
			other.transform.position = up_location.transform.position;
		}
		else if (down_location != null && sw.going_down) {
			//move to downlocation
			other.transform.position = down_location.transform.position;
		}
	}
}
