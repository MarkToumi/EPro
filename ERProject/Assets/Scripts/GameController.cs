using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController Player01; // プレイヤーを
	[SerializeField] PlayerController Player02; // 取得
	[SerializeField] int startHp = 3; // 初期HP
    [SerializeField] float accel; // 移動の加速度
    [SerializeField] float releaseTime; // 強化解除の時間
    [SerializeField] float respawnWait; // リスポーンまでの時間
    [SerializeField] GameObject[] items; // 出現するアイテム
	[SerializeField] int createTime; // アイテムの出現頻度（createTimeごとに出現)
    [SerializeField] GameObject graveInstance; // 墓のプレファブ
	[SerializeField] GameObject winner; // ゲームオーバーで勝者を写すやつ
	private int itemNum;
	private int itemPos;
	private float timeCount;
	private Text winnerName; // 勝者の名前が入るやつ
    public bool gameOver = false; // いろんなところから変更するからpublicで
	// Use this for initialization
	void Start () {
		winner.SetActive(false);
		timeCount = 0;
		SetPlayer();
		CreateItem();
		winnerName = winner.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;
		if(createTime == (int)timeCount && !gameOver)
		{
			CreateItem();
			timeCount = 0;
		}

        if (Player01.recovery)
        {
            Vector3 playerPos = Player01.gameObject.transform.position;
            Player01.Resusitation();
            CreateGrave(playerPos); // キャラがいた位置にお墓を建てる
        }

        if (Player02.recovery)
        {
            Vector3 playerPos = Player02.gameObject.transform.position;
            Player02.Resusitation();
            CreateGrave(playerPos); // キャラがいた位置にお墓を建てる
        }

		if(gameOver) // ゲームオーバー処理
		{
			winner.SetActive(true);
			if(Player01.HP > Player02.HP)
			{
				winnerName.text = "プレイヤー１の勝利！";
			}
			else if(Player02.HP > Player01.HP)
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
		Player02.HP = startHp;
        Player02.ReleaseTime = releaseTime;
        Player02.RespawnWait = respawnWait;
        Player02.Accel = accel;
	}

	void CreateItem() // アイテムを生成してランダムに配置。アイテムの属性も同時に設定
	{ 
        Debug.Log("アイテム生成");
		itemNum = Random.Range(0, 3);
		itemPos = Random.Range(0, items.Length);
        if(items[itemPos].activeSelf)
        {
            switch(itemPos)
            {
                case 0:
                    itemPos = 1;
                    break;
                case 1:
                    itemPos = 2;
                    break;
                case 2:
                    itemPos = 3;
                    break;
                case 3:
                    itemPos = 0;
                    break;
                default:
                    break;
            }
        }
		items[itemPos].SetActive(true);
		Debug.Log(items[itemPos]);
		Item item = items[itemPos].GetComponent<Item>();
		item.ItemNum = 1;
	}

    void CreateGrave(Vector3 pos) // プレイヤーの残機が減った場所にオブジェクト生成
    {
        Debug.Log("墓生成");
        Instantiate(graveInstance, pos, Quaternion.identity);
	}
}
