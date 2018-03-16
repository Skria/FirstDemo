using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heroshoot : MonoBehaviour {

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
    //射击协程
    private IEnumerator coroutineshoot;

    //用于更换子弹模块
    public bool reloading;
    public int bulletcount;
    public bool reloadingfinish;
    private IEnumerator coroutinereloading;
    int equipment;

    Hero hero;

    void Start () {
        bulletcount = 10;
        hero = this.GetComponent < Hero>() ;
        
        fire = false;
        coroutineshoot = WaitAndShoot();
        coroutinereloading = Watiandreloading();
        reloadingfinish = false;
        reloading = false;

        flag1 = true;
        flag2 = true;
        flag3 = true;
        flag4 = true;
        flag5 = true;

    }
	
	void Update () {
        equipment = hero.equipment;
        Shoot();
        Handreloding();
        Changeequiment();
    }

    void Shoot()
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
            coroutineshoot = WaitAndShoot();
        }
    }

    private IEnumerator WaitAndShoot()
    {
        while (true)
        {
            Vector3 shootvec = this.transform.position;
            shootvec.y = shootvec.y + 0.5f;
            int equipment = hero.equipment;
            if (bulletcount >= 0)
            {
                bulletcount--;
            }
            if (equipment == 1 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet1, shootvec, this.transform.rotation);
                yield return new WaitForSeconds(0.2f);
            }
            else if (equipment == 2 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet2, shootvec, this.transform.rotation);
                yield return new WaitForSeconds(0.1f);
            }
            else if (equipment == 3 && bulletcount >= 0)
            {
                Quaternion temp1 = this.transform.rotation;
                Quaternion temp2 = this.transform.rotation;
                temp1.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y + 30, 0);
                temp2.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y - 30, 0);
                GameObject.Instantiate(bullet3, shootvec, this.transform.rotation);
                GameObject.Instantiate(bullet3, shootvec, temp1);
                GameObject.Instantiate(bullet3, shootvec, temp2);
                yield return new WaitForSeconds(0.2f);
            }
            else if (equipment == 4 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet4, shootvec, this.transform.rotation);
                yield return new WaitForSeconds(0.4f);
            }
            else if (equipment == 5 && bulletcount >= 0)
            {
                GameObject.Instantiate(bullet5, shootvec, this.transform.rotation);
                yield return new WaitForSeconds(0.4f);
            }
            if (bulletcount == -1 && reloading == false)
            {
                Debug.Log("自动换子弹");
                StartCoroutine(coroutinereloading);
            }
            if (reloadingfinish == true)
            {
                StopCoroutine(coroutinereloading);
                coroutinereloading = Watiandreloading();
                reloadingfinish = false;
            }
            yield return new WaitForSeconds(0.01f);
        }
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

    public void Changeequiment()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (equipment != 1 && flag1 == true)
            {
                bulletcount = 10;
                hero.equipment = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("xxxx我换了装备");
            if (equipment != 2 && flag2 == true)
            {
                bulletcount = 30;
                hero.equipment = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (equipment != 3 && flag3 == true)
            {
                bulletcount = 5;
                hero.equipment = 3;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (equipment != 4 && flag4 == true)
            {
                bulletcount = 3;
                hero.equipment = 4;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (equipment != 5 && flag5 == true)
            {
                bulletcount = 3;
                hero.equipment = 5;
            }
        }
    }
}
