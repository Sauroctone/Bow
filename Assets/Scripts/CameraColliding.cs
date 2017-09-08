using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliding : MonoBehaviour {

	public ThirdPersonCamera camera;
	public float zoomLimit = -1.3f;
	private Vector3 originalPos;

	void Start()
	{
		originalPos = transform.localPosition;
	}

	void OnTriggerStay(Collider col)
	{
		if (col.tag == "Floor")
		{
			camera.isColliding = true;
			if (transform.localPosition.z < zoomLimit && camera.mouseY > 0) {
				transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 
					Mathf.Lerp (transform.localPosition.z, zoomLimit, 0.1f));
			}

			if (camera.mouseY < 0) 
			{
				transform.localPosition = Vector3.Lerp (transform.localPosition, originalPos, 0.1f);
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Floor") 
		{
			camera.isColliding = false;
		}
	}

	void FixedUpdate ()
	{
		
	}
}
