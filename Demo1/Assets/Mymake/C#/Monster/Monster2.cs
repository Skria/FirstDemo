using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster2 : Monsterbase {

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
        if (deathflag == false && manager.parse == false)
        {
            Stopturn();
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

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
}
