using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairWalker : MonoBehaviour {

	ControllerController cc;

	public bool going_up = false, going_down = false;
	public bool recentered = false;

	void Start () {
		cc = GetComponent<ControllerController> ();
	}

	// Update is called once per frame
	void Update () {
		StartCoroutine(unstuff ());

		if (Mathf.Abs (cc.controller.LeftStickY) < 0.7) {
			recentered = true;
		}

		if (Input.GetKey (KeyCode.W) || (cc.controller != null && cc.controller.LeftStickY > 0.7) && recentered) {
			recentered = false;
			going_up = true;
		}
		if (Input.GetKey (KeyCode.S) || (cc.controller != null && cc.controller.LeftStickY < -0.7) && recentered) {
			recentered = false;
			going_down = true;
		}
	}

	IEnumerator unstuff() {
		yield return new WaitForFixedUpdate ();
		going_up = false;
		going_down = false;
	}
}
