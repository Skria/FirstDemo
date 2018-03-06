using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	int damage;
	float speed;
	// Use this for initialization
	void Start () {
		damage = 2;
		speed = 20.0f;
	}

	public void Changedamege(int change) {
		damage += change;
	}
	
	public int Getdamage(){
		return damage;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate (Vector3.forward*speed);

		//自我销毁模块

	}

	void OnTriggerEnter(Collider c)
	{
		//与怪物碰撞
		if (c.gameObject.layer == 11) 
		{
			GameObject.Destroy(this.gameObject);
		}
	}
}
