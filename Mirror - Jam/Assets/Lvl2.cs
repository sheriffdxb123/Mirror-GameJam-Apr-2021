using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lvl2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Finish"))
        {
            SceneManager.LoadScene("L2");
        }
    }
}
