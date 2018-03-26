using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Monsterbase {

    public GameObject showmyhp;
    GameObject showmyhpcopy;

    public GameObject tankmine;
    public GameObject tankbullet;
    public GameObject tankshell;
    public GameObject seedeath;
    public bool xmoveflag;
    public bool zmoveflag;
    public IEnumerator coroutineturnshoot;
    public IEnumerator coroutineshootbullet;
    public IEnumerator coroutineshootall;
    public int minedis;
    //旋转设计子弹
    public float count1;
    public bool countflag1;
    //360度子弹
    public float count2;
    //地雷
    public float  count3;
    Vector3 heroposition;
    Vector3 monsterposition;
    Vector3 needposition;
    float dis;

    float needturn;
    bool again;
    bool startshoot;


    void Start()
    {
        countflag1 = false;
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        manager.count = manager.count + 1;
        showmyhpcopy = GameObject.Instantiate(showmyhp, new Vector3(0,0,0), gameObject.transform.rotation);
        startshoot = false;
        coroutineshootall = IShootall();
        again = false;
        cdeathflag = false;
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
        deathflag = false;
        animator = this.GetComponent<Animator>();
        coroutine = Monsterdeath();
        Readatt();
        isdamage = false;
        coroutineproduct = Productprop();
        coroutineshootbullet = Shootbullet();
        coroutineturnshoot = Turnandshoot();
        StartCoroutine(coroutineshootbullet);
        count1 = 0;
        count2 = 0;
        count3 = 0;
        xmoveflag = true;
        zmoveflag = false;
        maxhp = hp;
    }

    // Update is called once per frame
    void Update () {
        if (manager.parse == false && countflag1 == false)
        {
            heroposition = hero.transform.position;
            monsterposition = this.transform.position;
            needposition = heroposition - monsterposition;
            dis = Vector3.Distance(heroposition, monsterposition);

            start = this.transform.rotation;
            this.transform.LookAt(hero.transform);
            end = this.transform.rotation;
            this.transform.rotation = start;
            //计算需要旋转的角度
            needturn = Quaternion.Angle(start, end);

            check();
        }
    }

    void FixedUpdate()
    {
        if(countflag1 == false)
        {
            count1++;
        }
        count2++;
    }

    private IEnumerator Shootbullet()
    {
        while (true)
        {
            for(int i = 0; i < 5; i++)
            {
                GameObject.Instantiate(tankbullet, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), this.transform.rotation);
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(2.0f);
            GameObject.Instantiate(tankshell, new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z), this.transform.rotation);
        }
    }

    private IEnumerator IShootall()
    {
            for (int i = 0; i < 5; i++)
            {
                Shootall(i*5);
                yield return new WaitForSeconds(0.3f);
            }
    }

    public IEnumerator Monsterdeath()
    {
        manager.count--;
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(coroutineproduct);
        GameObject.Destroy(showmyhpcopy);
        GameObject.Destroy(this.gameObject);

    }

    //怪物技能激活与需要采取的移动方式
   private void check()
    {
        if(needturn > 45)
        {
            Stopturn();
        }
        else
        {
            Movestrength();
        }

        if(count1 > 500 && hp < 1000)
        {
            coroutineturnshoot = Turnandshoot();
            StartCoroutine(coroutineturnshoot);
            countflag1 = true;
            count1 = 0;
        }

        if(count2 > 600)
        {
            StartCoroutine(coroutineshootall);
            startshoot = true;
            count2 = 0;
        }
        if(count2 <= 300 && startshoot == true && count2 >= 200)
        {
            StopCoroutine(coroutineshootall);
            coroutineshootall = IShootall();
        }
       
        if(count3 > 20)
        {
            productmine();
            count3 = 0;
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StopCoroutine(coroutineshootbullet);
            StartCoroutine(coroutine);
        }
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

    private void productmine()
    {
        GameObject.Instantiate(tankmine, this.transform.position, this.transform.rotation);
    }

    private void Shootall(float j)
    {
        Quaternion temp = new Quaternion();
        for (int i = 0; i < 18; i++)
        {
            temp.eulerAngles = new Vector3(0, i * 20+j, 0);
            GameObject.Instantiate(tankbullet, new Vector3(this.transform.position.x, this.transform.position.y + 0.6f, this.transform.position.z), temp);
        }
    }

    new public void Moveforward()
    {
        this.transform.Translate(0, 0, movespeed);
        count3 += movespeed;
    }

    public void Stopturn()
    {
        float lerp_speed = turnspeed / needturn;
        float lerp_tm = lerp_speed * Time.deltaTime;
        this.transform.rotation = Quaternion.Lerp(start, end, lerp_tm);
        if(again == true)
        {
            again = false;
        }
    }

    public void Movestrength()
    {
        if(again == false)
        {
            xmoveflag = true;
            zmoveflag = false;
            again = true;
        }
        if (dis <= 5)
        {
            this.transform.LookAt(hero.transform);
            Turntoaim();
        }
        else
        {
            Turntoaim();
            if (xmoveflag == true)
            {
                if (needposition.x <= 3 && needposition.x >= -3)
                {
                    xmoveflag = false;
                    zmoveflag = true;
                }
            }
            if (zmoveflag == true)
            {
                if (needposition.z <= 3 && needposition.z >= -3)
                {
                    zmoveflag = false;
                    xmoveflag = true;
                }
            }

            if (zmoveflag)
            {
                if (needposition.z > 0)
                {
                    this.transform.Translate(0, 0, movespeed, Space.World);
                }
                else
                {
                    this.transform.Translate(0, 0, -movespeed, Space.World);
                }
            }
            else if (xmoveflag)
            {
                if (needposition.x > 0)
                {
                    this.transform.Translate(movespeed, 0, 0, Space.World);
                }
                else
                {
                    this.transform.Translate(-movespeed, 0, 0, Space.World);
                }
            }
            count3 += movespeed;
        }
    }

    public IEnumerator Turnandshoot()
    {
        countflag1 = true;
        int speed = 17;
        for (int i = 0; i < 216; i++)
        {
            GameObject.Instantiate(tankbullet, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), this.transform.rotation);
            this.transform.Rotate(Vector3.up * speed);
            transform.position += (hero.transform.position - transform.position).normalized * movespeed;
            yield return new WaitForSeconds(0.01f);
        }
        countflag1 = false;
    }
}
