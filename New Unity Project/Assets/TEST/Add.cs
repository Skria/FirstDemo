using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour {
    public GameObject menu;
    public GameObject hero;
    public Hero heroat;
    //记录是否已经弹窗
    public bool flag;

	// Use this for initialization
	void Start () {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
    }
	
	// Update is called once per frame
	void Update () {
		if(heroat.showstart == true && flag == false)
        {
            flag = true;
            addmenu();
        }
	}

    public void addmenu()
    {
        NGUITools.AddChild(gameObject,menu);
    }
}
