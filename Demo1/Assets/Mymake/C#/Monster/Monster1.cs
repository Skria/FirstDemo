using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : Monsterbase {
    //折线移动标志
    public bool xmoveflag;
    public bool zmoveflag;

    // Use this for initialization
    public new void Start () {
        base.Start();
        xmoveflag = true;
        zmoveflag = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (deathflag == false && manager.parse == false)
        {
            Movestrength();
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

    public void Movestrength()
    {
        Vector3 heroposition = hero.transform.position;
        Vector3 monsterposition = this.transform.position;
        //需要的位移
        Vector3 needposition = heroposition - monsterposition;
        float dis = Vector3.Distance(heroposition, monsterposition);
        if (dis <= 5)
        {
            this.transform.LookAt(hero.transform);
            Turntoaim();
            Moveforward();
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
        }
    }
}
