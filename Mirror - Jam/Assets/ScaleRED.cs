using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRED : MonoBehaviour
{
    GameObject m_Cubes;
    public Material color;
    Vector3 ScaleChange;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        ScaleChange = new Vector3(3.3184f,1,1);

        if (m_Cubes.GetComponent<Renderer>().material == color)
        {
            transform.localScale = ScaleChange;
        }

    }
}
