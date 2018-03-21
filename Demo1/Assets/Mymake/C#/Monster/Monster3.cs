using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3 : Monsterbase {


	
	// Update is called once per frame
	void Update () {
        if (deathflag == false && manager.parse == false)
        {
            Turntoaimup();
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

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
        if (dis < 5)
        {
            this.transform.LookAt(hero.transform);
        }
        Moveforward();
    }
}
