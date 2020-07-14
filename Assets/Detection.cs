using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using UnityEngine.SceneManagement;

public class Detection : MonoBehaviour {

    private float health;
    public Canvas HealthHolder;
    private GameObject HealthBar;
    GameObject[] HealthBars;

    // Use this for initialization
    void Start () {
        health = PlayerPrefs.GetFloat("ShipHealth", 3f);
        HealthBars = new GameObject[(int)health];

        for (int i = 0; i < HealthHolder.transform.childCount; i++) {
            HealthHolder.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < health; i++) {
            HealthBars[i] = HealthHolder.transform.GetChild(i).gameObject;
            HealthHolder.transform.GetChild(i).gameObject.SetActive(true);

        }
	}

    //detect collisions if magnitude of impact is not high enough
    // the ship will not lose health otherwise health is lost and 
    //direction is reversed.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "normal(Clone)") {
            float speed;
            speed = transform.gameObject.GetComponent<ShipMovement>().getMoveSpeed();
            speed = (speed * -1f) / 2;
            transform.gameObject.GetComponent<ShipMovement>().setMoveSpeed(speed);
            GameObject Camera = GameObject.Find("CameraHolder");
            speed *= 2;
            Camera.GetComponentInChildren<Shake>().Shaker(speed * -1, speed * -1, .1f, .1f);
            if ((speed * -1) >= (transform.gameObject.GetComponent<ShipMovement>().getMaxMoveSpeed() / 2)) {
                health -= 1;
                HealthBars[(int)health].gameObject.SetActive(false);
            }

            if (health <= 0) {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
}
