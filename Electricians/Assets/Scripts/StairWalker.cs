using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairWalker : MonoBehaviour {

	ControllerController cc;

	public bool going_up = false, going_down = false;

	void Start () {
		cc = GetComponent<ControllerController> ();
	}

	// Update is called once per frame
	void Update () {
		going_up = Input.GetKey (KeyCode.W) || (cc.controller != null && cc.controller.LeftStickY > 0.5);
		going_down = Input.GetKey (KeyCode.S) || (cc.controller != null && cc.controller.LeftStickY > 0.5);
	}
}
