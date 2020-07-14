using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour {

    private GameObject ship;

	// Use this for initialization
	void Start () {
        ship = GameObject.Find("Player");
	}

    void follow() {
        transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position.z - 10);
    }
	
	// Update is called once per frame
	void Update () {
        follow();
	}
}
