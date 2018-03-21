using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4 : Monsterbase {
    int count5;

    // Use this for initialization
    new void Start () {
        base.Start();
        count5 = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if (deathflag == false && manager.parse == false)
        {
            Stopandrun();
        }

        if (deathflag == true && cdeathflag == false)
        {
            cdeathflag = true;
            StartCoroutine(coroutine);
        }
    }

    public void Stopandrun()
    {
        count5 = count5 % 150;
        if (count5 < 50)
        {
            animator.SetBool("run", true);
            Turntoaim();
            Moveforward();
        }
        else
        {
            animator.SetBool("run", false);
        }
        count5++;
    }
}
