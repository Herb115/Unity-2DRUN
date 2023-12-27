using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hinder : MonoBehaviour
{
    // Start is called before the first frame update
    GroundControl groundControl;
    PlayerControl playerControl;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("碰撞");
        if(playerControl.isEB==true)
        {
            if(collision.gameObject.tag == "Player")
            {
                //Debug.Log("销毁");
                playerControl.AddScore(20);
                playerControl.AS();
                Destroy(gameObject); 
            }
        }
        else if(collision.gameObject.tag=="Player"&&gameObject.tag=="Saw")
        {
            playerControl.MinusHp(1);
            if(playerControl.Hp<=0)
            {
                playerControl.GameOver();
            }
        }
    }
    void Start()
    {
        
        groundControl = GameObject.FindGameObjectWithTag("Ground1").GetComponent<GroundControl>();
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
