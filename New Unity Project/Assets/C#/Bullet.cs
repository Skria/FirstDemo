﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject boomrange;
    public GameObject seeboom;
    public int kind;
    public int damage;
    public float speed;
    GameObject hero;
    Hero heroat;
    // Use this for initialization
    void Start()
    {
        this.transform.Translate(Vector3.forward*speed);
        hero = GameObject.FindGameObjectWithTag ("Hero");
        heroat = hero.GetComponent<Hero>();
    }

    public void Changedamege(int change)
    {
        damage += change;
    }

    public int Getdamage()
    {
        return damage;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed);

        //自我销毁模块

    }

    void OnTriggerEnter(Collider c)
    {
        //与怪物碰撞
        if (c.gameObject.layer == 11)
        {
            if (kind == 99)
            {
                ;
            }
            else if(kind ==1)
            {
                GameObject.Destroy(this.gameObject);
            }
            //爆炸子弹 
            else if(kind == 3)
            {
                Showboom();
                //胶囊体碰撞实现爆炸效果
                GameObject.Instantiate(boomrange, gameObject.transform.position, gameObject.transform.rotation);
                GameObject.Destroy(this.gameObject);
            }
        }

        //与墙壁碰撞
        if(c.gameObject.layer == 13)
        {
            GameObject.Destroy(this.gameObject);
        }

        //与英雄相撞
        if (c.gameObject.layer == 9)
        {
            if(kind == 99)
            {
                if(heroat.hp - damage <= 0)
                {
                    heroat.hp = 0;
                }
                else
                {
                    heroat.hp = heroat.hp - damage;
                }
                GameObject.Destroy(this.gameObject);
            }
        }
    }

    private void Showboom()
    {
        GameObject.Instantiate(seeboom, gameObject.transform.position,gameObject.transform.rotation);
    }
}
