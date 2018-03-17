using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturer : MonoBehaviour {
    GameObject capturable = null;
    List<GameObject> captured = new List<GameObject>();
    int outlets, bitcoin;

    //Initializes the outlets and bitcoins
    private void Start()
    {
        outlets = 0;
        bitcoin = 0;
    }

    //Is called by a capturable dude when it can be captured by this guy
    public void CanCapture (GameObject c, bool b) {
        if (c != null) {
            if (b)
                capturable = c;
            else
                capturable = null;
        }
    }

    //Debugging stuff, for now
    void Update () {
        if (Input.GetKeyDown("space"))
            Capture();

        if (Input.GetKeyDown("c"))
            Debug.Log("Bitcoin: " + bitcoin + " Outlets: " + outlets);

        if (Input.GetKeyDown("x"))
            PowerSpike();
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
    public void Uncapture(GameObject other) {
        if (IsOutlet(other))
            outlets--;
        captured.Remove(other);
    }

    //Captures a boy
    void Capture () {
        Capturable c = capturable.GetComponent<Capturable>();
        c.GetCaptured(this);
        captured.Add(capturable);

        if (IsOutlet(capturable))
            outlets++;
    }
}
