using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public Material material;
    Renderer rend;
    public GameObject x;
    public Animation Anim;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        Anim.enabled = false;     

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "P1")
        {
            rend.sharedMaterial = material;
            // x.transform.localScale = new Vector3(4f, 1, 1);
            Anim.enabled = true;
        }

    }

}

