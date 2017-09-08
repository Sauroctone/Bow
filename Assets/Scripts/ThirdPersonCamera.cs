using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

	public GameObject player;
	public GameObject rotZ;

	Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.1f;
	private float mouseX;
	public float mouseY;
	public float sensX;
	public float sensY;

	public float topXConstraint;
	public float bottomXConstraint;
	public float maxBottomConstraint;


	float angle;

	public bool isColliding = false;

	void FixedUpdate()
	{
		transform.position = Vector3.SmoothDamp (transform.position, player.transform.position, ref velocity, smoothTime);

		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");

		transform.RotateAround (transform.position, transform.up, mouseX * sensX);
		rotZ.transform.RotateAround (transform.position, rotZ.transform.right, mouseY * -sensY);

		angle = rotZ.transform.localEulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;

		if (angle > topXConstraint)
			rotZ.transform.localEulerAngles = new Vector3(topXConstraint, 0, 0);
		
		if (angle < bottomXConstraint)
			rotZ.transform.localEulerAngles = new Vector3(bottomXConstraint, 0, 0);	

		/*
		if (isColliding && mouseY > 0 && bottomXConstraint > maxBottomConstraint)
		{
			bottomXConstraint -= 1;
		}

		else if (!isColliding && bottomXConstraint < -45 )
		{
			bottomXConstraint += 1;
		} */
	}
}
