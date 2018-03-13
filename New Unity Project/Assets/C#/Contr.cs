using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr : MonoBehaviour {
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


    }
	
	// Update is called once per frame
	void Update () {
        maxhp = hero.maxhp;
        nowhp = hero.hp;
        show = nowhp / maxhp;
        slider.value = show;
    }
}
