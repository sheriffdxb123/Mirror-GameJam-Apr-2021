using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public Material material;
    Renderer rend;
    public GameObject x;
    public bool d;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        d = false;
        anim.enabled = false;
    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "P1")
        {
            rend.sharedMaterial = material;
            d = true;
            anim.enabled = true;
            //Debug.Log("Hit!");
            
        }
    }

}

