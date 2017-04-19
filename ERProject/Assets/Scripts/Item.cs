﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
	private int itemNum;
    private PlayerController player;
    private int heal;
	// Use this for initialization
	void Start () {
        heal = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<PlayerController>();
            ItemUse(player, itemNum);
            Debug.Log("当たった");
            Destroy(this.gameObject);
        }
    }

    void ItemUse(PlayerController pc, int iNum)
    {
        switch(iNum)
        {
            case 0:
                Debug.Log("回復");
                pc.HP = pc.HP + heal;
                break;
            case 1:
                Debug.Log("加速");
                pc.Accel = 1.5f;
                pc.EffectOut();
                break;
            case 2:
                Debug.Log("強化");
                pc.EffectOut();
                break;
            default:
                break;
        }
    }

    public int ItemNum { 
		get { return this.itemNum; }
		set { this.itemNum = value; }
	}
}
