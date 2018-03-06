using UnityEngine;
using System.Collections;

public class Prop : MonoBehaviour {
	
	public int kind;
	public int equkind;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public int Getkind(){
		return kind;
	}
	
	void OnTriggerEnter(Collider c)
	{

	}

	public int Getequkind (){
		return equkind;
	}
	
}
