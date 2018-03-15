using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterhome : MonoBehaviour {

    public GameObject Monster;
    //死亡协程运行标志
    bool cdeathflag;
    //死亡判断标志
    bool deathflag;
    //死亡协程管理
    private IEnumerator coroutine;

    //生产协程
    private IEnumerator coroutineprooduct;
    //死亡协程运行标志
    bool cproductflag;

    int hp;
    float producetime;
    GameObject hero;

    // Use this for initialization
    void Start () {
        hp = 20;
        deathflag = false;
        cdeathflag = false;
        cproductflag = false;
        coroutine = Monsterdeath();
        hero = GameObject.FindGameObjectWithTag("Hero");
        coroutineprooduct = Monsterproduct();
    }
	
	// Update is called once per frame
	void Update () {
        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
        this.transform.LookAt(hero.transform.position);
        if(cproductflag == false)
        {
            StartCoroutine(coroutineprooduct);
            Debug.Log("运行成功");
            cproductflag = true;
        }
    }

    //死亡协程
    private IEnumerator Monsterdeath()
    {
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

    //生产怪物协程
    private IEnumerator Monsterproduct()
    {
        while (true)
        {
            yield return new WaitForSeconds(5.0f);
            GameObject.Instantiate(Monster, this.transform.position, this.transform.rotation);

        }
    }
}
