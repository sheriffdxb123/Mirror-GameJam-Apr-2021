using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind2 : MonoBehaviour
{
    public Animator g2;
    public Movement mv;
    public bool zz;
    public bool ff;
    private void Start()
    {
        zz = false;
        ff = false;
    }
    void Update()
    {
       
    }

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == ("P1"))
        {
            g2.Play("GreenUp1(lvl4)");
            
        }
      
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == ("ex"))
        {
            Debug.Log("hello");
            ff = true;
        }
    }
}
