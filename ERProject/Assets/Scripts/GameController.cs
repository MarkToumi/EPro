using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController Player01;
	[SerializeField] PlayerController Player02;
	[SerializeField] int startHp = 3;
    [SerializeField] float releaseTime;
    [SerializeField] float respawnWait;
    [SerializeField] GameObject itemInstance;
	[SerializeField] int maximumValue;
	[SerializeField] int createTime;
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
        itemObjects = new GameObject[maximumValue];
        item = new Item[maximumValue];
		CreateItem();
	}
	
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if(createTime == (int)timeCount && itemCount <= maximumValue){
			CreateItem();
			timeCount = 0;
		}
        if (!Player01.gameObject.activeSelf){
            Player01.gameObject.SetActive(true);
            Player01.Resusitation();
        }
        if (!Player02.gameObject.activeSelf){
            Player02.gameObject.SetActive(true);
            Player02.Resusitation();
        }
	}
	void SetPlayer(){
		Player01.HP = startHp;
        Player01.ReleaseTime = releaseTime;
        Player01.RespawnWait = respawnWait;
		Player02.HP = startHp;
        Player02.ReleaseTime = releaseTime;
        Player02.RespawnWait = respawnWait;
	}

	void CreateItem(){
        Debug.Log("アイテム生成");
		itemNum = Random.Range(0, 3);
		float x = Random.Range(0, 40f);
		float z = Random.Range(0, 40f);
		Vector3 newPos = new Vector3(x, 1.5f, z);
		itemObjects[itemCount] = Instantiate(itemInstance, newPos, Quaternion.Euler(0, 0, 0));
		item[itemCount] = itemObjects[itemCount].GetComponent<Item>();
		item[itemCount].ItemNum = itemNum;
		itemCount++;
	}
}
