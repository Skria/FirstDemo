using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
    public int maxhp;
	public int hp;
	public float movespeed;
	// Use this for initialization
	void Start () {
	
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
	
	public void Changespeed(float change) {
		movespeed += change;
	}
	
	public float Getspeed() {
		return movespeed;
	}		
}
