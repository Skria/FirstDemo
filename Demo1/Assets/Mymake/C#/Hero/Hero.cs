using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Base {
    public int equipment;
    public bool invincibleflag;
    // Use this for initialization
    void Start () {
        maxhp = 100;
        hp = 100;
        movespeed = 0.1f;
        equipment = 1;
        invincibleflag = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero; ;
    }
}
