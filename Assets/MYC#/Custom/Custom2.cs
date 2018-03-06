using UnityEngine;
using System.Collections;

public class Custom2 : Custom {

	// Use this for initialization
	void Start () {
		hp = 30;
		movespeed = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp <= 0) {
			overtime += Time.deltaTime;
			this.GetComponent<Renderer>().material.color = new Color(  
	        this.GetComponent<Renderer>().material.color.r, 
	        this.GetComponent<Renderer>().material.color.g,  
	        this.GetComponent<Renderer>().material.color.b,  
	        //减小Alpha值  
	        gameObject.GetComponent<Renderer>().material.color.a - overtime / 20f);  
			Debug.Log("overtime:"+overtime);
			Debug.Log("A:"+(gameObject.GetComponent<Renderer>().material.color.a - overtime / 20f));
		}
		if (overtime >= 20) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
