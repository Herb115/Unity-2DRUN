using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    PlayerControl playerControl;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            //Debug.Log("生成");
            playerControl.Hp = 0;
            playerControl.UpdateHp();
            playerControl.GameOver();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.Find("player").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
