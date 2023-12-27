using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEB : MonoBehaviour
{
    
    public float t = 5.0f;
    PlayerControl playerControl;
    GroundControl groundControl;
    void Start()
    {
        playerControl = GameObject.Find("player").GetComponent<PlayerControl>();
        groundControl = GameObject.FindGameObjectWithTag("Ground1").GetComponent<GroundControl>();
        if (gameObject.tag == "EB")
        {
            Invoke("DEB", t);
            Destroy(gameObject, t);
        }
        else
        {
            Destroy(gameObject, 1.0f);
        }
        

    }

    public void DEB()
    {
        playerControl.isEB = false;
        //groundControl.countx = true;
    }
    public void DEA()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
