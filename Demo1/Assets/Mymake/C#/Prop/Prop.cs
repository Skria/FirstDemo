using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public GameObject seefx;
    public GameObject hero;
    public Hero heroat;
    public int kind;
    public int equ_kind;
    public GameObject fastbullet;
    public GameObject slowbullet;
    private IEnumerator coroutineturnshoot;
    private IEnumerator coroutineinvincible;
    //用来隐藏对象；
    Renderer m_ObjectRenderer;
    // Use this for initialization
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        heroat = hero.GetComponent<Hero>();
        coroutineturnshoot = Turnshoot();
        coroutineinvincible = Invinciblehero();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == 9)// 是player层的节点撞的我, 可以在这里写一些播放特效的代码
        {
            switch (kind)
            {
                case 1:
                    //血包
                    Showfx();
                    if (heroat.hp + 20 >= heroat.maxhp)
                    {
                        heroat.hp = heroat.maxhp;
                    }
                    else
                    {
                        heroat.hp += 20;
                    }
                    GameObject.Destroy(this.gameObject);
                    break;
                case 2:
                    //鞋子
                    if (heroat.movespeed >= 0.3f)
                    {
                        ;
                    }
                    else
                    {
                        heroat.movespeed += 0.05f;
                    }
                    GameObject.Destroy(this.gameObject);
                    break;
                case 3:
                    //360度射击子弹
                    Quaternion temp = new Quaternion();
                    for (int i = 0; i < 18; i++)
                    {
                        temp.eulerAngles = new Vector3(0, i * 20, 0);
                        GameObject.Instantiate(slowbullet, this.transform.position, temp);
                    }
                    GameObject.Destroy(this.gameObject);
                    break;
                case 4:
                    //旋转射击道具
                    Disappear();
                    StartCoroutine(coroutineturnshoot);
                    break;
                case 5:
                    //无敌
                    Disappear();
                    StartCoroutine(coroutineinvincible);
                    break;
            }
        }
    }

    public int Getkind()
    {
        return kind;
    }

    public int Getequkind()
    {
        return equ_kind;
    }

    private IEnumerator Turnshoot()
    {
        Quaternion temp = new Quaternion();
        for (int i = 0; i < 54; i++)
        {
            float turn = (i * 20) % 360;
            temp.eulerAngles = new Vector3(0, turn, 0);
            GameObject.Instantiate(slowbullet, this.transform.position, temp);
            yield return new WaitForSeconds(0.05f);
        }
        GameObject.Destroy(this.gameObject);
    }

    private IEnumerator Invinciblehero()
    {
        heroat.invincibleflag = true;
        Showfx();
        yield return new WaitForSeconds(5);
        heroat.invincibleflag = false;
        GameObject.Destroy(this.gameObject);
    }

    private void Disappear()
    {
        m_ObjectRenderer = GetComponent<Renderer>();
        m_ObjectRenderer.enabled = false;
    }


    private void Showfx()
    {
        GameObject tempsee;
        tempsee = GameObject.Instantiate(seefx, hero.transform.position, hero.transform.rotation);
        tempsee.transform.parent = hero.transform;
    }


}
