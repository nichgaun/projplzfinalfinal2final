using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

	Transform fill;

	// Use this for initialization
	void Start () {
		fill = transform.Find ("Fill");
	}

	public void set_fill(float val) {
		if (val > 1)
			val = 1;
		if (val < 0)
			val = 0;

		Vector3 tmp = fill.localScale;
		tmp.x = val;
		fill.localScale = tmp;
	}
}
