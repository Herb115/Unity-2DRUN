using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour
{
    public int Hp = 2;
    public Text HpText;
    private Rigidbody2D rBody;
    private Animator ani;
    private bool isGround = false;
    GroundControl groundControl;
    public bool isEB=false;
    public int score=0;//记录得分信息
    public Text scoreText;

    public GameObject gb;
    public GameObject gs;
    public GameObject gb2;

    
    public void AB()//冲击
    {
        GameObject objB = Instantiate(gb, transform);
        isEB=true;
    }
    public void AS()//破坏
    {
        GameObject objS = Instantiate(gs, transform);
        
    }
    public void AB2()//冲刺
    {
        GameObject objB2 = Instantiate(gb2, transform);
    }
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;//得分更新
    }

    public void MinusHp(int value)
    {
        Hp -= value;
        UpdateHp();
    }
    public void AddHp(int value) 
    {  
        Hp += value; 
        UpdateHp(); 
    }
    public void UpdateHp() 
    {
        HpText.text = "Hp: " + Hp;//血量更新
    }
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        groundControl = GameObject.FindGameObjectWithTag("Ground1").GetComponent<GroundControl> ();
        UpdateScore();
        UpdateHp();
    }

    // Update is called once per frame
    void Update()
    {
        if(groundControl.charge==true&& groundControl.counts==true)
        {

            groundControl.counts = false;
            groundControl.countx = true;
            //rBody.gravityScale = 0;
            Vector2 vector = rBody.velocity;
            vector.y = 0;vector.x = 0;
            Collider2D[] cd = GetComponents<Collider2D>();
            
            foreach (Collider2D c in cd)
            {
                c.isTrigger = true;
            }
            
        }
        else
        {
            if(groundControl.countx == true)
            {
                groundControl.countx = false;
                
                //rBody.gravityScale = 0;
                Collider2D[] cd = GetComponents<Collider2D>();

                foreach (Collider2D c in cd)
                {
                    c.isTrigger = false;
                }
                Invoke("Rb", 3f);
            }
            
            
        }

        if(gameObject.transform.position.y<-30)
        {
            
                //Debug.Log("生成");
                Hp = 0;
                UpdateHp();
                GameOver();
            
        }

    }
    void Rb()
    {
        rBody.gravityScale = 2;
    }

    //跳跃
    public void Jump()
    {
        if (isGround==true && Hp>0)
        {
            //给一个力 方向*数值
             rBody.AddForce(Vector2.up * 400);
            //播放音效
            AudioManager.Instance.PlaySound("跳");
        }
        
    }

    //发生碰撞
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true;
            ani.SetBool("Jump", false);
        }
        //if (collision.collider.tag == "Bottom")
        //{
        //    Debug.Log("生成");
        //    Hp = 0;
        //    UpdateHp();
        //    GameOver();
        //}
    }
    //private void OnCollisionEnter3D(Collision collision)
    //{
    //    if (collision.collider.tag == "Bottom")
    //    {
    //        Debug.Log("生成");
    //        Hp = 0;
    //        UpdateHp();
    //        GameOver();
    //    }
    //}
    
//结束碰撞
private void OnCollisionExit2D(Collision2D collision)
    {
        //如果离开地面
        if(collision.collider.tag == "Ground")
        {
            isGround=false;
            //播放跳跃动画
            ani.SetBool("Jump", true);
        }
    }

    public void GameOver()
    {
        Collider2D[] cd = GetComponents<Collider2D>();

        foreach (Collider2D c in cd)
        {
            c.isTrigger = true;
        }
    }
}
