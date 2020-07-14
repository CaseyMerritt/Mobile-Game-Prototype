using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuAccess : MonoBehaviour {

    private GameObject Room;
    private static int NumberOfIterations;
    GameObject[] Top = new GameObject[NumberOfIterations + 1];
    GameObject[] Right = new GameObject[NumberOfIterations + 1];
    GameObject[] Down = new GameObject[NumberOfIterations + 1];
    GameObject[] Left = new GameObject[NumberOfIterations + 1];

    private void Start() {
        NumberOfIterations = 2;
        Room = (GameObject)Resources.Load("Assets/Models/Rooms/MainRoom");
    }

    public void GenerateMap() {
        GameObject first;
        first = Instantiate(Room, new Vector3(0, 0, 0), Quaternion.identity);
        Top[0] = first;
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < NumberOfIterations; j++) {
                if (i == 0)
                {
                    if (j == 0)
                    {
                        float scalex = Random.Range(1f, 1f);
                        float scalez = Random.Range(1f, 1f);
                        GameObject temp = Instantiate(Room, first.transform.position + new Vector3((1 / 2) + (scalex / 2), 0, 0), Quaternion.identity);
                        Top[j + 1] = temp;
                        Top[j + 1].GetComponent<Data>().SetScale(scalex, scalez);
                        Top[j + 1].GetComponent<Data>().SetPosition(Top[j + 1].gameObject.transform.position);
                    }
                    else {
                        float scalex = Random.Range(1f, 1f);
                        float scalez = Random.Range(1f, 1f);
                        int direction = (int)Random.Range(0f, 3f);
                        if (direction == 0)
                        {
                            GameObject temp = Instantiate(Room, Top[j].transform.position + new Vector3((Top[j].GetComponents<Data>().GetScale() / 2) + (scalex / 2), 0, 0), Quaternion.identity);
                            Top[j + 1].GetComponent<Data>().SetScale(scalex, scalez);
                            Top[j + 1].GetComponent<Data>().SetPosition(Top[j + 1].gameObject.transform.position);
                            Top[j + 1] = temp;

                        }
                        else if (direction == 1)
                        {


                        }
                        else if (direction == 2)
                        {


                        }
                        else if(direction == 3)
                        {


                        }
                    }
                }
                else if (i == 1)
                {

                }
                else if (i == 2)
                {

                }
                else if (i == 3) {

                }
            }
        }
    }

    public void ClearMap() {

    }
}
