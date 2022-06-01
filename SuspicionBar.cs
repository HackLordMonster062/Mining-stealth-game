using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionBar : MonoBehaviour {
    public static SuspicionBar bar;

    public int state;
    public float count;
	
    void Start() {
        bar = this;
    }

    void Update() {
        state = (int)count / 10;
    }
}
