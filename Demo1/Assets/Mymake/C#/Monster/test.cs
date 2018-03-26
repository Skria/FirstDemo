using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider c)
    {
        Quaternion tempstart = gameObject.transform.rotation;
        Quaternion tempend = c.transform.rotation;
        gameObject.transform.rotation = tempend;
        gameObject.transform.Translate(Vector3.forward);
        gameObject.transform.rotation = tempstart;
    }
}
