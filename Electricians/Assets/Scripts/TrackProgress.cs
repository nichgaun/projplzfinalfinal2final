using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProgressBar))]
public class TrackProgress : MonoBehaviour {

	ProgressBar pb;

	public Capturer cap;

	// Use this for initialization
	void Start () {
		pb = GetComponent<ProgressBar> ();
	}
	
	// Update is called once per frame
	void Update () {
		pb.set_fill (cap.bitcoin);
	}
}
