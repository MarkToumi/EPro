using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safety : MonoBehaviour {
	private PlayerController pc;
	private Ray ray;
	// Use this for initialization
	void Start () {
		pc = this.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if(Physics.SphereCast(ray, 1f, out hit, 15f))
		{
			if(hit.collider.tag == "Block" || hit.collider.tag == "Grave")
				pc.catchObject = hit.collider.gameObject;
			else if(hit.collider.tag == "Player")
			{
				pc.Safety = true;
				pc.otherPlayer = hit.collider.GetComponent<PlayerController>();
			}
		}
		else
		{
			pc.Safety = false;
			pc.otherPlayer = null;
			pc.catchObject = null;
		}
	}
}
