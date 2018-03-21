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
        relativeposition = new Vector3(0, 40, -7);
        Vector3 temp = hero.transform.position;
        if (temp.x > 24)
        {
            temp.x = 24;
        }
        if (temp.x < -22)
        {
            temp.x = -22;
        }
        if (temp.z > 26)
        {
            temp.z = 26;
        }
        if (temp.z < -34)
        {
            temp.z = -34;
        }

        this.transform.position = temp + relativeposition;
    }
}
