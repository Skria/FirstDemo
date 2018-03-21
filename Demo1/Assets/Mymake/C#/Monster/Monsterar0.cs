using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterar0 : Monster1 {
    //用于远程怪物射击
    public bool fire;
    public Bullet bullet;
    private IEnumerator coroutineshoot;
    // Use this for initialization
    new void Start () {
        base.Start();
        coroutineshoot = WaitAndShoot(2);
        fire = false;
    }
	
	// Update is called once per frame
	void Update () {
        //判断是否死亡
        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StopCoroutine(coroutineshoot);
            StartCoroutine(coroutine);
        }
        if (deathflag == false && manager.parse == false)
        {
            Archer();
        }
    }

    public void Archer()
    {
        Vector3 heroposition = hero.transform.position;
        Vector3 monsterposition = this.transform.position;
        //需要的位移
        Vector3 needposition = heroposition - monsterposition;
        float dis = Vector3.Distance(heroposition, monsterposition);
        if (dis > 15)
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
                if (fire == false && deathflag == false)
                {
                    StartCoroutine(coroutineshoot);
                    fire = true;
                }
            }
            else
            {
                if(fire == true)
                {
                    fire = false;
                    StopCoroutine(coroutineshoot);
                }
            }
        }
    }

    private IEnumerator WaitAndShoot(float waitTime)
    {
        while (true)
        {
            GameObject.Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), this.transform.rotation);
            yield return new WaitForSeconds(2.0f);
        }
    }


}
