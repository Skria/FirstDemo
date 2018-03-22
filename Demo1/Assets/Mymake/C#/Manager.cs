using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public GameObject father;
    public GameObject showparse;
    public GameObject showwin;
    public GameObject showdeath;
    public bool winui;
    public bool deathui;
    public bool parse;
    public int count;
    public int level ;
    public bool producttank;
    public GameObject tank;
    public bool parseui;
    public bool herodeath;
	// Use this for initialization
	void Start () {
        father = GameObject.FindGameObjectWithTag("HPcamera");
        winui = false;
        deathui = false;
        producttank = false;
        parse = false;
        parseui = false;
        herodeath = false;
    }
	
	// Update is called once per frame
	void Update () {
        check();
        if (Input.GetKeyDown(KeyCode.Escape) && parseui == false && herodeath == false)
        {
            Time.timeScale = 0;
            parse = true;
            parseui = true;
            GameObject.Instantiate(showparse, new Vector3(0, 0, 0), this.transform.rotation);
        }
        if (herodeath == true && deathui == false)
        {
            GameObject temp;
            deathui = true;
            temp =  GameObject.Instantiate(showdeath, new Vector3(0, 0, 0), this.transform.rotation);
            temp.transform.parent = father.transform;
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public void check()
    {
        if(count <= 0)
        {
            if (level == 5)
            {
                if(producttank == false)
                {
                    producttank = true;
                    GameObject.Instantiate(tank, new Vector3(30,0,-10), this.transform.rotation);
                }
                else if (winui == false)
                {
                    GameObject temp;
                    winui = true;
                    temp = GameObject.Instantiate(showwin, new Vector3(0, 0, 0), this.transform.rotation);
                    temp.transform.parent = father.transform;
                    temp.transform.localPosition = Vector3.zero;
                    temp.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else if(winui == false)
            {
                GameObject temp;
                winui = true;
                temp = GameObject.Instantiate(showwin, new Vector3(0, 0, 0), this.transform.rotation);
                temp.transform.parent = father.transform;
                temp.transform.localPosition = Vector3.zero;
                temp.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

}
