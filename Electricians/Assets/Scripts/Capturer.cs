using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturer : MonoBehaviour {
    const int TOTAL_OUTLETS = 6;
    GameObject capturable = null;
    GameObject bitcoinMeter;
    List<GameObject> captured = new List<GameObject>();
    public List<GameObject> outletIcons = new List<GameObject>(6);
    public int outlets, bitcoin;
    float timeToCap = 0;
    bool isCaping;
    const float CAPTURE_TIME = 1;
    public Color faction;
	public Sprite capSprite;

    //Initializes the outlets and bitcoins
    private void Start () {
        outlets = 0;
        bitcoin = 0;
    }

    void RenderOutletCount () {
		return;
        for (int i = 0; i < TOTAL_OUTLETS; i++) {
            Renderer renderI = outletIcons[i].GetComponent<Renderer>();
            if (i < outlets) {
                renderI.enabled = true;
            } else {
                renderI.enabled = false;
            }
        }
    }

    //Is called by a capturable dude when it can be captured by this guy
    public void CanCapture (GameObject c, bool b) {
        if (c != null) {
            if (b) {
                capturable = c;
                if (Input.GetKey("e"))
                    AttemptCapture();
            } else {
                capturable = null;
                StopCapture();
            }
        }
    }

    //Debugging stuff, for now
    void Update () {
        RenderOutletCount();
		if (!GetComponent<Attackable> ().dead) {
			if (Input.GetKeyDown ("e"))
				AttemptCapture ();

			if (Input.GetKeyUp ("e"))
				StopCapture ();
			
			if (Input.GetKeyDown ("x"))
				PowerSpike ();

			if (timeToCap > 0) {
				timeToCap -= Time.deltaTime;
			} else if (timeToCap <= 0 && isCaping) {
				Capture ();
			}
		}
    }

    //Called whenever there is a powerspike, makes bitcoin
    void PowerSpike () {
        foreach (GameObject g in captured) {
            if (!IsOutlet(g))
                bitcoin++;
        }
    }

    //Checks to see if a gameobject is an outlet
    bool IsOutlet (GameObject c) {
        return c.GetComponent<Capturable>().GetResource() == Capturable.ResourceType.Outlet;
    }

    //Removes a thing when it is captured by another player
    public void Uncapture (GameObject other) {
        if (IsOutlet(other))
            outlets--;
        captured.Remove(other);
    }

    void StopCapture () {
        timeToCap = 0;
        isCaping = false;
    }

    void AttemptCapture () {
        timeToCap = CAPTURE_TIME;
        isCaping = true;
    }

    //Captures a boy
    void Capture () {
        if (capturable != null) {
            Capturable c = capturable.GetComponent<Capturable>();
            c.GetCaptured(this);

            if (!captured.Contains(capturable)) {
                captured.Add(capturable);
				if (IsOutlet (capturable)) {
					outlets++;
				}
            }
        }
    }
}
