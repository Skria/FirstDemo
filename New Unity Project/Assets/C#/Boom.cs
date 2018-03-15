using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour {
    //用来隐藏对象；
    Renderer m_ObjectRenderer;
    // Use this for initialization
    void Start () {
        Disappear();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Disappear()
    {
        m_ObjectRenderer = GetComponent<Renderer>();
        m_ObjectRenderer.enabled = false;
    }
}
