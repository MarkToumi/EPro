using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePad;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController pc01;
	[SerializeField] PlayerController pc02;
	[SerializeField] int maxHp; 
	// Use this for initialization
	void Start () {
		SetPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SetPlayer(){
		pc01.HP = maxHp;
		pc02.HP = maxHp;
	}
}
