using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heromove : MonoBehaviour {

    public GameObject managerobject;
    public Manager manager;
    Hero hero;
    //动画管理
    Animator animator;
    //用于移动
    bool forward;
    bool back;
    bool left;
    bool right;
    // Use this for initialization
    void Start () {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        hero = gameObject.GetComponent<Hero>();
        animator = gameObject.GetComponent<Animator>();
        forward = false;
        back = false;
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hero.deathflag == false && manager.parse == false)
        {
            Move();
        }
    }


    private void Move()
    {
            float movespeed = hero.movespeed;
            if (Input.GetKeyDown(KeyCode.W))
            {
                forward = true;
                animator.SetBool("forward", true);

            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                back = true;
                animator.SetBool("back", true);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                left = true;
                animator.SetBool("left", true);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                right = true;
                animator.SetBool("right", true);
            }

            //抬起
            if (Input.GetKeyUp(KeyCode.W))
            {
                forward = false;
                animator.SetBool("forward", false);
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("back", false);
                back = false;
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                left = false;
                animator.SetBool("left", false);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                right = false;
                animator.SetBool("right", false);
            }


            //移动
            if (forward)
            {
                this.transform.Translate(0, 0, movespeed, Space.World);
            }

            if (back)
            {
                this.transform.Translate(0, 0, 0 - movespeed, Space.World);
            }

            if (left)
            {
                this.transform.Translate(-movespeed, 0, 0, Space.World);
            }

            if (right)
            {
                this.transform.Translate(movespeed, 0, 0, Space.World);
            }
    }
}
