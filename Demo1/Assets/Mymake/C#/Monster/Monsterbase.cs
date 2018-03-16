using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterbase : Base {
    public TextAsset text;
    public GameObject hero;
    //死亡协程运行标志
    public bool cdeathflag;
    //死亡判断标志
    public bool deathflag;
    public int read;
    //旋转速度
    public float turnspeed;
    public float lerpt;

    //用于怪物伤害人物
    public bool isdamage;
    public int damage;
    public Hero heroat;

    //动画管理
    public Animator animator;

    //死亡协程管理
    public IEnumerator coroutine;

    //用于怪物死亡后道具的生成
    public GameObject propin;
    public GameObject propshoes;
    public GameObject prophp;
    public GameObject propallmove;
    public GameObject propturn;
    public IEnumerator coroutineproduct;
    // Use this for initialization
    void Start () {
        cdeathflag = false;
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
        deathflag = false;
        animator = this.GetComponent<Animator>();
        animator.SetBool("run", true);
        coroutine = Monsterdeath();
        Readatt();
        isdamage = false;
        coroutineproduct = Productprop();

    }

    // Update is called once per frame
    public void Update () {
       

    }
    public void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero; ;
    }

    void OnTriggerEnter(Collider c)
    {
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
        //跟炸弹层碰撞
        if (c.gameObject.layer == 12)
        {
            hp -= 15;
            Debug.Log("我与炸弹碰撞" + hp);
            if (hp <= 0)
            {
                deathflag = true;
            }
        }

        if (c.gameObject.layer == 9)
        {
            bool invincibleflag = heroat.invincibleflag;
            if (invincibleflag == false)
            {
                heroat.hp = heroat.hp - damage;
            }
        }

        
    }

    void OnCollisionEnter(Collision collision)
    {

        Collider c = collision.collider;
        Debug.Log("我与英雄相撞");

        if (c.gameObject.layer == 9)
        {
            bool invincibleflag = heroat.invincibleflag;
            if (invincibleflag == false)
            {
                heroat.hp = heroat.hp - damage;
            }
        }
    }


    //死亡协程
    public IEnumerator Monsterdeath()
    {
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2);
        StartCoroutine(coroutineproduct);
        GameObject.Destroy(this.gameObject);
    }

    //读取怪物属性
    public void Readatt()
    {
        string path = "Monster" + read;
        Debug.Log(path);
        text = (TextAsset)Resources.Load(path);
        string str = text.text;
       
        Debug.Log(str);
        string[] str1 = str.Split(',');
        movespeed = float.Parse(str1[0]);
        turnspeed = float.Parse(str1[1]);
        damage = int.Parse(str1[2]);
        hp = int.Parse(str1[3]);
    }

    //生产道具协程
    public IEnumerator Productprop()
    {
        int kind = Random.Range(0, 200);
        kind = kind / 10;
        switch (kind)
        {
            case 1:
                GameObject.Instantiate(prophp, gameObject.transform.position, this.transform.rotation);
                break;
            case 2:
                GameObject.Instantiate(propshoes, gameObject.transform.position, this.transform.rotation);
                break;
            case 3:
                GameObject.Instantiate(propallmove, gameObject.transform.position, this.transform.rotation);
                break;
            case 4:
                GameObject.Instantiate(propturn, gameObject.transform.position, this.transform.rotation);
                break;
            case 5:
                GameObject.Instantiate(propin, gameObject.transform.position, this.transform.rotation);
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1);
    }

}
