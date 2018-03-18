using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEffect : MonoBehaviour {

	public int waitTime = 1;
	public SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = gameObject.AddComponent<SpriteRenderer> ();
		sr.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void show () {
		if (!sr.enabled) {
			StartCoroutine (showCr ());
		}
	}

	IEnumerator showCr() {
		sr.enabled = true;
		print ("A");
		yield return new WaitForSeconds (waitTime);
		sr.enabled = false;
		print ("B");
	}
}
