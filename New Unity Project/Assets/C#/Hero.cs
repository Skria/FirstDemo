using System.Collections;
using UnityEngine;

public class Hero : Base {

 
    
    //用于武器切换
    bool flag1;//武器1
    bool flag2;//武器2
    bool flag3;//武器3
    //用于实例化子弹
    public GameObject bullet;
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
    void Start ()
    {
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
        deathflag = false;
        cdeathflag = false;
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
                equipment = 1;
            }
            else if (flag1 == false)
            {
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (equipment != 2 && flag2 == true)
            {
                equipment = 2;
            }
            else if (flag2 == false)
            {
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (equipment != 3 && flag3 == true)
            {
                equipment = 3;
            }
            else if (flag3 == false)
            {
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
            if (equipment == 0)
            {
                break;
                yield return new WaitForSeconds(waitTime);
            }
            else if (equipment == 1)
            {
                GameObject.Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), this.transform.rotation);
                yield return new WaitForSeconds(waitTime);
            }
            else if (equipment == 2)
            {
                GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }
            else if (equipment == 3)
            {
                Quaternion temp1 = this.transform.rotation;
                Quaternion temp2 = this.transform.rotation;
                temp1.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y + 30, 0);
                temp2.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y - 30, 0);
                GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation);
                GameObject.Instantiate(bullet, this.transform.position, temp1);
                GameObject.Instantiate(bullet, this.transform.position, temp2);
                yield return new WaitForSeconds(waitTime);
            }
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
        Debug.Log("运行");
        Collider collider = this.GetComponent<Collider>();
        collider.enabled = false;
        animator.SetBool("death", true);
        yield return new WaitForSeconds(2);
        showstart = true;
    }




}
