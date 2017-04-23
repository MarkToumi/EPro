using System.Collections;
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
	[SerializeField] float createTime; // アイテムの出現頻度（createTimeごとに出現)
    [SerializeField] GameObject graveInstance; // 墓のプレファブ
	[SerializeField] GameObject winner; // ゲームオーバーで勝者を写すやつ
	private int itemNum;
	private int itemCount;
	private IEnumerator createItem;
	private Text winnerName; // 勝者の名前が入るやつ
    public bool gameOver = false; // いろんなところから変更、参照するからpublicで
	// Use this for initialization
	void Start () {
		itemCount = 0;
		SetPlayer();
        createItem = CreateItem(createTime);
        StartCoroutine(createItem);
		winnerName = winner.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Player01.Recovery)
        {
            Vector3 playerPos = Player01.gameObject.transform.position;
            Player01.Resusitation();
            CreateGrave(playerPos); // キャラがいた位置にお墓を建てる
        }

        if (Player02.Recovery)
        {
            Vector3 playerPos = Player02.gameObject.transform.position;
            Player02.Resusitation();
            CreateGrave(playerPos); // キャラがいた位置にお墓を建てる
        }

		if(gameOver) // ゲームオーバー処理
		{
			winner.SetActive(true);
			if(Player01.HP > Player02.HP)
				winnerName.text = "プレイヤー１の勝利！";
			else if(Player02.HP > Player01.HP)
				winnerName.text = "プレイヤー２の勝利！";
			else if(Player01.HP == Player02.HP)
				winnerName.text = "引き分け！";
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

    IEnumerator CreateItem(float delay)
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            itemNum = Random.Range(0, 3);
            items[itemCount].SetActive(true);
            Item item = items[itemCount].GetComponent<Item>();
            item.ItemNum = itemNum;
            itemCount++;
            itemCount %= items.Length;
        }
    }

    void CreateGrave(Vector3 pos) // プレイヤーの残機が減った場所にオブジェクト生成
    {
        Debug.Log("墓生成");
        Instantiate(graveInstance, pos, Quaternion.identity);
	}
}
