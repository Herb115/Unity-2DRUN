using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GroundControl : MonoBehaviour
{
    public float Speed = 2f;
    float timer;
    //地面预设体
    public GameObject[] Grounds;
    PlayerControl playerControl;

    //public double far=0;
    public bool charge=false;//冲锋标记//
    public bool counts=false;//确认计数-生成
    public bool countx=false;//确认计数-销毁
    float timerCharge=0.0f;

    
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("player").GetComponent<PlayerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControl.Hp<=0)
        {
            Speed = 0;
        }
        if (playerControl.Hp >= 0&&Input.GetKeyDown(KeyCode.E))
        {
            sprint();
        }
        timer += Time.deltaTime;
        if (timer >=20f && playerControl.Hp >= 0)
        {
            Speed = Speed+0.4f;
            timer = 0f;
        }
        if(playerControl.score!=0&&playerControl.score%100==0 && charge == false)
        {
            if(playerControl.isEB==false)
            {
                playerControl.AB();
                counts =true;
                //Debug.Log("生成"); 
            }
            
            charge = true;
            //Speed = Speed+5f;
            
        }
        if(charge==true)
        {
            
            timerCharge += Time.deltaTime;
            if (timer>=5f)
            {
                //Speed = Speed - 5f;
                charge = false;
                timerCharge = 0f;
                //playerControl.isEB = true;
                

            }
        }
        Vector2 v = transform.localPosition;
        v.x -= Speed * Time.deltaTime;
        if (v.x < -7.2f)
        {
            v.x += 7.2f * 2;
            //切换地形
            //删除旧地形
            foreach (Transform trans in transform)
            {
                Destroy(trans.gameObject);
            }
            //创建新地形
            Instantiate(Grounds[Random.Range(0,Grounds.Length)],transform);
        }
        transform.localPosition = v;
    }

    public void sprint()
    {
        Speed += 5f;
        Invoke("notsprint", 1f);
        playerControl.AB2();
    }
    public void notsprint()
    {
        Speed -= 5f;
    }
}
