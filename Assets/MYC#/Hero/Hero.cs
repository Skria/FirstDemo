using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	int hp;
	int equipment;
	float movespeed;

	// Use this for initialization
	void Start () {
		equipment = 1;
		hp = 100;
		movespeed = 20.0f;
	}

	void FixedUpdate() {
		rigidbody.velocity = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Changehp(int change) {
		hp += change;
	}

	public int Gethp() {
		return hp;
	}

	public int Getequ () {
		return equipment;
	}

	public void Changeequ(int equ) {
		equipment = equ;
	}


	public void Changespeed(float change) {
		movespeed += change;
	}

	public float Getspeed() {
		return movespeed;
	}
}
