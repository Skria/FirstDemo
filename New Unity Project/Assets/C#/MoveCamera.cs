using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
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
        relativeposition = new Vector3(100, 2000, -500);
        this.transform.position = hero.transform.position + relativeposition;
    }
}
