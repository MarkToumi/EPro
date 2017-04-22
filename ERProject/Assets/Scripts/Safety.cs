using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safety : MonoBehaviour {
	private PlayerController pc;
	// Use this for initialization
	void Start () {
		pc = this.GetComponentInParent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Block" || other.tag == "Grave")
		{
			pc.catchObject = other.gameObject;
		}
		else if(other.tag == "Player") 
		{
			pc.Safety = true;
			pc.otherPlayer = other.GetComponent<PlayerController>();
		}
	}

	void OnTriggerExit(Collider other)
	{
		pc.Safety = false;
		pc.otherPlayer = null;
		pc.catchObject = null;
	}
}
