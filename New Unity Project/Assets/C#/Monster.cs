using UnityEngine;
using System.Collections;
using System.IO;

public class Monster : Base {
    //死亡协程运行标志
    bool cdeathflag;
    //死亡判断标志
    bool deathflag;
    //采取策略
	public int kind;
	//开始旋转时候的角度
	private Quaternion start;
	//目标角度
	private Quaternion end;
	GameObject hero;
	//伤害
	public int damage;
	//碰撞体积（可能不用）
	public float volume;
	//旋转速度
	public float turnspeed;
	private float lerpt;

    //属性文件
    public TextAsset text;

    //动画管理
    Animator animator;

    //协程管理
    private IEnumerator coroutine;
    // Use this for initialization
    void Start () {
        cdeathflag = false;
        hero = GameObject.FindGameObjectWithTag("Hero");
        deathflag = false;
        animator = this.GetComponent<Animator>();
        animator.SetBool("run", true);
        coroutine = Monsterdeath();
        Readatt();
    }
	
	// Update is called once per frame
	void Update () {
        //判断选择的策略
		if (kind == 1 && deathflag == false) {
            Movestrength ();
		} 
		else if (kind == 0 && deathflag == false){
			Turntoaim();
		}
        else if (kind == 2 && deathflag == false)
        {
            Stopturn();
        }

        //判断是否死亡
        if(deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
	}

	public int Getdamage() {
		return damage;
	}

	public void Changedamage(int change) {
		damage += change;
	}


	//旋转物体到目标角度 策略0
	public void Turntoaim () {
		start = this.transform.rotation;
		this.transform.LookAt (hero.transform);
		end = this.transform.rotation;
		this.transform.rotation = start;
		//计算需要旋转的角度
		float needturn = Quaternion.Angle (start,end);

		float lerp_speed = turnspeed / needturn;

		float lerp_tm = lerp_speed * Time.deltaTime;
		this.transform.rotation = Quaternion.Lerp(start, end, lerp_tm);

        Moveforward();
	}

	//向前走
	public void Moveforward () {
		this.transform.Translate (0,0,movespeed);
	}


	//直线移动模式 策略1
	public void Movestrength() {
		Vector3 heroposition = hero.transform.position;
		Vector3 monsterposition = this.transform.position;
		//需要的位移
		Vector3 needposition = heroposition - monsterposition;
		float dis =  Vector3.Distance(heroposition,monsterposition);
		if (dis <= 100) {
			Turntoaim ();
		} 
		else {
			Turntoaim();
			if (needposition.x <= 50 && needposition.x >= -50) {
				if(needposition.z>0) {
					this.transform.Translate(0,0,movespeed,Space.World);
				}
				else {
					this.transform.Translate(0,0,-movespeed,Space.World);
				}
			}
			else {
				if(needposition.x>0) {
					this.transform.Translate(movespeed,0,0,Space.World);
				}
				else {
					this.transform.Translate(-movespeed,0,0,Space.World);
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

        if(needturn <=15)
        {
            Moveforward();
        }
    }

    void OnTriggerEnter(Collider c)
    {
        //与子弹层碰撞
        if (c.gameObject.layer == 10)
        {
            Bullet bullet = c.GetComponent<Bullet>();
            hp -= bullet.Getdamage();
            if(hp <= 0)
            {
                deathflag = true;
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



}
