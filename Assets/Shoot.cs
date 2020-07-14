using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shoot : MonoBehaviour {

    private string ability1;
    private string ability2;
    private string ability3;
    private GameObject ab1;
    private GameObject ab2;
    private GameObject ab3;
    public GameObject ship;


    /**public class Data
    {
        string name;
        string team;
        string ability;

        public Data(string n, string t, string ab)
        {
            name = n;
            team = t;
            ability = ab;
        }

        public Data(Data copy)
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

        public void setAbility(string ab) {
            ability = ab;
        }

        public string getName() {
            return name;
        }

        public string getTeam() {
            return team;
        }

        public string getAbility() {
            return ability;
        }
    }
**/
    void Start()
    {
        print("yeet");
        //ship = GameObject.Find("Player");
        ability1 = PlayerPrefs.GetString("ability1", "normal");
        ability2 = PlayerPrefs.GetString("ability2", "normal");
        ability3 = PlayerPrefs.GetString("ability3", "normal");
        ab1 = (GameObject)Resources.Load("Prefabs/Missles/" + ability1);
        ab2 = (GameObject)Resources.Load("Prefabs/Missles/" + ability2);
        ab3 = (GameObject)Resources.Load("Prefabs/Missles/" + ability3);

    }

    public void UseAB1()
    {
        //Data yeet = new Data();
        //yeet.setAbility(ability1);
        CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .1f);
        GameObject newAttack = Instantiate(ab1, ship.transform.position, ship.transform.rotation);
        //newAttack.GetComponent<ProjectileMotion>().Holder.copy(yeet.getName(), yeet.getTeam(), yeet.getAbility());
    }
    public void UseAB2()
    {
        //Data yeet = new Data();
        //yeet.setAbility(ability2);
        CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .1f);
        GameObject newAttack = Instantiate(ab2, ship.transform.position, ship.transform.rotation);
        //newAttack.GetComponent<ProjectileMotion>().Holder.copy(yeet.getName(), yeet.getTeam(), yeet.getAbility());
    }
    public void UseAB3()
    {
       // Data yeet = new Data();
        //yeet.setAbility(ability3);
        CameraShaker.Instance.ShakeOnce(2f, 2f, .1f, .1f);
        GameObject newAttack = Instantiate(ab3, ship.transform.position, ship.transform.rotation);
      //  newAttack.GetComponent<ProjectileMotion>().Holder.copy(yeet.getName(), yeet.getTeam(), yeet.getAbility());
    }

}
