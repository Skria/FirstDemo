using UnityEngine;
using System.Collections;

public class Custom : MonoBehaviour {

	public int hp;
	public float movespeed;
	public float overtime = 0;
	// Use this for initialization
	void Start () {

	}
	void FixedUpdate() {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Changehp(int change) {
		hp += change;
	}
	
	public int Gethp(){
		return hp;
	}

	void OnTriggerEnter(Collider c)
	{
		//与子弹层碰撞
		if (c.gameObject.layer == 10) 
		{
			Bullet bullet = c.GetComponent<Bullet>();
			hp -= bullet.Getdamage();
			Debug.Log("怪物说hp：" +hp);
			if(hp<=0){
				collider.enabled = false;
			}
		}
	}



}
