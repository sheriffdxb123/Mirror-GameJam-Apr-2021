using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTwo : MonoBehaviour
{
    public float MoveSpeed = 300f;
    public Rigidbody rb;
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
    }

     void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {

        rb.MovePosition(transform.position + (Vector3.forward * MoveSpeed));
    }
}
