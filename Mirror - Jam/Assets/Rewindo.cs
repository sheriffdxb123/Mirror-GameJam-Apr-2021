using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewindo : MonoBehaviour
{
    public Animator g1;
    
    
    
    

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == ("P1"))
        {
            g1.Play("GreenReturn");

        }
    }
}
