using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController Player01; // プレイヤーを
	[SerializeField] PlayerController Player02; // 取得
	[SerializeField] int startHp = 3; // 初期HP
    [SerializeField] float releaseTime; // 強化解除の時間
    [SerializeField] float respawnWait; // リスポーンまでの時間
    [SerializeField] GameObject itemInstance; // 生成するアイテムのプレファブ
	[SerializeField] int maximumValue; // 出現するアイテムの最大個数
	[SerializeField] int createTime; // アイテムの出現頻度（createTimeごとに出現)
	private int itemNum;
	private int itemCount;
	private float timeCount;
	private GameObject[] itemObjects;
	private Item[] item;
	// Use this for initialization
	void Start () 
	{
		timeCount = 0;
		itemCount = 0;
		SetPlayer();
        itemObjects = new GameObject[maximumValue];
        item = new Item[maximumValue];
		CreateItem();
	}
	
	// Update is called once per frame
	void Update () 
	{
		timeCount += Time.deltaTime;
		if(createTime == (int)timeCount && itemCount <= maximumValue)
		{
			CreateItem();
			timeCount = 0;
		}

        if (Player01.getAlpha() <= 0.1f) Player01.Resusitation();
    
        if (Player02.getAlpha() <= 0.1f) Player02.Resusitation();
	}
	void SetPlayer() // 各プレイヤーに初期設定
	{
		Player01.HP = startHp;
        Player01.ReleaseTime = releaseTime;
        Player01.RespawnWait = respawnWait;
		Player02.HP = startHp;
        Player02.ReleaseTime = releaseTime;
        Player02.RespawnWait = respawnWait;
	}

	void CreateItem() // アイテムを生成してランダムに配置。アイテムの属性も同時に設定
	{ 
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
