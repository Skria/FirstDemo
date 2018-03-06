using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	
	bool fire = false;
	public GameObject bullet;
	private Vector3 heroposition;
	private Quaternion herorotation;
	private IEnumerator coroutine;  
	private float waittime = 0.2f;
	int equkind=1;
	GameObject hero;
	Hero heroat;
	// Use this for initialization
	void Start () {
		coroutine = WaitAndShoot(waittime);
		hero = GameObject.FindGameObjectWithTag ("Hero");
	}
	
	// Update is called once per frame
	void Update () {
		heroposition = hero.transform.position;
		herorotation = hero.transform.rotation;
		heroat = hero.GetComponent<Hero>();
		equkind = heroat.Getequ();
		if (Input.GetMouseButtonDown(0)) {  
			if (fire == true){

			}
			else{
				fire = true;
				StartCoroutine (coroutine);
			}
		}  
		if (Input.GetMouseButtonUp(0)) {
			fire = false;
		}  


		if (fire == false ){
			StopCoroutine(coroutine);
			coroutine = WaitAndShoot(waittime);
		}
	}

	private IEnumerator WaitAndShoot(float waitTime)
	{  
		while (true) {
			if (equkind == 0) {
				break;
				yield return new WaitForSeconds (waitTime); 
			}
			else if (equkind == 1) {
				GameObject.Instantiate (bullet, heroposition, herorotation);
				yield return new WaitForSeconds (waitTime); 
			}
			else if (equkind == 2) {
				GameObject.Instantiate (bullet, heroposition, herorotation);
				yield return new WaitForSeconds (0.1f); 
			}
			else if(equkind == 3) {
				Quaternion temp1 = herorotation;
				Quaternion temp2 = herorotation;
				temp1.eulerAngles = new Vector3(0,herorotation.eulerAngles.y+30,0);
				temp2.eulerAngles = new Vector3(0,herorotation.eulerAngles.y-30,0);
				GameObject.Instantiate (bullet, heroposition, herorotation);
				GameObject.Instantiate (bullet, heroposition, temp1);
				GameObject.Instantiate (bullet, heroposition, temp2);
				yield return new WaitForSeconds (waitTime);
			}
		}
	}  
}
