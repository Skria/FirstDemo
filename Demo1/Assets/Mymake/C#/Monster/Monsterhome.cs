using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterhome : MonoBehaviour
{
    public GameObject managerobject;
    public Manager manager;

    public GameObject monster;
    //生产协程
    private IEnumerator coroutineprooduct;
    //死亡协程运行标志
    bool cproductflag;

    //死亡协程运行标志
    public bool cdeathflag;
    //死亡判断标志
    public bool deathflag;
    //死亡协程管理
    private IEnumerator coroutine;
    public int hp;
    public GameObject hero;
    // Use this for initialization
    void Start () {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        manager.count = manager.count + 1;
        hp = 50;
        deathflag = false;
        cdeathflag = false;
        cproductflag = false;
        coroutine = Monsterdeath();
        hero = GameObject.FindGameObjectWithTag("Hero");
        coroutineprooduct = Monsterproduct();
    }
	
	// Update is called once per frame
	void Update () {
        if(manager.parse == false)
        { 
            this.transform.LookAt(hero.transform.position);
            if (cproductflag == false )
            {
                StartCoroutine(coroutineprooduct);
                cproductflag = true;
            }
        }
        if (deathflag == true && cdeathflag == false)
        {
            StopCoroutine(coroutineprooduct);
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator Monsterproduct()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            GameObject.Instantiate(monster, this.transform.position, this.transform.rotation);
        }
    }

    private IEnumerator Monsterdeath()
    {
        manager.count--;
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        yield return new WaitForSeconds(0.01f);
        GameObject.Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider c)
    {
        //与子弹层碰撞
        if (c.gameObject.layer == 10)
        {
            Bullet bullet = c.GetComponent<Bullet>();
            if (bullet.kind == 1 || bullet.kind == 2)
            {
                hp -= bullet.Getdamage();
                if (hp <= 0)
                {
                    deathflag = true;
                }
            }
        }
    }
}
