﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePad;

public class PlayerController : MonoBehaviour {
	private int hp;
	private float LStick_X;
	private float LStick_Y;
	private float RStick_X;
	private float RStick_Y;
	private int pNums;
	private bool[] Players;
	// Use this for initialization
	void Start () {
		pNums = GameObject.FindGameObjectsWithTag("Player").Length;
        Players = new bool[pNums];
        for (int i = 0; i < pNums; i++)
        {
            if (this.gameObject.name == "Player0" + (i + 1).ToString()) Players[i] = true;
            else Players[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Players[0])
		{
			LStick_X = GamePad01.LStick_X;
			LStick_Y = GamePad01.LStick_Y;
			Move(LStick_X, LStick_Y);
		}
		else if(Players[1])
		{
			LStick_X = GamePad01.LStick_X;
			LStick_Y = GamePad01.LStick_Y;
			Move(LStick_X, LStick_Y);
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Item") Debug.Log("アイテムゲット&使用");
	}

	void Move(float x, float y)
	{
		transform.position += transform.forward * y;
		transform.Rotate(0, x, 0);
	}

	public int HP { get; set; }
}
