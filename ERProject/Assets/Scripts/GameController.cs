using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController Player01; // プレイヤーを
	[SerializeField] PlayerController Player02; // 取得
	[SerializeField] int startHp = 3; // 初期HP
    [SerializeField] float accel; // 移動の加速度
    [SerializeField] float rotatePlus = 0.5f; // 回転の速度
    [SerializeField] float releaseTime; // 強化解除の時間
    [SerializeField] float respawnWait; // リスポーンまでの時間
    [SerializeField] GameObject itemInstance; // 生成するアイテムのプレファブ
	[SerializeField] int maximumValue; // 出現するアイテムの最大個数
	[SerializeField] int createTime; // アイテムの出現頻度（createTimeごとに出現)
    [SerializeField] GameObject graveInstance; // 墓のプレファブ
	[SerializeField] GameObject winner;
	private int itemNum;
	private int itemCount;
	private float timeCount;
	private GameObject[] itemObjects;
	private Item[] item;
	private TimeCheck tc;
	private Text winnerName;
    public bool gameOver = false;
	// Use this for initialization
	void Start () {
		winner.SetActive(false);
		timeCount = 0;
		itemCount = 0;
		SetPlayer();
        itemObjects = new GameObject[maximumValue];
        item = new Item[maximumValue];
		CreateItem();
		tc = GetComponent<TimeCheck>();
		winnerName = winner.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if(createTime == (int)timeCount && tc.TimeCount > 0)
		{
			CreateItem();
			timeCount = 0;
		}

        if (Player01.getAlpha() <= 0.1f)
        {
            Vector3 playerPos = Player01.gameObject.transform.position;
            Player01.Resusitation();
            CreateGrave(playerPos);
        }

        if (Player02.getAlpha() <= 0.1f)
        {
            Vector3 playerPos = Player02.gameObject.transform.position;
            Player02.Resusitation();
            CreateGrave(playerPos);
        }

		if(gameOver)
		{
			winner.SetActive(true);
			if(Player02.GameOver || Player01.HP > Player02.HP)
			{
				winnerName.text = "プレイヤー１の勝利！";
			}
			else if(Player01.GameOver || Player02.HP > Player01.HP)
			{
				winnerName.text = "プレイヤー２の勝利！";
			}
			else if(Player01.HP == Player02.HP)
			{
				winnerName.text = "引き分け！";
			}
            Debug.Log("ゲーム終了");
		}
	}
	void SetPlayer() // 各プレイヤーに初期設定
	{
		Player01.HP = startHp;
        Player01.ReleaseTime = releaseTime;
        Player01.RespawnWait = respawnWait;
        Player01.Accel = accel;
        Player01.RotatePlus = rotatePlus;
		Player02.HP = startHp;
        Player02.ReleaseTime = releaseTime;
        Player02.RespawnWait = respawnWait;
        Player02.Accel = accel;
        Player02.RotatePlus = rotatePlus;
	}

	void CreateItem() // アイテムを生成してランダムに配置。アイテムの属性も同時に設定
	{ 
        Debug.Log("アイテム生成");
		itemNum = Random.Range(0, 3);
		itemObjects[itemCount] = Instantiate(itemInstance, itemInstance.transform.position, Quaternion.Euler(0, 0, 0));
		item[itemCount] = itemObjects[itemCount].GetComponent<Item>();
		item[itemCount].ItemNum = itemNum;
		itemCount++;
	}

    void CreateGrave(Vector3 pos) // プレイヤーの残機が減った場所にオブジェクト生成
    {
        Debug.Log("墓生成");
        Instantiate(graveInstance, pos, Quaternion.identity);
    }

	public int StartHP{
		get { return this.startHp; }
	}
}
