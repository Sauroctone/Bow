using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 6f;

	Vector3 movement; 
	Animator anim;
	Rigidbody rigid;

	float v;
	float h;

	public GameObject facing;

	public GameObject camera;

	public float turnSpeed;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		rigid = GetComponent<Rigidbody> ();

	}

	void Update()
	{
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");
	}

	void FixedUpdate ()
	{
		Move (h, v);
		Animate (h, v);

		if (h != 0 || v != 0) 
		{
			Turn ();
		}
	}

	void Move (float h, float v)
	{
		//camera forward and right vectors
		Vector3 forward = camera.transform.forward;
		Vector3 right = camera.transform.right;

		//movement = new Vector3 (h, 0, v).normalized*speed;
		movement = (h * right + v * forward).normalized * speed;
		movement.y = rigid.velocity.y;
		rigid.velocity = movement;
	}

	void Turn()
	{
		facing.transform.LookAt (transform.position + rigid.velocity);
		transform.rotation = Quaternion.Slerp (transform.rotation, facing.transform.rotation, turnSpeed*Time.deltaTime);
	}

	void Animate (float h, float v)
	{
		bool isWalking = h != 0f || v != 0f;
		anim.SetBool("isWalking", isWalking);
	}
}
