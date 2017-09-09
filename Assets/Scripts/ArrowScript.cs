using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

	private Rigidbody rb;
	[Range(0f,1f)]public float drawPercent;
	public float speed;

	void Start ()
	{
		print (drawPercent);
		rb = GetComponent<Rigidbody> ();
		Vector3 force = drawPercent * transform.forward * speed;
		rb.AddForce (force, ForceMode.VelocityChange);
	}
}
