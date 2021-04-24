using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange2 : MonoBehaviour
{
    public Material material;
    Renderer rend;
    GameObject x;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "P2")
        {
            rend.sharedMaterial = material;
            
        }

    }

}