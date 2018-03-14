using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr : MonoBehaviour {
    //得到屏幕大小
    float width;
    float higt;
    //记录英雄屏幕坐标
    RectTransform hpposition;
    Vector3 heroposition;
    Camera camera;
    GameObject gamehero;
    Hero hero;
    UISlider slider = new UISlider();
    public float maxhp;
    public float nowhp;
    public float show;
	// Use this for initialization
	void Start () {
        gamehero = GameObject.FindGameObjectWithTag("Hero");
        hero = gamehero.GetComponent<Hero>();
        slider = gameObject.GetComponent<UISlider>();
        camera = Camera.main;
        hpposition = gameObject.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {

        //血条长度更新
        maxhp = hero.maxhp;
        nowhp = hero.hp;
        show = nowhp / maxhp;
        slider.value = show;

        //让血条跟随英雄移动
        heroposition = camera.WorldToScreenPoint(hero.transform.position);
        heroposition.z = 0;
        heroposition.x = heroposition.x - Camera.main.pixelWidth / 2 - 35;
        heroposition.y = heroposition.y - Camera.main.pixelHeight / 2 + 25;
        hpposition.anchoredPosition3D = heroposition;


    }
}
