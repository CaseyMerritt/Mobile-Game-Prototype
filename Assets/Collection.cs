using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour {

    private int childCount;
    private int index;
    private GameObject parentHolder;

    // Use this for initialization
    private void Awake()
    {
        parentHolder = GameObject.Find("ParentHolder");
    }

    void Start () {
        childCount = parentHolder.transform.childCount;
        index = 0;
	}

    public void LeftArrow() {
        if ((index - 1) < 0)
        {
            index = 0;
        }
        else {
            index--;
            parentHolder.transform.GetChild(index + 1).gameObject.SetActive(false);
            parentHolder.transform.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void rightArrow() {
        if ((index + 1) > childCount)
        {
            index = childCount;
        }
        else {
            index++;
            parentHolder.transform.GetChild(index - 1).gameObject.SetActive(false);
            parentHolder.transform.GetChild(index).gameObject.SetActive(true);
        }
    }
}
