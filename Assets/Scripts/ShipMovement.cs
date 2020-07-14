using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    private float AngleinRads;
    private float AdjustedAngleInDegrees;

    private float turnSpeed;
    private float maxMoveSpeed;
    private float moveSpeed;
    private float accelSpeed;
    private Touch touch;

	// Use this for initialization
	void Start () {
        turnSpeed = PlayerPrefs.GetFloat("ShipTurnSpeed", 2f);
        maxMoveSpeed = PlayerPrefs.GetFloat("ShipMoveSpeed", 10f);
        accelSpeed = PlayerPrefs.GetFloat("ShipAccelSpeed", 3f);
        moveSpeed = 0;
	}

    //Takes in position of screen touches in pixel coordinates and then determines the Angle
    //in terms of 360 degrees
    void calculateAngle(Vector2 position) {
        float width = Screen.width / 2;
        float height = Screen.height / 2;

        float positionHeight = (position.y - height);
        float positionWidth = (position.x - width);

        float Angle = Mathf.Atan(positionHeight / positionWidth);
        AngleinRads = Angle;
        Angle = Angle * Mathf.Rad2Deg;

        if (positionWidth <= 0 && positionHeight > 0)
        {
            Angle += 180;
        }
        else if (positionWidth < 0 && positionHeight <= 0)
        {
            Angle += 180;
        }
        else if (positionWidth >= 0 && positionHeight < 0)
        {
           Angle += 360;
        }
        else
        {
            print("angle out of range");
        }

        AdjustedAngleInDegrees = Angle;
    }

    //Takes the Angle calculated in the previous method and interpolates it to create a smooth turn over time
    void turnShip() {
        Quaternion target = Quaternion.Euler(0, 0, AdjustedAngleInDegrees - 90);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * turnSpeed);
    }

    //accelerates ship to max move speed over time based on accel multiplier
    void moveShip() {
        if (moveSpeed < maxMoveSpeed) {
            moveSpeed += Time.deltaTime * accelSpeed;
        }
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }

    //Whenever ship isnt accellerating decceleration is called and deccelerates the ship in half the accel speed
    void decceleration() {
        if (moveSpeed > 0f)
        {
            moveSpeed -= Time.deltaTime * accelSpeed * 2;
        }
        else if (moveSpeed < 0) {
            moveSpeed += Time.deltaTime * accelSpeed * 2;
        }
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }

    //allows for outside access to speed
    public float getMoveSpeed() {
        return moveSpeed;
    }

    //allows outside scripts to change move speed
    public void setMoveSpeed(float speed) {
        moveSpeed = speed;
    }

    //allows for outside access to max speed
    public float getMaxMoveSpeed() {
        return maxMoveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.position.x < 500 && touch.position.y < 200)
            {
                decceleration();
            }
            else {
                moveShip();
                calculateAngle(touch.position);
                turnShip();
            }
        }
        else {
            decceleration();
        }
	}
}
