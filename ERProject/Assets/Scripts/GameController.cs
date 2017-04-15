using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePad;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController pc01;
	[SerializeField] PlayerController pc02;
	[SerializeField] int maxHp; 
	[SerializeField] Item item;
	[SerializeField] int kari;
	[SerializeField] float waitTIme;
	// Use this for initialization
	void Start () {
		SetPlayer();
		item.ItemNum = kari;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SetPlayer(){
		pc01.HP = maxHp;
		pc01.WaitTime = waitTIme;
		pc02.HP = maxHp;
		pc02.WaitTime = waitTIme;
	}
}
