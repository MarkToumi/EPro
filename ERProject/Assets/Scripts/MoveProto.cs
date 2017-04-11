using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ButtonName;

public class MoveProto : MonoBehaviour {
	private float dy;
	// Use this for initialization
	void Start () {
		dy = 0;
	}
	
	// Update is called once per frame
	void Update () {
		dy = KeyBord.Y();
		transform.position += transform.forward * dy;
	}
}
