using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductMonsters : MonoBehaviour {

    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public GameObject Monster4;
    public GameObject Monster5;
    public GameObject Monster6;
    GameObject hero;
    // Use this for initialization
    void Start () {
        hero = GameObject.FindGameObjectWithTag("Hero");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(hero.transform.position);
	}

    public void Productmonster1()
    {
        GameObject.Instantiate(Monster1, this.transform.position, this.transform.rotation);
    }

    public void Productmonster2()
    {
        GameObject.Instantiate(Monster2, this.transform.position, this.transform.rotation);
    }

    public void Productmonster3()
    {
        GameObject.Instantiate(Monster3, this.transform.position, this.transform.rotation);
    }
    public void Productmonster4()
    {
        GameObject.Instantiate(Monster4, this.transform.position, this.transform.rotation);
    }
    public void Productmonster5()
    {
        GameObject.Instantiate(Monster5, this.transform.position, this.transform.rotation);
    }
    public void Productmonster6()
    {
        GameObject.Instantiate(Monster6, this.transform.position, this.transform.rotation);
    }
}
