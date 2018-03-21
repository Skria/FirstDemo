using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
    public GameObject seeboom;
    GameObject hero;
    Hero heroat;
    public GameObject managerobject;
    public Manager manager;
    // Use this for initialization
    void Start () {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
	}
	
	// Update is called once per frame
	void Update () {
        if(manager.parse == false)
        {
            this.transform.Translate(Vector3.forward * 0.5f);
        }
    }
    void OnTriggerEnter(Collider c)
    {
        //与墙壁碰撞
        if (c.gameObject.layer == 8)
        {
            Showboom();
            //胶囊体碰撞实现爆炸效果
            GameObject.Destroy(this.gameObject);
        }

        //与英雄相撞
        if (c.gameObject.layer == 9)
        {
            Showboom();
            if (heroat.hp - 15 <= 0)
            {
                heroat.hp = 0;
            }
            else
            {
                heroat.hp = heroat.hp - 15;
            }
            GameObject.Destroy(this.gameObject);
        }
    }

    private void Showboom()
    {
        GameObject.Instantiate(seeboom, gameObject.transform.position, gameObject.transform.rotation);
    }

}
