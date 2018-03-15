using System.Collections;
using UnityEngine;

public class Hero : Base {

    //无敌标志
    public bool invincibleflag;

    //用于武器切换
    bool flag1;//武器1
    bool flag2;//武器2
    bool flag3;//武器3
    bool flag4;//武器4
    bool flag5;//武器5
    //用于实例化子弹
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    //用于射击
    bool fire;
    //射击间隔
    float waittime;
    //射击协程
    private IEnumerator coroutineshoot;
    //用于人物旋转
    Camera camera;
    Vector3 mousevec;
    //动画管理
    Animator animator;
    int equipment;

    //用于移动
    bool forward;
    bool back;
    bool left;
    bool right;

    //死亡协程管理
    private IEnumerator coroutine;

    //用于实现人物的死亡
    bool deathflag;
    //死亡协程运行标志
    private bool cdeathflag;

    //弹窗指示
    public bool showstart;
    // Use this for initialization

    //用于更换子弹模块
    public bool reloading;
    public int bulletcount;
    public bool reloadingfinish;
    private IEnumerator coroutinereloading;
    void Start ()
    {
        reloadingfinish = false;
        reloading = false;
        bulletcount = 10;
        waittime = 0.2f;
        animator = this.GetComponent<Animator>();
        maxhp = 100;
        hp = 100;
        movespeed = 5.0f;
        equipment = 1;
        forward = false;
        back = false;
        left = false;
        right = false;
        camera = Camera.main;
        fire = false;
        coroutineshoot = WaitAndShoot(waittime);
        coroutine = Herodeath();
        flag1 = true;
        flag2 = true;
        flag3 = true;
        flag4 = true;
        flag5 = true;
        deathflag = false;
        cdeathflag = false;
        invincibleflag = false;
        coroutinereloading = Watiandreloading();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(deathflag == false)
        {
            Changeequiment();
            Move();
            Followmouse();
            Shoot();
            Handreloding();
        }
        Death();
	}
    void FixedUpdate()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;;
    }

    void Shoot ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (fire == true)
            {

            }
            else
            {
                fire = true;
                StartCoroutine(coroutineshoot);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            fire = false;
        }

        if (fire == false)
        {
            StopCoroutine(coroutineshoot);
            coroutineshoot = WaitAndShoot(waittime);
        }
    }

    public void Changeequiment()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (equipment != 1 && flag1 == true)
            {
                bulletcount = 10;
                equipment = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (equipment != 2 && flag2 == true)
            {
                bulletcount = 30;
                equipment = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (equipment != 3 && flag3 == true)
            {
                bulletcount = 5;
                equipment = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (equipment != 4 && flag4 == true)
            {
                bulletcount = 3;
                equipment = 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (equipment != 5 && flag5 == true)
            {
                bulletcount = 3;
                equipment = 5;
            }
        }
    }

    public int Getequiment()
    {
        return equipment;
    }
    
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            forward = true;
            animator.SetBool("forward", true);

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            back = true;
            animator.SetBool("back", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            left = true;
            animator.SetBool("left", true);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            right = true;
            animator.SetBool("right", true);
        }

        //抬起
        if (Input.GetKeyUp(KeyCode.W))
        {
            forward = false;
            animator.SetBool("forward", false);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("back", false);
            back = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            left = false;
            animator.SetBool("left", false);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            right = false;
            animator.SetBool("right", false);
        }


        //移动
        if (forward)
        {
            this.transform.Translate(0, 0, movespeed, Space.World);
        }

        if (back)
        {
            this.transform.Translate(0, 0, 0 - movespeed, Space.World);
        }

        if (left)
        {
            this.transform.Translate(-movespeed, 0, 0, Space.World);
        }

        if (right)
        {
            this.transform.Translate(movespeed, 0, 0, Space.World);
        }
    }

    void Recprop()
    {

    }

    void Followmouse()
    {
        mousevec = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.transform.position.y));
        mousevec.y = this.transform.position.y;
        this.transform.LookAt(mousevec);
    }

    private IEnumerator WaitAndShoot(float waitTime)
    {
        while (true)
        {
            if (bulletcount >= 0)
            {
                bulletcount--;
            }
            if (equipment == 1 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet1, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                yield return new WaitForSeconds(0.2f);
            }
            else if (equipment == 2 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet2, this.transform.position, this.transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }
            else if (equipment == 3 && bulletcount >= 0)
            {
                Quaternion temp1 = this.transform.rotation;
                Quaternion temp2 = this.transform.rotation;
                temp1.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y + 30, 0);
                temp2.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y - 30, 0);
                GameObject.Instantiate(bullet3, this.transform.position, this.transform.rotation);
                GameObject.Instantiate(bullet3, this.transform.position, temp1);
                GameObject.Instantiate(bullet3, this.transform.position, temp2);
                yield return new WaitForSeconds(0.2f);
            }
             else if (equipment == 4 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet4, this.transform.position, this.transform.rotation);
                yield return new WaitForSeconds(0.4f);
            }
            else if (equipment == 5 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet5, this.transform.position, this.transform.rotation);
                yield return new WaitForSeconds(0.4f);
            }
            if (bulletcount == -1 && reloading == false)
            {
                Debug.Log("自动换子弹");
                StartCoroutine(coroutinereloading);
            }
            if(reloadingfinish == true)
            {
                StopCoroutine(coroutinereloading);
                coroutinereloading = Watiandreloading();
                reloadingfinish = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    void Death()
    {
        if (hp <= 0 && deathflag == false )
        {
            Debug.Log("我死了");
            deathflag = true;
        }

        if(deathflag == true && cdeathflag == false)
        {
            Debug.Log("我死了");
            cdeathflag = true;
            StartCoroutine(coroutine);
            Debug.Log("运行之后");
        }
    }

    private IEnumerator Herodeath()
    {
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2);
        showstart = true;
    }

    private IEnumerator Watiandreloading()
    {
        reloading = true;
        if (equipment == 1)
        {
            yield return new WaitForSeconds(1);
            bulletcount = 10;
        }
        else if (equipment == 2)
        {
            yield return new WaitForSeconds(2);
            bulletcount = 30;
        }
        else if (equipment == 3)
        {
            yield return new WaitForSeconds(2.0f);
            bulletcount = 5;
        }
        else if (equipment == 4)
        {
            yield return new WaitForSeconds(2.0f);
            bulletcount = 3;
        }
        else if (equipment == 5)
        {
            yield return new WaitForSeconds(2.0f);
            bulletcount = 3;
        }
        reloadingfinish = true;
        reloading = false;
    }


    private void Handreloding()
    {
        if (Input.GetKeyDown(KeyCode.R) && reloading == false)
        {
            StartCoroutine(coroutinereloading);
        }
        if (reloadingfinish == true)
        {
            StopCoroutine(coroutinereloading);
            coroutinereloading = Watiandreloading();
            reloadingfinish = false;
        }
    }
}
