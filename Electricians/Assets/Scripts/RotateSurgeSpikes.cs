using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSurgeSpikes : MonoBehaviour {

	SpriteRenderer sr;

	public List<Sprite> rods = new List<Sprite>();
	public float time_between_transitions = 5f;
	public bool is_surging = false;

	float curr_time_remaining;
	int num_transitions;
	int curr_index = 0;

	// Use this for initialization
	void Start () {
		curr_time_remaining = time_between_transitions;
		num_transitions = rods.Count;
		sr = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		curr_time_remaining -= Time.deltaTime;

		if (curr_time_remaining <= 0) {
			sr.sprite = rods [(curr_index + 1) % num_transitions];
			curr_index = (curr_index + 1) % num_transitions;

			is_surging = curr_index == num_transitions - 1;

			curr_time_remaining = time_between_transitions;
		}
	}
}
