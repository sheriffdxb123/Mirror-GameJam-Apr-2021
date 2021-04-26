using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange2 : MonoBehaviour
{
    public Material material;
    Renderer rend;
    GameObject x;
    public Animator anim2;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        anim2.enabled = false;
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "P2")
        {
            rend.sharedMaterial = material;
            anim2.enabled = true;
        }

    }

}