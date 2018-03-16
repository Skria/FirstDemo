using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0 : Monsterbase {

    //开始旋转时候的角度
    private Quaternion start;
    //目标角度
    private Quaternion end;

    // Use this for initialization
    
	
	// Update is called once per frame
	void Update () {
        if (deathflag == false)
        {
            Turntoaim();
            Moveforward();
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
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
