using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController Player01;
	[SerializeField] PlayerController Player02;
	[SerializeField] int maxHp; 
	[SerializeField] GameObject itemInstance;
	[SerializeField] int maximumValue;
	[SerializeField] int createTime;
	[SerializeField] float waitTIme;
	private int itemNum;
	private int itemCount;
	private float timeCount;
	private GameObject[] itemObjects;
	private Item[] item;
	// Use this for initialization
	void Start () {
		timeCount = 0;
		itemCount = 0;
		SetPlayer();
		CreateItem();
	}
	
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if(createTime == (int)timeCount){
			CreateItem();
			timeCount = 0;
		}
	}
	void SetPlayer(){
		Player01.HP = maxHp;
		Player01.WaitTime = waitTIme;
		Player02.HP = maxHp;
		Player02.WaitTime = waitTIme;
	}

	void CreateItem(){
		itemNum = Random.Range(0, maximumValue);
		float x = Random.Range(0, 40f);
		float z = Random.Range(0, 40f);
		Vector3 newPos = new Vector3(x, 0.5f, z);
		itemObjects[itemCount] = Instantiate(itemInstance, newPos, Quaternion.Euler(0, 0, 0));
		item[itemCount] = itemObjects[itemCount].GetComponent<Item>();
		item[itemCount].ItemNum = itemNum;
		itemCount++;
	}
}
