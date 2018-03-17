using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ControllerController : MonoBehaviour {

	public int controller_num = -1;
	public InputDevice controller;

	// Use this for initialization
	void Start () {
		if (controller_num >= 0 && InputManager.Devices.Count >= controller_num + 1) {
			controller = InputManager.Devices [controller_num];
		}
	}
}
