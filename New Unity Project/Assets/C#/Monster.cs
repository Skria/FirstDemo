using UnityEngine;
using System.Collections;
using System.IO;

public class Monster : Base
{
    //死亡协程运行标志
    bool cdeathflag;
    //死亡判断标志
    bool deathflag;
    //采取的策略种类
    public int kind;
    //开始旋转时候的角度
    private Quaternion start;
    //目标角度
    private Quaternion end;
    GameObject hero;

    //碰撞体积（可能不用）
    public float volume;
    //旋转速度
    public float turnspeed;
    private float lerpt;

    //用于怪物伤害人物
    private bool isdamage;
    private int damage;
    private Hero heroat;
    //属性文件
    public TextAsset text;

    //动画管理
    Animator animator;

    //死亡协程管理
    private IEnumerator coroutine;

    //折线移动标志
    bool xmoveflag;
    bool zmoveflag;
    //用于远程怪物射击
    public bool fire;
    public Bullet bullet;
    private IEnumerator coroutineshoot;

    //用于策略5三步一停中的一停、
    int count5;
    //用于策略6怪物行走方式的阶段指示
    private int level6 ;
    //策略6 2阶段移动方向指示
    bool level6up;

    //用于怪物死亡后道具的生成
    public GameObject propin;
    public GameObject propshoes;
    public GameObject prophp;
    public GameObject propallmove;
    public GameObject propturn;
    private IEnumerator coroutineproduct;
    // Use this for initialization
    void Start()
    {
        count5 = 1;
        level6 = 1;
        cdeathflag = false;
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
        deathflag = false;
        animator = this.GetComponent<Animator>();
        animator.SetBool("run", true);
        coroutine = Monsterdeath();
        Readatt();
        isdamage = false;
        coroutineshoot = WaitAndShoot(2);
        fire = false;
        coroutineproduct = Productprop();
        xmoveflag = true;
        zmoveflag = false;
        level6up = false;
}

    // Update is called once per frame
    void Update()
    {
        //判断选择的策略
        if (kind == 0 && deathflag == false)
        {
            Turntoaim();
            Moveforward();
        }
        else if (kind == 1 && deathflag == false)
        {
            Movestrength();
        }
        else if (kind == 2 && deathflag == false)
        {
            Stopturn();
        }
         else if(kind == 3 && deathflag == false)
        {
            Turntoaimup();
        }
        else if (kind == 4 && deathflag == false)
        {
            Archer();
        }
        else if (kind == 5 && deathflag == false)
        {
            Stopandrun();
        }
        else if (kind == 6 && deathflag == false)
        {
            Movestrengthup();
        }

        //判断是否死亡
        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

    public int Getdamage()
    {
        return damage;
    }

    public void Changedamage(int change)
    {
        damage += change;
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


    //直线移动模式 策略1
    public void Movestrength()
    {
        Vector3 heroposition = hero.transform.position;
        Vector3 monsterposition = this.transform.position;
        //需要的位移
        Vector3 needposition = heroposition - monsterposition;
        float dis = Vector3.Distance(heroposition, monsterposition);
        if (dis <= 40)
        {
            Turntoaim();
            Moveforward();
        }
        else
        {
            Turntoaim();
            if (xmoveflag == true)
            {
                if (needposition.x <= 20 && needposition.x >= -20)
                {
                    xmoveflag = false;
                    zmoveflag = true;
                }
            }
            if(zmoveflag == true)
            {
                if (needposition.z <= 20 && needposition.z >= -20)
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
            else if(xmoveflag)
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
        }
    }

    //停顿转弯后移动   策略2
    public void Stopturn()
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

        if (needturn <= 15)
        {
            Moveforward();
        }
    }


    //旋转至目标角度变种 策略3
    public void Turntoaimup()
    {
        Vector3 heroposition = hero.transform.position;
        Vector3 monsterposition = this.transform.position;
        //需要的位移
        Vector3 needposition = heroposition - monsterposition;
        float dis = Vector3.Distance(heroposition, monsterposition);


        start = this.transform.rotation;
        this.transform.LookAt(hero.transform);
        end = this.transform.rotation;
        this.transform.rotation = start;
        //计算需要旋转的角度
        float needturn = Quaternion.Angle(start, end);

        float lerp_speed = turnspeed / needturn;

        float lerp_tm = lerp_speed * Time.deltaTime;
        this.transform.rotation = Quaternion.Lerp(start, end, lerp_tm);
        if (dis < 20)
        {
            this.transform.LookAt(hero.transform);
        }
        Moveforward();
    }

    //远程兵策略 4
    public void Archer()
    {
        Vector3 heroposition = hero.transform.position;
        Vector3 monsterposition = this.transform.position;
        //需要的位移
        Vector3 needposition = heroposition - monsterposition;
        float dis = Vector3.Distance(heroposition, monsterposition);
        if (dis > 600)
        {
            Movestrength();
        }
        else
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

            if (needturn <= 8)
            {
                if (fire == false)
                {
                    StartCoroutine(coroutineshoot);
                    fire = true;
                }
                else
                {
                    ;
                }
            }
            else
            {
                if (fire == false)
                {
                    ;
                }
                else
                {
                    fire = false;
                    StopCoroutine(coroutineshoot);
                    coroutine = WaitAndShoot(2);
                }

            }
        }
    }

    //三走一停策略 5
    public void Stopandrun()
    {
        count5 = count5 % 300;
        if(count5 < 200)
        {
            animator.SetBool("run", true);
            Turntoaim();
            Moveforward();
        }
        else
        {
            animator.SetBool("run", false);
        }
        count5++;
    }

    //直线移动模式改良版 策略6
    public void Movestrengthup()
    {
        Vector3 heroposition = hero.transform.position;
        Vector3 monsterposition = this.transform.position;
        //需要的位移
        Vector3 needposition = heroposition - monsterposition;
        float dis = Vector3.Distance(heroposition, monsterposition);
        Debug.Log(level6);
        if (dis <= 40 && level6 == 4)
        {
            Turntoaim();
        }
        else
        {
            Turntoaim();
            if (xmoveflag == true && (level6 == 1  || level6 ==4 ))
            {
                if (needposition.x <= 20 && needposition.x >= -20)
                {
                    xmoveflag = false;
                    zmoveflag = true;
                    if (level6 == 1)
                    {
                        if (needposition.x <= 20 && needposition.x >= 0)
                        {
                            level6up = true;
                        }
                        else
                        {
                            level6up = false;
                        }
                        level6 = 2;
                    }
                }
               
            }
            if (zmoveflag == true && (level6 == 3 || level6 == 4))
            {
                if (needposition.z <= 20 && needposition.z >= -20)
                {
                    zmoveflag = false;
                    xmoveflag = true;
                    level6 = 4;
                }
            
            }

            if (level6 == 2)
            {
                if (level6up)
                {
                    if(needposition.x <= -200)
                    {
                        level6 = 3;
                    }
                    this.transform.Translate(movespeed, 0, 0, Space.World);
                }
                else
                {
                    if (needposition.x >= 200)
                    {
                        level6 = 3;
                    }
                    this.transform.Translate(-movespeed, 0, 0, Space.World);
                }
            }


            if (zmoveflag && level6 != 2)
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
            else if (xmoveflag && level6 != 2)
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
        }
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
    private IEnumerator Monsterdeath()
    {
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2);
        StartCoroutine(coroutineproduct);
        GameObject.Destroy(this.gameObject);
    }

    //读取怪物属性
    private void Readatt()
    {
        string str = text.text;
        string[] str1 = str.Split(',');
        kind = int.Parse(str1[0]);
        movespeed = float.Parse(str1[1]);
        turnspeed = float.Parse(str1[2]);
        damage = int.Parse(str1[3]);
        hp = int.Parse(str1[4]);
    }

    private IEnumerator WaitAndShoot(float waitTime)
    {
        while (true)
        {
            GameObject.Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator Productprop()
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
            default :
                break;
        }
        yield return new WaitForSeconds(1);
    }
}
