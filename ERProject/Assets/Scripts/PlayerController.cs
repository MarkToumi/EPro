using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePad;

public class PlayerController : MonoBehaviour {
	private const float UP = 0;
	private const float DOWN = 180;
	private const float RIGHT = 90;
	private const float LEFT = 270;
	private int hp;
	private int oldHp;
	private int maxHp;
	private bool safety; // Safety.csと連動
	private float move_X;
	private float move_Z;
    private float accel;
    private int pNums; // プレイヤーの数
	private bool[] Players; // プレイヤーの対応パッド
    private IEnumerator respawn; // コルーチン使うならこっちの方が引数を２つ以上設定できるのでオヌヌメ
    private float releaseTime; // 強化解除時間
    private float respawnWait; // リスポーンまでの時間
    private GameController gc;
    public PlayerController otherPlayer; // Safety.csと連動
	public GameObject[] life;
	public bool recovery = false;
	// Use this for initialization
	void Start () {
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		maxHp = hp;
		pNums = GameObject.FindGameObjectsWithTag("Player").Length;
        Players = new bool[pNums];
        for (int i = 0; i < pNums; i++)
        {
            if (this.gameObject.name == "Player0" + (i + 1).ToString()) Players[i] = true;
            else Players[i] = false;
        }
        respawn = Respawn(respawnWait);
	}
	
	// Update is called once per frame
	void Update () {
		if(!gc.gameOver)
		{
			if(Players[0])
			{
				move_X = GamePad01.LStick_X;
				move_Z = GamePad01.LStick_Y;
				Move(move_X, move_Z);
				if(safety)
				{
					if(GamePad01.Fire)
						Attack();
				}
			}
			else if(Players[1])
			{
				move_X = GamePad02.LStick_X;
				move_Z = GamePad02.LStick_Y;
				Move(move_X, move_Z);
				if(safety)
				{
					if(GamePad02.Fire)
						Attack();
				}
			}
		}
		
		if(oldHp > hp)
			Debug.Log("残り" + hp + "!!");
        Debug.Log(accel);
	}

    void OnTriggerEnter(Collider other)
    {
		/*
        if(other.gameObject.tag == "Item"){
            Debug.Log("アイテムゲット&使用 コライダー");
            Item item = other.gameObject.GetComponent<Item>();
            ItemUse(item.ItemNum);
            Destroy(other.gameObject);
        }
		*/
    }

    void Move(float moveX, float moveZ)
	{
        // 両方Ver.
		if(moveX < -0.2f)
			transform.rotation = Quaternion.Euler(new Vector3(0, LEFT, 0));
		else if(moveX > 0.2f)
			transform.rotation = Quaternion.Euler(new Vector3(0, RIGHT, 0));
		else if(moveZ < -0.2f)
			transform.rotation = Quaternion.Euler(new Vector3(0, DOWN, 0));
		else if(moveZ > 0.2f)
			transform.rotation = Quaternion.Euler(new Vector3(0, UP, 0));
		float absX = Mathf.Abs(moveX);
		float absZ = Mathf.Abs(moveZ);
		if(absX < absZ)
			moveX = 0;
		else
			moveZ = 0;
        Vector3 newPos = new Vector3(transform.position.x + (moveX * accel), transform.position.y, transform.position.z + (moveZ * accel));
        transform.position = newPos;
        
        // 片方Ver.1
        /*
        Vector3 newPos = new Vector3(transform.position.x + moveX, transform.position.y, transform.position.z + moveY);
        transform.position = newPos;
        transform.Rotate(0, moveX, 0);
        */
        // 片方Ver.2
        /*
        transform.position += transform.forward * moveY;
        transform.Rotate(0, moveX, 0);
        */
	}

	void Attack() // 攻撃関係
    {
		if(otherPlayer != null)
		{
			int remaining = otherPlayer.HP -1;
			otherPlayer.HP -= 1;
			otherPlayer.life[remaining].SetActive(false);
		}
        if (otherPlayer.HP == 0)
            gc.gameOver = true;
        else
			recovery = true;
	}

    void Respawn() // 関数Ver.
    {
        float x = Random.Range(-40f, 40f);
        float z = Random.Range(-40f, 40f);
        Vector3 newPos = new Vector3(x, transform.position.y, z);
        transform.position = newPos;
    }

    IEnumerator Respawn(float delay) // コルーチンVer.
    {
        yield return new WaitForSeconds(delay);
        float x = Random.Range(-40f, 40f);
        float z = Random.Range(-40f, 40f);
        Vector3 newPos = new Vector3(x, transform.position.y, z);
        transform.position = newPos;
    }

    public void Resusitation() // リスポーン関係
    {
        Respawn();
        //StartCoroutine(respawn);
		recovery = false;
    }

    public int HP { 
		set { oldHp = hp; hp = value; }
		get { return this.hp; }
	 }

	 public int MaxHP {
		 get { return this.maxHp; }
	 }

	public bool Safety { 
		set { safety = value; }
		get { return this.safety; }
	 }

	public float ReleaseTime {
		set { releaseTime = value; }
		get { return releaseTime; }
	 }

    public float RespawnWait {
        set { respawnWait = value; }
    }

    public float Accel {
        set { accel = value; }
        get { return this.accel; }
    }
}
