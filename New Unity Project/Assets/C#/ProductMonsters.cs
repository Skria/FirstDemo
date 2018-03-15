using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductMonsters : MonoBehaviour {

    public GameObject Monster1;
    public GameObject Monster2;
    public GameObject Monster3;
    public GameObject Monster4;
    public GameObject Monster5;
    public GameObject Monster6;
    public GameObject Monster7;
    public GameObject Monster8;
    public GameObject Monster9;
    public GameObject Monster10;
    public GameObject Monster11;
    public GameObject Monster12;
    public GameObject Monsterar1;
    public GameObject Monsterar2;
    GameObject hero;
    // Use this for initialization
    void Start () {
        hero = GameObject.FindGameObjectWithTag("Hero");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(hero.transform.position);
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
    public void Productmonster6()
    {
        GameObject.Instantiate(Monster6, this.transform.position, this.transform.rotation);
    }

    public void Productmonster7()
    {
        GameObject.Instantiate(Monster7, this.transform.position, this.transform.rotation);
    }

    public void Productmonster8()
    {
        GameObject.Instantiate(Monster8, this.transform.position, this.transform.rotation);
    }

    public void Productmonster9()
    {
        GameObject.Instantiate(Monster9, this.transform.position, this.transform.rotation);
    }
    public void Productmonster10()
    {
        GameObject.Instantiate(Monster10, this.transform.position, this.transform.rotation);
    }
    public void Productmonster11()
    {
        GameObject.Instantiate(Monster11, this.transform.position, this.transform.rotation);
    }
    public void Productmonster12()
    {
        GameObject.Instantiate(Monster12, this.transform.position, this.transform.rotation);
    }

    public void Productmonsterar1()
    {
        GameObject.Instantiate(Monster6, this.transform.position, this.transform.rotation);
    }

    public void Productmonsterar2()
    {
        GameObject.Instantiate(Monster6, this.transform.position, this.transform.rotation);
    }

    public void Productmonstergrop1()
    {
        for(int i =0; i < 3; i++)
        {
            for(int j = 0; j<2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 150;
                temp.z = temp.z + j * 150;
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
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
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
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
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
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
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
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster5, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop6()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster6, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop7()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster7, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop8()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster8, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop9()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster9, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop10()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster10, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop11()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster11, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergrop12()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monster12, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergropar1()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monsterar1, temp, this.transform.rotation);
            }
        }
    }

    public void Productmonstergropar2()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 temp = this.transform.position;
                temp.x = temp.x + i * 100;
                temp.z = temp.z + j * 100;
                GameObject.Instantiate(Monsterar2, temp, this.transform.rotation);
            }
        }
    }
   

}
