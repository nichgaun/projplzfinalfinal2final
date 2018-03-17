using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturer : MonoBehaviour {
    GameObject capturable = null;
    List<GameObject> captured = new List<GameObject>();
    int outlets, bitcoin;

    private void Start()
    {
        outlets = 0;
        bitcoin = 0;
    }

    public void CanCapture (GameObject c, bool b) {
        if (c != null) {
            if (b)
                capturable = c;
            else
                capturable = null;
        }
    }

    void Update () {
        if (Input.GetKeyDown("space"))
            Capture();

        if (Input.GetKeyDown("c"))
            Debug.Log("Bitcoin: " + bitcoin + " Outlets: " + outlets);
        //if (Input.GetKeyUp("space"))
        //    Uncapture();
    }

    bool IsOutlet (GameObject c) {
        return c.GetComponent<Capturable>().GetResource() == Capturable.ResourceType.Outlet;
    }

    public void Uncapture(GameObject other) {
        if (IsOutlet(other))
            outlets--;
        captured.Remove(other);
    }

    void Capture () {
        Capturable c = capturable.GetComponent<Capturable>();
        c.GetCaptured(this);
        captured.Add(capturable);

        if (IsOutlet(capturable))
            outlets++;
    }
}
