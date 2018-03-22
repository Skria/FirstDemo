using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parse : MonoBehaviour {
    public GameObject father;
    public GameObject managerobject;
    public Manager manager;
    // Use this for initialization
    void Start () {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        father = GameObject.FindGameObjectWithTag("Parse");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resume()
    {
        manager.parse = false;
        manager.parseui = false;
        Time.timeScale = 1;
        GameObject.Destroy(father);
    }
    public void Restart()
    {
        if(manager.level == 1)
        {
            manager.parse = false;
            manager.parseui = false;
            Time.timeScale = 1;
            Toplay1();
        }
        else if (manager.level == 2)
        {
            manager.parse = false;
            manager.parseui = false;
            Time.timeScale = 1;
            Toplay2();
        }
        else if (manager.level == 3)
        {
            manager.parse = false;
            manager.parseui = false;
            Time.timeScale = 1;
            Toplay3();
        }
        else if (manager.level == 4)
        {
            manager.parse = false;
            manager.parseui = false;
            Time.timeScale = 1;
            Toplay4();
        }
        else if (manager.level == 5)
        {
            manager.parse = false;
            manager.parseui = false;
            Time.timeScale = 1;
            Toplay5();
        }
        
    }
    public void Mainmenu()
    {
        Time.timeScale = 1;
        Tomenu();
    }

    public void Toplay1()
    {
        SceneManager.LoadScene("Play1");
    }

    public void Toplay2()
    {
        SceneManager.LoadScene("Play2");
    }

    public void Toplay3()
    {
        SceneManager.LoadScene("Play3");
    }

    public void Toplay4()
    {
        SceneManager.LoadScene("Play4");
    }

    public void Toplay5()
    {
        SceneManager.LoadScene("Play5");
    }

    public void Tomenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
