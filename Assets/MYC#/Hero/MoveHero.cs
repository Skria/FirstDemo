using UnityEngine;
using System.Collections;

public class MoveHero : MonoBehaviour {
	
	float movespeed;
	bool wkey = false;
	bool skey = false;
	bool akey = false;
	bool dkey = false;
	Hero hero;
	
	// Use this for initialization
	void Start () {
		wkey = false;
		skey = false;
		akey = false;
		dkey = false;
		hero = this.GetComponent<Hero> ();
	}
	
	// Update is called once per frame
	void Update () {
		float movespeed = hero.Getspeed();

		//按键
		if (Input.GetKeyDown (KeyCode.W))    
		{    
			wkey = true;   
		}    
		
		if (Input.GetKeyDown (KeyCode.S))    
		{    
			skey = true;     
		}    
		
		if (Input.GetKeyDown (KeyCode.A))    
		{    
			akey = true;      
		}    
		
		if (Input.GetKeyDown (KeyCode.D))    
		{    
			dkey = true;      
		}    
		
		//抬起
		if (Input.GetKeyUp (KeyCode.W))    
		{    
			wkey = false;      
		}    
		
		if (Input.GetKeyUp (KeyCode.S))    
		{    
			skey = false;    
		}    
		
		if (Input.GetKeyUp (KeyCode.A))    
		{    
			akey = false;  
		}    
		
		if (Input.GetKeyUp (KeyCode.D))    
		{    
			dkey = false;      
		}    
		
		
		//移动
		if (wkey)    
		{    
			this.transform.Translate(0,0,movespeed,Space.World);     
		}    
		
		if (skey)    
		{    
			this.transform.Translate(0,0,0-movespeed,Space.World);
		}    
		
		if (akey)    
		{    
			this.transform.Translate(-movespeed,0,0,Space.World);   
		}    
		
		if (dkey)    
		{    
			this.transform.Translate(movespeed,0,0,Space.World);      
		}    
		
		
	}
}
