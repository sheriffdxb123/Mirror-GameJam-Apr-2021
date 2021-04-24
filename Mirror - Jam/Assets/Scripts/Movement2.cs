﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
	[SerializeField]
	float moveSpeed = 0.25f;
	[SerializeField]
	float rayLength = 1.4f;
	[SerializeField]
	float rayOffsetX = 0.5f;
	[SerializeField]
	float rayOffsetY = 0.5f;
	[SerializeField]
	float rayOffsetZ = 0.5f;
	[SerializeField]
	float er = 2.67f;

	Rigidbody m_Rigidbody;


	Vector3 targetPosition;
	Vector3 startPosition;
	bool moving;

    private void Start()
    {
		m_Rigidbody = GetComponent<Rigidbody>();
	}
    void Update()
	{
		if (moving)
		{
			if (Vector3.Distance(startPosition, transform.position) > 1f)
			{
				transform.position = targetPosition;
				moving = false;
				return;
			}

			transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime ;
			return;
		}

		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX + Vector3.forward * rayLength, Color.red, Time.deltaTime);
		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX + Vector3.forward * rayLength, Color.red, Time.deltaTime);

		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX + Vector3.back * rayLength, Color.red, Time.deltaTime);
		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX + Vector3.back * rayLength, Color.red, Time.deltaTime);

		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ + Vector3.left * rayLength, Color.red, Time.deltaTime);
		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ + Vector3.left * rayLength, Color.red, Time.deltaTime);

		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ + Vector3.right * rayLength, Color.red, Time.deltaTime);
		Debug.DrawLine(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ + Vector3.right * rayLength, Color.red, Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.W))
		{
			if (CanMove(Vector3.forward))
			{
				targetPosition = transform.position + (er * Vector3.forward);
				startPosition = transform.position;
				moving = true;
			}
		}
	
		else if (Input.GetKeyDown(KeyCode.A))
		{
			if (CanMove(Vector3.left))
			{
				targetPosition = transform.position +(er * Vector3.left);
				startPosition = transform.position;
				moving = true;
			}
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			if (CanMove(Vector3.right))
			{
				targetPosition = transform.position +(er * Vector3.right);
				startPosition = transform.position;
				moving = true;
			}
		}
				
	}

   /* public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
			moving = false;
			m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition;
		}
    }*/
    bool CanMove(Vector3 direction)
	{
		if (Vector3.Equals(Vector3.forward, direction) || Vector3.Equals(Vector3.back, direction))
		{
			if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.right * rayOffsetX, direction, rayLength)) return false;
			if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.right * rayOffsetX, direction, rayLength)) return false;
		}
		else if (Vector3.Equals(Vector3.left, direction) || Vector3.Equals(Vector3.right, direction))
		{
			if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY + Vector3.forward * rayOffsetZ, direction, rayLength)) return false;
			if (Physics.Raycast(transform.position + Vector3.up * rayOffsetY - Vector3.forward * rayOffsetZ, direction, rayLength)) return false;
		}
		return true;
	}
}