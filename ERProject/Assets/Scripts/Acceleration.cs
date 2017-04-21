using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour {

	// Use this for initialization
	private PlayerController pc;
	private float releaseTime;
	private IEnumerator effectExit;
	void Start () {
		pc = GetComponent<PlayerController>();
		releaseTime = pc.ReleaseTime;
		effectExit = EffectExit(releaseTime);
		Accel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Accel()
	{
		pc.Accel += 1;
		StartCoroutine(effectExit);
	}

	IEnumerator EffectExit(float delay)
	{
		yield return new WaitForSeconds(delay);
		pc.Accel = pc.DefaultAccel;
		Destroy(this);
	}
}
