using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour {

    private float turnSpeed;
    private float multiplier;
	// Use this for initialization
	void Start () {
        turnSpeed = 10f;
        multiplier = 1;
	}

    public void setSpeed(float mult) {
        multiplier = mult;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.back * Time.deltaTime * turnSpeed * multiplier);
	}
}
