using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotion : MonoBehaviour {

    private float deathTime;
    private float speed;


    /**public class Data
    {
        string name;
        string team;
        string ability;

        Data(string n, string t, string ab)
        {
            name = n;
            team = t;
            ability = ab;
        }

        Data(string ab)
        {
            ability = ab;
        }

        Data(Data copy)
        {
            name = copy.name;
            team = copy.team;
            ability = copy.ability;
        }

        public Data()
        {
            name = PlayerPrefs.GetString("PlayerName", "Anon");
            team = "None";
        }

        ~Data()
        {

        }

        public void copy(string n, string t, string ab) {
            name = n;
            team = t;
            ability = ab;
        }
   }
    **/

    // Use this for initialization
    void Start () {
        deathTime = 2f;
        speed = 40f;
        //Data Holder = new Data();
        
	}

    void moveForward() {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    void death() {
        if (deathTime > 0)
        {
            deathTime -= Time.deltaTime;
        }
        else if (deathTime <= 0) {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player") {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        moveForward();
        death();
	}
}
