using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControl : MonoBehaviour
{
    PlayerControl playerControl;
    void Start()
    {
        playerControl= GameObject.Find("player").GetComponent<PlayerControl>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(gameObject.tag=="Green"&&playerControl.Hp<3&&playerControl.Hp>0)
            {
                playerControl.AddHp(1);
            }
            AudioManager.Instance.PlaySound("金币");
            Destroy(gameObject);
            playerControl.AddScore(10);//金币加分10
        }
    }
}
