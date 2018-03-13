using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void exitgame()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }
}
