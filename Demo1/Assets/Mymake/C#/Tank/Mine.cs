using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {
    public GameObject seeboom;
    GameObject hero;
    Hero heroat;
	// Use this for initialization
	void Start () {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider c)
    {
        Vector3 temp = gameObject.transform.position;
        if (c.gameObject.layer == 9)
        {
            bool invincibleflag = heroat.invincibleflag;
            if (invincibleflag == false)
            {
                heroat.hp = heroat.hp - 15;
            }
            GameObject.Instantiate(seeboom, temp, this.transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
