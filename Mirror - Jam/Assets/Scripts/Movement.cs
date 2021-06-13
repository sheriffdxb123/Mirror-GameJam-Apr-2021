using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
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
	float er = 1.67f;
	public float t;
	public float t1;
	Rigidbody m_Rigidbody;
	public int scenetime; 

	public Color color; 

	Vector3 targetPosition;
	Vector3 startPosition;
	bool moving;
	MeshRenderer cubeRenderer;
	public Animator P1anim;
	public int index;
	
    private void Start()
	{
		m_Rigidbody = GetComponent<Rigidbody>();
		P1anim.enabled = false;
		
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

			transform.position += (targetPosition - startPosition) * moveSpeed * Time.deltaTime;
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
				targetPosition = transform.position + (-er * Vector3.left);
				startPosition = transform.position;
				moving = true;
			}
		}
		else if (Input.GetKeyDown(KeyCode.D))
		{
			if (CanMove(Vector3.right))
			{
				targetPosition = transform.position + (-er * Vector3.right);
				startPosition = transform.position;
				moving = true;
			}
		}

	}
	

    public void OnCollisionStay(UnityEngine.Collision collision)
	{
		if (collision.gameObject.tag == "Green")
		{
			StartCoroutine(freezeLate(t));
			StartCoroutine(MoveDown(t1));

			
		}
	}
	IEnumerator freezeLate(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		moving = false;
		m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
		m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

	}

	IEnumerator MoveDown(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

		P1anim.enabled = true;

	}
	IEnumerator WaitForIt(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene(index);
		//hello
	}
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.tag == "P2")
        {
			StartCoroutine(WaitForIt(scenetime));
		}
    }
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