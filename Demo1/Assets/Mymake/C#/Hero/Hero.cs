﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Base {
    public GameObject managerobject;
    public Manager manager;
    public int equipment;

    public bool invincibleflag;

    /*
    private float invincibletime = 0f;
    public bool IsInvincible
    {
        get { return Time.time - invincibletime < 5f; }
        set { invincibletime = Time.time; }
    }
    */


    //用于实现人物的死亡
    public  bool deathflag;
    //死亡协程运行标志
    public bool cdeathflag;
    //死亡协程管理
    private IEnumerator coroutine;
    Animator animator;
    // Use this for initialization
    void Start () {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        coroutine = Herodeath();
        maxhp = 100;
        hp = 100;
        movespeed = 0.25f;
        equipment = 1;
        invincibleflag = false;
        deathflag = false;
        cdeathflag = false;
        animator = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Death();
        if (gameObject.transform.position.y > 0)
        {
            Vector3 temp = gameObject.transform.position;
            temp.y = 0;
            gameObject.transform.position = temp; 
        }
       
	}


    void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero; ;
    }

    void Death()
    {
        if (hp <= 0 && deathflag == false)
        {
            deathflag = true;
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator Herodeath()
    {
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2);
        manager.herodeath = true;
    }
}
