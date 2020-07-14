using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Canvas Play;
    public Canvas Collection;
    public Canvas Options;
    public GameObject CollectionShipHolder;
    public GameObject HomePageShip;
    private GameObject CenterPoint;
    private string HomePageShipName;

    // Use this for initialization
    private void Awake()
    {
        CollectionShipHolder = GameObject.Find("ParentHolder");
        HomePageShipName = PlayerPrefs.GetString("ShipName", "SpaceShip");
        HomePageShip = (GameObject)Resources.Load("Prefabs/Ships/HomePage/" + HomePageShipName);
        CenterPoint = GameObject.Find("SpawnLocation");
    }

    private void Start()
    {
        CollectionShipHolder.gameObject.SetActive(false);
        atTheBeggining();
    }

    public void LoadPlay()
    {
        SceneManager.LoadScene("Play");
    }

    public void LoadCollection()
    {
        HomePageShip.gameObject.SetActive(false);
        Play.gameObject.SetActive(false);
        CollectionShipHolder.SetActive(true);
        Collection.gameObject.SetActive(true);

        int yaBoi = CollectionShipHolder.transform.childCount;
        for (int i = 0; i < yaBoi; i++) {
            if (i == 0) {
                CollectionShipHolder.transform.GetChild(i).gameObject.SetActive(true);
            }
            else{
                CollectionShipHolder.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void LoadShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void LoadHome()
    {
        Destroy(HomePageShip);
        HomePageShip = (GameObject)Resources.Load("Prefabs/Ships/HomePage/" + HomePageShipName);
        GameObject temp;
        temp = Instantiate(HomePageShip, CenterPoint.transform.position, HomePageShip.transform.rotation);
        HomePageShip = temp;
        this.gameObject.GetComponent<ManualTurn>().setShip(HomePageShip);
        Play.gameObject.SetActive(true);
        CollectionShipHolder.SetActive(false);
        Collection.gameObject.SetActive(false);
    }

    public void LoadOptions()
    {
        
    }

    void atTheBeggining() {
        GameObject temp;
        temp = Instantiate(HomePageShip, CenterPoint.transform.position, HomePageShip.transform.rotation);
        HomePageShip = temp;
        Play.gameObject.SetActive(true);
    }
}
