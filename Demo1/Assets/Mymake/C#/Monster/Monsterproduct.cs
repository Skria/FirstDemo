using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsterproduct : MonoBehaviour {
    public GameObject Tank;
    public GameObject managerobject;
    public Manager manager;
    public GameObject Monster0;
    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public GameObject Monster4;
    public GameObject Monster5;
    public GameObject Monsterar0;

    public GameObject home0;
    public GameObject home1;
    public GameObject home2;
    public GameObject home3;
    public GameObject home4;
    public GameObject home5;
    public GameObject homear0;

    GameObject hero;
    void Start()
    {
        managerobject = GameObject.FindGameObjectWithTag("Manager");
        manager = managerobject.GetComponent<Manager>();
        manager.count = manager.count + 1;
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(hero.transform.position);
    }
    public void Producttank()
    {
        GameObject.Instantiate(Tank, this.transform.position, this.transform.rotation);
    }

    public void Productmonster0()
    {
        GameObject.Instantiate(Monster0, this.transform.position, this.transform.rotation);
    }

    public void Productmonster1()
    {
        GameObject.Instantiate(Monster1, this.transform.position, this.transform.rotation);
    }

    public void Productmonster2()
    {
        GameObject.Instantiate(Monster2, this.transform.position, this.transform.rotation);
    }
    public void Productmonster3()
    {
        GameObject.Instantiate(Monster3, this.transform.position, this.transform.rotation);
    }
    public void Productmonster4()
    {
        GameObject.Instantiate(Monster4, this.transform.position, this.transform.rotation);
    }
    public void Productmonster5()
    {
        GameObject.Instantiate(Monster5, this.transform.position, this.transform.rotation);
    }

    public void Productmonsterar0()
    {
        GameObject.Instantiate(Monsterar0, this.transform.position, this.transform.rotation);
    }

    public void Producthome0()
    {
        GameObject.Instantiate(home0, this.transform.position, this.transform.rotation);
    }

    public void Producthome1()
    {
        GameObject.Instantiate(home1, this.transform.position, this.transform.rotation);
    }

    public void Producthome2()
    {
        GameObject.Instantiate(home2, this.transform.position, this.transform.rotation);
    }

    public void Producthome3()
    {
        GameObject.Instantiate(home3, this.transform.position, this.transform.rotation);
    }

    public void Producthome4()
    {
        GameObject.Instantiate(home4, this.transform.position, this.transform.rotation);
    }

    public void Producthome5()
    {
        GameObject.Instantiate(home5, this.transform.position, this.transform.rotation);
    }
    public void Producthomear0()
    {
        GameObject.Instantiate(homear0, this.transform.position, this.transform.rotation);
    }

    public void Productmonstergrop0()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 7;
                temp.z = temp.z + j * 7;
                GameObject.Instantiate(Monster0, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop1()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 7;
                temp.z = temp.z + j * 7;
                GameObject.Instantiate(Monster1, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop2()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 7;
                temp.z = temp.z + j * 7;
                GameObject.Instantiate(Monster2, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop3()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 7;
                temp.z = temp.z + j * 7;
                GameObject.Instantiate(Monster3, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop4()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 7;
                temp.z = temp.z + j * 7;
                GameObject.Instantiate(Monster4, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop5()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 7;
                temp.z = temp.z + j * 7;
                GameObject.Instantiate(Monster5, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergropar0()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 7;
                temp.z = temp.z + j * 7;
                GameObject.Instantiate(Monsterar0, temp, this.transform.rotation);
            }
        }
    }



    public void Productover()
    {
        manager.count = manager.count - 1;
        GameObject.Destroy(this.gameObject);
    }
}
