using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capturer : MonoBehaviour {
    GameObject capturable = null;

    public void CanCapture (GameObject c, bool b) {
        if (c != null) {
            if (b)
                capturable = c;
            else
                capturable = null;
        }
    }

    void Update() {
        if (Input.GetKeyDown("space"))
            Capture();
        if (Input.GetKeyUp("space"))
            Uncapture();
    }

    void Uncapture() {
        capturable.GetComponent<Capturable>().GetUncaptured(this);
    }

    void Capture () {
        capturable.GetComponent<Capturable>().GetCaptured(this);
    }
}
