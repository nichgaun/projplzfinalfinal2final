using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairWalker : MonoBehaviour {

	public bool going_up = false, going_down = false;
	
	// Update is called once per frame
	void Update () {
		going_up = Input.GetKey (KeyCode.W);
		going_down = Input.GetKey (KeyCode.S);
	}
}
