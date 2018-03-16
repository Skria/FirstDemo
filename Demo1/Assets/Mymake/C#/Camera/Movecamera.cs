using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour
{

    private Vector3 relativeposition;
    GameObject hero;
    // Use this for initialization
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        Followhero();
    }

    void Followhero()
    {
        relativeposition = new Vector3(0, 44, -7);
        Vector3 temp = hero.transform.position;
        if (temp.x > 2300)
        {
            temp.x = 2300;
        }
        if (temp.x < -2000)
        {
            temp.x = -2000;
        }
        if (temp.z > 2200)
        {
            temp.z = 2200;
        }
        if (temp.z < -2800)
        {
            temp.z = -2800;
        }

        this.transform.position = temp + relativeposition;
    }
}
