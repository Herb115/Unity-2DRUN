using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgControl : MonoBehaviour
{
    public float Speed = 0.2f;
    float timer;
    PlayerControl playerControl;
    void Start()
    {
        playerControl = GameObject.Find("player").GetComponent<PlayerControl>();
    }

    void Update()
    {
        if (playerControl.Hp <= 0)
        {
            Speed = 0;
        }
        timer += Time.deltaTime;
        if (timer >= 20f&& playerControl.Hp >= 0)
        {
            Speed = Speed + 0.04f;
            timer = 0f;
        }
        //背景持续滚动
        Vector2 v = transform.localPosition; 
        v.x -= Speed * Time.deltaTime;
        //判断如果出了屏幕，就移动到新位置
        if (v.x < -7.2f)
        {
            v.x += 7.2f * 2;
        }
        transform.localPosition = v;
    }
}
