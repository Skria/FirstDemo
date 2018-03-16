using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroturn : MonoBehaviour {

    Camera camera;
    Vector3 mousevec;
    // Use this for initialization
    void Start () {
        camera = Camera.main;
    }
	
	// Update is called once per frame
	void Update () {
        Followmouse();
	}

    void Followmouse()
    {
        mousevec = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.y));
        mousevec.y = this.transform.position.y;
        this.transform.LookAt(mousevec);
    }
}
