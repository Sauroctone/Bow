using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public bool isDrawing;
	public bool hasNocked;
	public bool hasDrawn;
	private Animator anim;
	[Range(0f,1f)]public float drawPercent;
	public GameObject arrow;
	public GameObject arrowSpawner;
	public float minDrawPercent;

	AnimatorStateInfo currentState;
	public float playbackTime;

	public PlayerMovement player;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void Update()
	{
		if (Input.GetMouseButtonDown(1) && !isDrawing)
		{
			//drawPercent = minDrawPercent;
			isDrawing = true;
			player.state = PlayerStates.Drawing;

			anim.SetBool ("isDrawing", isDrawing);
		}

		if (Input.GetMouseButton (1) && isDrawing && hasNocked && !hasDrawn)
		{
			currentState = anim.GetCurrentAnimatorStateInfo(0);
			playbackTime = currentState.normalizedTime % 1;
		}

		if (!Input.GetMouseButton (1) && hasNocked) 
		{
			drawPercent = Mathf.Round ((playbackTime * 100)) / 100;
			drawPercent = 2 * drawPercent - 1;
			drawPercent = Mathf.Max (drawPercent, minDrawPercent);

			GameObject _arrow = Instantiate (arrow, arrowSpawner.transform.position, arrowSpawner.transform.rotation);
			_arrow.GetComponent<ArrowScript> ().drawPercent = drawPercent;
			Destroy (_arrow, 20);

			drawPercent = 0;
			isDrawing = false;
			hasNocked = false;
			hasDrawn = false;
			playbackTime = 0;

			anim.SetBool ("isDrawing", isDrawing);
			anim.SetTrigger ("Releases");
			print ("release");
		}
	}

	void Nock()
	{
		hasNocked = true;
	}

	void MaxDrawn()
	{
		hasDrawn = true;
	}
}