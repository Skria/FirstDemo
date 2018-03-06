using UnityEngine;
using System.Collections;

public class ProductProp : MonoBehaviour {


	public GameObject Prop1;
	public GameObject Prop21;
	public GameObject Prop22;
	public GameObject Prop3;
	private IEnumerator coroutine; 
	private Vector3 propposition;
	private Quaternion proprotation;
	GameObject heroobj;
	Hero hero;
	int kind;
	int equkind;
	float time;
	// Use this for initialization
	void Start () {
		heroobj = GameObject.FindGameObjectWithTag ("Hero");
		coroutine = Product(1.5f);
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time = time + Time.deltaTime;
		if (time >= 5) {
			propposition = heroobj.transform.position;
			propposition.x += 1000;
			proprotation = heroobj.transform.rotation;
			int randomprop = Random.Range(0, 100);
			Debug.Log ("random"+randomprop);
			kind = randomprop/33 + 1;
			randomprop = Random.Range(0, 100);
			equkind = randomprop/50 + 1;
			Debug.Log ("kind:"+kind+"equkind:"+equkind);
			StartCoroutine(coroutine);
			StopCoroutine(coroutine);
			time = 0.0f;
		}
	}

	private IEnumerator Product(float waitTime)
	{  
		Debug.Log ("xxxxxkind:"+kind+"equkind:"+equkind);
		if (kind == 1) {
			GameObject.Instantiate (Prop1,propposition, proprotation);
			Debug.Log ("k1");
		}
		else if (kind == 2) {
			if (equkind == 1) {
				GameObject.Instantiate (Prop21,propposition, proprotation);	
				Debug.Log ("k21");
			}
			else if (equkind == 2) {
				GameObject.Instantiate (Prop22,propposition, proprotation);	
				Debug.Log ("k22");
			}
		}
		else if (kind == 3) {
			Debug.Log ("k3");
			GameObject.Instantiate (Prop3,propposition, proprotation);	
		}
		yield return new WaitForSeconds (waitTime); 
	}
}
