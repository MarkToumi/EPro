using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	private int itemNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") Debug.Log("当たった");
    }

    public int ItemNum { 
		get { return this.itemNum; }
		set { this.itemNum = value; }
	}
}
