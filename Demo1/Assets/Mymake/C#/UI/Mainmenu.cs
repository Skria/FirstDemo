using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {
    GameObject countgame;
    Maincount count;
    GameObject start;
    GameObject help;
    GameObject exit;

    GameObject lv1;
    GameObject lv2;
    GameObject lv3;
    GameObject lv4;
    GameObject lv5;
    GameObject back;

    private IEnumerator coroutinebackstart;
    private IEnumerator coroutinebackhelp;
    private IEnumerator coroutinebackexit;
    private IEnumerator coroutinebackmenu;

    private IEnumerator coroutinebacklv1;
    private IEnumerator coroutinebacklv2;
    private IEnumerator coroutinebacklv3;
    private IEnumerator coroutinebacklv4;
    private IEnumerator coroutinebacklv5;
    private IEnumerator coroutinebackback;
    private IEnumerator coroutinebackchoose;

    private IEnumerator coroutinegostart;
    private IEnumerator coroutinegohelp;
    private IEnumerator coroutinegoexit;
    private IEnumerator coroutinegomenu;

    private IEnumerator coroutinegolv1;
    private IEnumerator coroutinegolv2;
    private IEnumerator coroutinegolv3;
    private IEnumerator coroutinegolv4;
    private IEnumerator coroutinegolv5;
    private IEnumerator coroutinegoback;
    private IEnumerator coroutinegochoose;
    // Use this for initialization
    void Start () {
        countgame = GameObject.FindGameObjectWithTag("Count");
        count = countgame.GetComponent<Maincount>();

        start = GameObject.FindGameObjectWithTag("Play");
        help = GameObject.FindGameObjectWithTag("Help");
        exit = GameObject.FindGameObjectWithTag("Exit");

        lv1 = GameObject.FindGameObjectWithTag("Level1");
        lv2 = GameObject.FindGameObjectWithTag("Level2");
        lv3 = GameObject.FindGameObjectWithTag("Level3");
        lv4 = GameObject.FindGameObjectWithTag("Level4");
        lv5 = GameObject.FindGameObjectWithTag("Level5");
        back = GameObject.FindGameObjectWithTag("Back");
        coroutinebackstart = Backbutton(start);
        coroutinebackhelp = Backbutton(help);
        coroutinebackexit = Backbutton(exit);
        coroutinebackmenu = Startbackmenu();

        coroutinebacklv1 = Backbutton(lv1);
        coroutinebacklv2 = Backbutton(lv2);
        coroutinebacklv3 = Backbutton(lv3);
        coroutinebacklv4 = Backbutton(lv4);
        coroutinebacklv5 = Backbutton(lv5);
        coroutinebackback = Backbutton(back);
        coroutinebackchoose = Startbackchoose();

        coroutinegostart = Gobutton(start);
        coroutinegohelp = Gobutton(help);
        coroutinegoexit = Gobutton(exit);
        coroutinegomenu = Startgomenu();

        coroutinegolv1 = Gobutton(lv1);
        coroutinegolv2 = Gobutton(lv2);
        coroutinegolv3 = Gobutton(lv3);
        coroutinegolv4 = Gobutton(lv4);
        coroutinegolv5 = Gobutton(lv5);
        coroutinegoback = Gobutton(back);
        coroutinegochoose = Startgochoose();

        StartCoroutine(coroutinegomenu);
    }
	
	// Update is called once per frame
	void Update () {
        if(count.leveling == 0)
        {
            if (start.transform.localPosition.x >= 0)
            {
                StopCoroutine(coroutinegostart);
            }
            if (help.transform.localPosition.x >= -89)
            {
                StopCoroutine(coroutinegohelp);
            }
            if (exit.transform.localPosition.x >= -162)
            {
                StopCoroutine(coroutinegoexit);
            }
        }

		if(count.leveling == 2)
        {
            if(start.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebackstart);
            }
            if (exit.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebackexit);
            }
            if (help.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebackhelp);
            }

            if(lv1.transform.localPosition.x >= 10)
            {
                StopCoroutine(coroutinegolv1);
               
            }
            if (lv2.transform.localPosition.x >= -21)
            {
                StopCoroutine(coroutinegolv2);
            }
            if (lv3.transform.localPosition.x >= -86)
            {
                StopCoroutine(coroutinegolv3);
            }
            if (lv4.transform.localPosition.x >= -170)
            {
                StopCoroutine(coroutinegolv4);
            }
            if (lv5.transform.localPosition.x >= -226)
            {
                StopCoroutine(coroutinegolv5);
            }
            if (back.transform.localPosition.x >= -129)
            {
                StopCoroutine(coroutinegoback);
            }
        }

        if(count.leveling == 4)
        {
            if (start.transform.localPosition.x >= 0)
            {
                StopCoroutine(coroutinegostart);
            }
            if (help.transform.localPosition.x >= -89)
            {
                StopCoroutine(coroutinegohelp);
            }
            if (exit.transform.localPosition.x >= -162)
            {
                StopCoroutine(coroutinegoexit);
            }


            if (lv1.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebacklv1);
               
            }
            if (lv2.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebacklv2);
            }
            if (lv3.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebacklv3);
            }
            if (lv4.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebacklv4);
            }
            if (lv5.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebacklv5);
            }
            if (back.transform.localPosition.x <= -510)
            {
                StopCoroutine(coroutinebackback);
            }
        }
	}

   

    public void Buttonstart()
    {
        Debug.Log("我运行啦");
        coroutinebackstart = Backbutton(start);
        coroutinebackhelp = Backbutton(help);
        coroutinebackexit = Backbutton(exit);
        coroutinebackmenu = Startbackmenu();
        coroutinegolv1 = Gobutton(lv1);
        coroutinegolv2 = Gobutton(lv2);
        coroutinegolv3 = Gobutton(lv3);
        coroutinegolv4 = Gobutton(lv4);
        coroutinegolv5 = Gobutton(lv5);
        coroutinegoback = Gobutton(back);
        coroutinegochoose = Startgochoose();
        StartCoroutine(coroutinebackmenu);
        StartCoroutine(coroutinegochoose);
        count.leveling = 2;
    }

    public void Buttonhelp()
    {

        StartCoroutine(coroutinebackmenu);
        count.leveling = 2;
    }

    public void Buttonexit()
    {
        Exitgame();
    }

    public void Buttonback()
    {
        Debug.Log("我运行啦");
        coroutinebacklv1 = Backbutton(lv1);
        coroutinebacklv2 = Backbutton(lv2);
        coroutinebacklv3 = Backbutton(lv3);
        coroutinebacklv4 = Backbutton(lv4);
        coroutinebacklv5 = Backbutton(lv5);
        coroutinebackback = Backbutton(back);
        coroutinebackchoose = Startbackchoose();
        coroutinegostart = Gobutton(start);
        coroutinegohelp = Gobutton(help);
        coroutinegoexit = Gobutton(exit);
        coroutinegomenu = Startgomenu();
        StartCoroutine(coroutinebackchoose);
        StartCoroutine(coroutinegomenu);
        count.leveling = 4;
    }

    public IEnumerator Startbackmenu()
    {
        StartCoroutine(coroutinebackstart);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinebackhelp);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinebackexit);
    }

    public IEnumerator Startbackchoose()
    {
        StartCoroutine(coroutinebacklv1);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinebacklv2);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinebacklv3);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinebacklv4);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinebacklv5);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinebackback);
    }

    public IEnumerator Startgomenu()
    {
        StartCoroutine(coroutinegostart);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinegohelp);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinegoexit);
    }

    public IEnumerator Startgochoose()
    {
        StartCoroutine(coroutinegolv1);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinegolv2);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinegolv3);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinegolv4);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinegolv5);
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(coroutinegoback);
    }

    private IEnumerator Backbutton(GameObject tempgame)
    {
        Vector3 temp = tempgame.transform.localPosition;
        while (true)
        {
            temp.x -= 20;
            tempgame.transform.localPosition = temp;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator Gobutton(GameObject tempgame)
    {
        Debug.Log("Gobutton");
        Vector3 temp = tempgame.transform.localPosition;
        while (true)
        {
            temp.x += 20;
            tempgame.transform.localPosition = temp;
            yield return new WaitForSeconds(0.01f);
        }
    }


    public void Tohelp()
    {
        SceneManager.LoadScene("Help");
    }

    public void Exitgame()
    {
        Debug.Log("退出游戏");
        Application.Quit();
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
}
