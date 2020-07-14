using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTurn : MonoBehaviour {
    private float multiplier;
    private GameObject ship;
    private Vector2 temp;
    private Touch main;
    private int counter;


	// Use this for initialization
	void Start () {
        ship = GameObject.Find("SpaceShip(Clone)");
        multiplier = 2;
        counter = 0;
	}

    //takes in current pixel location and determines the distance between that and the
    //saved posiiton
    void checkDistance(Vector2 test) {
        float distance = (float)(test.x - temp.x);
       //print(distance);
        if (distance < 0)
        {
            multiplier = (distance / 2);
        }
        else if (distance > 0)
        {
            multiplier = (distance / 2);
        }
        else {
            multiplier = 1f;
        }
        ship.GetComponent<turn>().setSpeed(multiplier);
    }

    public void setShip(GameObject s) {
        ship = s;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            if (counter == 0)
            {
                main = Input.GetTouch(0);
                temp = new Vector2(main.position.x, main.position.y);
                counter++;
            }
            else if (counter == 1)
            {
                main = Input.GetTouch(0);
                checkDistance(new Vector2(main.position.x, main.position.y));
                counter--;
            }
        }
        else {
            counter = 0;
            ship.GetComponent<turn>().setSpeed(1f);
        }
	}
}
