using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroturn : MonoBehaviour {
    public GameObject managerobject;
    public Manager manager;
    Hero hero;
    Camera camera;
    Vector3 mousevec;
    // Use this for initialization
    void Start () {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        camera = Camera.main;
        hero = gameObject.GetComponent<Hero>();
    }
	
	// Update is called once per frame
	void Update () {
        if (hero.deathflag == false && manager.parse == false)
        {
            Followmouse();
        }
	}

    void Followmouse()
    {
        mousevec = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.y));
        mousevec.y = this.transform.position.y;
        this.transform.LookAt(mousevec);
    }
}
