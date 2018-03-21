using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    public bool parse;
    public int count;
    public int level ;
    public bool producttank;
    public GameObject tank;
	// Use this for initialization
	void Start () {
        //count = 0;
        producttank = false;
        parse = false;
    }
	
	// Update is called once per frame
	void Update () {
        check();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC");
            Stopgame();
        }
    }

    public void check()
    {
        if(count <= 0)
        {
           if(level == 1)
            {
                Toplay2();
            }
           else if(level == 2)
            {
                Toplay3();
            }
            else if (level == 3)
            {
                Toplay4();
            }
            else if (level == 4)
            {
                Toplay5();
            }
            else if (level == 5)
            {
                if(producttank == false)
                {
                    producttank = true;
                    GameObject.Instantiate(tank, new Vector3(30,0,-10), this.transform.rotation);
                }
                else
                {
                    Debug.Log("通关啦");
                }
            }
        }
    }

    public void Stopgame()
    {
        if(parse == true)
        {
            Time.timeScale = 1;
            parse = false;
        }
        else
        {
            Time.timeScale = 0;
            parse = true;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Toplay1()
    {
        Application.LoadLevel("Play1");
    }

    public void Toplay2()
    {
        Application.LoadLevel("Play2");
    }

    public void Toplay3()
    {
        Application.LoadLevel("Play3");
    }

    public void Toplay4()
    {
        Application.LoadLevel("Play4");
    }

    public void Toplay5()
    {
        Application.LoadLevel("Play5");
    }

    public void Tohelp()
    {
        Application.LoadLevel("Help");
    }

    public void Tomenu()
    {
        Application.LoadLevel("Menu");
    }
}
