using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float cameraMoveSpeed = 120f;
	public GameObject cameraFollowObj;
	Vector3 followPos;
	public float clampAngle = 45f;
	public float sensX = 20;
	public float sensY = 10;
	public GameObject camera;
	public GameObject player;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
	public float smoothX;
	public float smoothY;
	private float rotY;
	private float rotX;
	Vector3 velocity = Vector3.zero;
	public float smoothTime = 0.1f;

	void Start () 
	{
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void FixedUpdate () 
	{
		mouseX = Input.GetAxis ("Mouse X");
		mouseY = Input.GetAxis ("Mouse Y");

		rotY += mouseX * sensX;
		rotX += -mouseY * sensY;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0f);
		transform.rotation = localRotation;

		Transform target = cameraFollowObj.transform;
		transform.position = Vector3.SmoothDamp (transform.position, target.position, ref velocity, smoothTime);
	}
}