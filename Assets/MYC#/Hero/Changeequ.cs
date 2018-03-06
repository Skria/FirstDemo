using UnityEngine;
using System.Collections;

public class Changeequ : MonoBehaviour {

	bool flag1 = true;//武器1
	bool flag2 = false;//武器2
	bool flag3 = false;//武器3
	int equipment;
	Hero hero;

	// Use this for initialization
	void Start () {
		hero = this.GetComponent<Hero>();
		equipment = hero.Getequ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1))    
		{    
			Debug.Log("test");
			if(equipment != 1 && flag1 == true) {
				hero.Changeequ(1);
				equipment = 1;
				Debug.Log("携带1号武器");
			}   
			else if (flag1 == false){
				Debug.Log("武器1未激活");
			}
		}    
		
		if (Input.GetKeyDown (KeyCode.Alpha2))    
		{    
			if(equipment != 2 && flag2 == true) {
				hero.Changeequ(2);
				equipment = 2;
				Debug.Log("携带2号武器");
			} 
			else if (flag2 == false) {
				Debug.Log("武器2未激活");
			}
		}    
		
		if (Input.GetKeyDown (KeyCode.Alpha3))    
		{    
			if(equipment != 3 && flag3 == true) {
				hero.Changeequ(3);
				equipment = 3;
				Debug.Log("携带3号武器");
			}  
			else if (flag3 == false){
				Debug.Log("武器3未激活");
			}
		} 

	}

	public void change2() {
		flag2 = true;
	}

	public void change3() {
		flag3 = true;
	}
}
