using UnityEngine;
using System.Collections;

public class RecProp : MonoBehaviour {
	Hero hero;
	Changeequ changeequ;

	// Use this for initialization
	void Start () {
		hero = this.GetComponent<Hero> ();
		changeequ = this.GetComponent<Changeequ> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c) {
		if (c.gameObject.layer == 8) {
			Prop p = c.GetComponent<Prop> ();
			int kind = p.Getkind();
			Debug.Log ("道具种类:"+p.Getkind());
			switch (kind) {
			//加血包
			case 1:
				hero.Changehp(2);
				break;
			//武器包
			case 2:
				Debug.Log("激活武器");
				int equkind = p.Getequkind();
				if(equkind == 2) {
					changeequ.change2();
					Debug.Log("激活武器2");
				}
				else if (equkind == 3) {
					changeequ.change3();
					Debug.Log("激活武器3");
				}
				break;
			//鞋子
			case 3:
				hero.Changespeed(60.0f);
				Debug.Log(hero.Getspeed());
				break;
			}
		}
	}
}
