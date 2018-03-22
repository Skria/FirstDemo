using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterbase : Base {
    public GameObject managerobject;
    public Manager manager;
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

    //开始旋转时候的角度
    public Quaternion start;
    //目标角度
    public Quaternion end;


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
    public void Start () {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        manager.count = manager.count + 1;
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


    public void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero; ;
    }

    public void OnTriggerEnter(Collider c)
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

    public void OnCollisionEnter(Collision collision)
    {
        Collider c = collision.collider;
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
        manager.count--;
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(coroutineproduct);
        GameObject.Destroy(this.gameObject);
    }

    //读取怪物属性
    public void Readatt()
    {
        string path = "Monster" + read;
        text = (TextAsset)Resources.Load(path);
        string str = text.text;
        string[] str1 = str.Split(',');
        movespeed = float.Parse(str1[0]);
        turnspeed = float.Parse(str1[1]);
        damage = int.Parse(str1[2]);
        hp = int.Parse(str1[3]);
    }

    //生产道具协程
    public IEnumerator Productprop()
    {
        Vector3 temp = gameObject.transform.position;
        temp.y = 0.5f;
        int kind = Random.Range(0, 800);
        kind = kind / 10;
        switch (kind)
        {
            case 1:
                GameObject.Instantiate(prophp, temp, this.transform.rotation);
                break;
            case 2:
                GameObject.Instantiate(propshoes, temp, this.transform.rotation);
                break;
            case 3:
                GameObject.Instantiate(propallmove, temp, this.transform.rotation);
                break;
            case 4:
                GameObject.Instantiate(propturn, temp, this.transform.rotation);
                break;
            case 5:
                GameObject.Instantiate(propin, temp, this.transform.rotation);
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(1);
    }


    //旋转物体到目标角度 策略0
    public void Turntoaim()
    {
        start = this.transform.rotation;
        this.transform.LookAt(hero.transform);
        end = this.transform.rotation;
        this.transform.rotation = start;
        //计算需要旋转的角度
        float needturn = Quaternion.Angle(start, end);
        float lerp_speed = turnspeed / needturn;
        float lerp_tm = lerp_speed * Time.deltaTime;
        this.transform.rotation = Quaternion.Lerp(start, end, lerp_tm);

    }

    //向前走
    public void Moveforward()
    {
        this.transform.Translate(0, 0, movespeed);
    }

}
