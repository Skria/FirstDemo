using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	private Vector3  relativeposition;
	private GameObject hero;

	// Use this for initialization
	void Start () {
		relativeposition = new Vector3 (0, 3600, 0);
		hero = GameObject.FindGameObjectWithTag("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = hero.transform.position + relativeposition;

	}
}
