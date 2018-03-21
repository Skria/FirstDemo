using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster5 : Monsterbase {
    //折线移动标志
    bool xmoveflag;
    bool zmoveflag;
    //用于策略6怪物行走方式的阶段指示
    private int level6;
    //策略6 2阶段移动方向指示
    bool level6up;
    // Use this for initialization
    new void Start () {
        base.Start();
        xmoveflag = true;
        zmoveflag = false;
        level6up = false;
        level6 = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (deathflag == false && manager.parse == false)
        {
            Movestrengthup();
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

    public void Movestrengthup()
    {
        Vector3 heroposition = hero.transform.position;
        Vector3 monsterposition = this.transform.position;
        //需要的位移
        Vector3 needposition = heroposition - monsterposition;
        float dis = Vector3.Distance(heroposition, monsterposition);

        if (dis <= 10 && level6 == 4)
        {
            Turntoaim();
            Moveforward();
        }
        else
        {
            Turntoaim();
            if (xmoveflag == true && (level6 == 1 || level6 == 4))
            {
                if (needposition.x <=5 && needposition.x >= -5)
                {
                    xmoveflag = false;
                    zmoveflag = true;
                    if (level6 == 1)
                    {
                        if (needposition.x <= 5 && needposition.x >= 0)
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
                if (needposition.z <= 5 && needposition.z >= -5)
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
                    if (needposition.x <= -10)
                    {
                        level6 = 3;
                    }
                    this.transform.Translate(movespeed, 0, 0, Space.World);
                }
                else
                {
                    if (needposition.x >= 10)
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
}
