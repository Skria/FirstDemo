using UnityEngine;
using System.Collections;

public class Prop1 : Prop {

	// Use this for initialization
	void Start () {
		kind = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c)
	{
		Debug.Log("道具说：" + c.gameObject.name + c.gameObject.layer);
		if (c.gameObject.layer == 9)// 是player层的节点撞的我, 可以在这里写一些播放特效的代码
		{
			Debug.Log("我是加血包");
			GameObject.Destroy(this.gameObject);
		}
	}
}
