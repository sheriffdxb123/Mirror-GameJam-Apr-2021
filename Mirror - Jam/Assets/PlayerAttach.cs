using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{
    public GameObject Player2;
    public GameObject Player1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player2)
        {
            Player2.transform.parent = transform;
        }

        if (other.gameObject == Player1)
        {
            Player1.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player2)
        {
            Player2.transform.parent = null;
            
        }

        if (other.gameObject == Player1)
        {
            Player1.transform.parent = null;
        }
    }


}

