﻿using System.Collections;
using UnityEngine;
using GamePad;

public class PlayerController : MonoBehaviour {
	private const float UP = 0;
	private const float DOWN = 180;
	private const float RIGHT = 90;
	private const float LEFT = 270;
	private int hp;
	private int maxHp;
	private bool safety; // Safety.csと連動
	private bool isCatch; // Saftey.csと連動
	private float throwPower;
	private float move_X;
	private float move_Z;
    private float accel;
    private int pNums; // プレイヤーの数
	private bool[] Players; // プレイヤーの対応パッド
    private IEnumerator respawn; // コルーチン使うならこっちの方が引数を２つ以上設定できるのでオヌヌメ
    private float releaseTime; // 強化解除時間
    private float respawnWait; // リスポーンまでの時間
	private bool recovery;
    private GameObject throwObject;
    private GameController gc;
	private Safety sf;
    public PlayerController otherPlayer; // Safety.csと連動
	public GameObject catchObject; // Safety.csと連動
	public GameObject[] life;
	// Use this for initialization
	void Start () {
		safety = false;
		isCatch = false;
		recovery = false;
        gc = GameObject.Find("GameController").GetComponent<GameController>();
		sf = GetComponent<Safety>();
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
				if(GamePad01.Fire)
				{
					sf.Ray();
					if(isCatch)
						Throw();
					else if(catchObject != null)
						Catch();
					else if(safety)
						Attack();
				}
			}
			else if(Players[1])
			{
				move_X = GamePad02.LStick_X;
				move_Z = GamePad02.LStick_Y;
				Move(move_X, move_Z);
				if(GamePad02.Fire)
				{
					sf.Ray();
					if(isCatch)
						Throw();
					else if(catchObject != null)
						Catch();
					else if(safety)
						Attack();
				}
			}
		}
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
	}

	void Attack() // 攻撃関係
    {
		if(otherPlayer != null)
		{
			otherPlayer.HP -= 1;
			otherPlayer.life[otherPlayer.HP].SetActive(false);
		}
        if (otherPlayer.HP == 0)
            gc.gameOver = true;
        else
			otherPlayer.Recovery = true;
		otherPlayer = null;
		safety = false;
	}

	void Catch()
	{
        throwObject = catchObject;
		catchObject = null;
		throwObject.transform.parent = transform;
		isCatch = true;
	}

	void Throw()
	{
		Rigidbody rb = throwObject.GetComponent<Rigidbody>();
		if(!rb)
			rb = throwObject.AddComponent<Rigidbody>();
		rb.useGravity = true;
		rb.isKinematic = false;
		rb.AddForce(transform.TransformDirection(Vector3.forward) + transform.TransformDirection(Vector3.up) / 2 * throwPower);
		throwObject.transform.parent = null;
        throwObject = null;
		isCatch = false;
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

    // プレイヤー側でインスペクターからいじれそうに見えるのが嫌なのでprivateとセッター&ゲッターを使用
    public int HP { 
		set { hp = value; }
		get { return this.hp; }
	 }

	 public int MaxHP {
		 get { return this.maxHp; }
	 }

	public bool Safety { 
		set { safety = value; }
		get { return this.safety; }
	 }

	 public bool Recovery {
		 set { recovery = value; }
		 get { return this.recovery; }
	 }

	public float ReleaseTime {
		set { releaseTime = value; }
		get { return this.releaseTime; }
	 }

    public float RespawnWait {
        set { respawnWait = value; }
    }

    public float Accel {
        set { accel = value; }
        get { return this.accel; }
    }

	public float ThrowPower {
		set { throwPower = value; }
		get { return this.ThrowPower; }
	}
}
