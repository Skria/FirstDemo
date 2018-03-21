using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster0 : Monsterbase {

   
    // Use this for initialization
    
	
	// Update is called once per frame
	 void Update () {
        if (deathflag == false && manager.parse == false)
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
 
}
