using UnityEngine;
using System.Collections;

public class turn : MonoBehaviour {
	
	Vector3 herovec;
	Vector3 mousevec;
	Camera maincamera;

	// Use this for initialization
	void Start () {
		maincamera = Camera.main;
	}

	// Update is called once per frame
	void Update () {
		herovec = this.transform.position;
		mousevec = maincamera.ScreenToWorldPoint(new Vector3 (Input.mousePosition.x,Input.mousePosition.y,maincamera.transform.position.y));
		mousevec.y = herovec.y;
		this.transform.LookAt (mousevec);      

	}
}
