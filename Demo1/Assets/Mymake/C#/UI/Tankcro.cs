using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankcro : MonoBehaviour {
    //得到屏幕大小
    float width;
    float higt;
    //记录英雄屏幕坐标
    Vector3 tankposition;
    Camera camera;
    GameObject gametank;
    Tank tank;
    UISlider slider = new UISlider();
    public float maxhp;
    public float nowhp;
    public float show;
    // Use this for initialization
    void Start()
    {
        gametank = GameObject.FindGameObjectWithTag("Tank");
        tank = gametank.GetComponent<Tank>();
        slider = gameObject.GetComponent<UISlider>();
        camera = Camera.main;
      
    }

    // Update is called once per frame
    void Update()
    {

        //血条长度更新
        maxhp = tank.maxhp;
        nowhp = tank.hp;
        show = nowhp / maxhp;
        slider.value = show;

        //让血条跟随英雄移动
        tankposition = camera.WorldToScreenPoint(tank.transform.position);
        tankposition.z = 0;
        tankposition.x = tankposition.x - Camera.main.pixelWidth / 2 ;
        tankposition.y = tankposition.y - Camera.main.pixelHeight / 2 +40;
        this.transform.localPosition = tankposition;
    }
}
