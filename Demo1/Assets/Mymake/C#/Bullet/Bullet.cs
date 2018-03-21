using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject managerobject;
    public Manager manager;
    public GameObject hitblood;
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
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        this.transform.Translate(Vector3.forward * speed);
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
    }


    // Update is called once per frame
    void Update()
    {
        if (manager.parse == false)
        {
            this.transform.Translate(Vector3.forward * speed);
        }
    }


    public void Changedamege(int change)
    {
        damage += change;
    }

    public int Getdamage()
    {
        return damage;
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
            else if(kind == 2)
            {
                GameObject.Instantiate(hitblood, gameObject.transform.position, gameObject.transform.rotation);
            }
            else if (kind == 1)
            {
                GameObject.Instantiate(hitblood, gameObject.transform.position, gameObject.transform.rotation);
                GameObject.Destroy(this.gameObject);
            }
            //爆炸子弹 
            else if (kind == 3)
            {
                Showboom();
                //胶囊体碰撞实现爆炸效果
                GameObject.Instantiate(boomrange, gameObject.transform.position, gameObject.transform.rotation);
                GameObject.Destroy(this.gameObject);
            }
        }

        //与墙壁碰撞
        if (c.gameObject.layer == 8)
        {
            if (kind == 3)
            {
                Showboom();
                //胶囊体碰撞实现爆炸效果
                GameObject.Instantiate(boomrange, gameObject.transform.position, gameObject.transform.rotation);
            }
            GameObject.Destroy(this.gameObject);
        }

        //与英雄相撞
        if (c.gameObject.layer == 9)
        {
            if (kind == 99)
            {
                GameObject.Instantiate(hitblood, gameObject.transform.position, gameObject.transform.rotation);
                if (heroat.hp - damage <= 0)
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
        GameObject.Instantiate(seeboom, gameObject.transform.position, gameObject.transform.rotation);
    }
}
