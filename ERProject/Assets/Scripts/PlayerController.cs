using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePad;

public class PlayerController : MonoBehaviour {
	private int hp;
	private int oldHp;
	private bool safety; // Safety.csと連動
	private float move_X;
	private float move_Y;
    private float rotate_X;
	private int pNums; // プレイヤーの数
	private bool[] Players; // プレイヤーの対応パッド
	private IEnumerator effectExit; // コルーチン使うなら
    private IEnumerator respawn; // こっちの方が引数を２つ以上設定できるのでオヌヌメ
    private float releaseTime; // 強化解除時間
    private float respawnWait; // リスポーンまでの時間
	private MeshRenderer mesh;
	private Color defaultColor;
	private Color alpha;
    public PlayerController otherPlayer; // Safety.csと連動
	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshRenderer>();
		defaultColor = mesh.material.color;
		alpha = new Color(0, 0, 0, 0);
		pNums = GameObject.FindGameObjectsWithTag("Player").Length;
        Players = new bool[pNums];
        for (int i = 0; i < pNums; i++)
        {
            if (this.gameObject.name == "Player0" + (i + 1).ToString()) Players[i] = true;
            else Players[i] = false;
        }
		effectExit = EffectExit(releaseTime);
        respawn = Respawn(respawnWait);
	}
	
	// Update is called once per frame
	void Update () {
		if(Players[0])
		{
			move_X = GamePad01.LStick_X;
			move_Y = GamePad01.LStick_Y;
            rotate_X = GamePad01.RStick_X;
			Move(move_X, move_Y, rotate_X);
			if(safety) {
				if(GamePad01.Fire){
					Debug.Log("Fire!");
					Attack();
				}
			}
		}
		else if(Players[1])
		{
            move_X = GamePad02.LStick_X;
            move_Y = GamePad02.LStick_Y;
            rotate_X = GamePad02.RStick_X;
            Move(move_X, move_Y, rotate_X);
			if(safety){
				if(GamePad02.Fire){
					Debug.Log("Fire!");
					Attack();
				}
			}
		}
		if(oldHp > hp)
			Debug.Log("残り" + hp + "!!");
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

    void Move(float moveX, float moveY, float rotateX)
	{
        // 両方Ver.
        
        Vector3 newPos = new Vector3(transform.position.x + moveX, transform.position.y, transform.position.z + moveY);
        transform.position = newPos;
        transform.Rotate(0, rotateX, 0);
        
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

	void ItemUse(int itemNum)
	{
		switch(itemNum){
		    case 0:
			    Debug.Log("回復");
			    hp++;
			    break;
		    case 1:
			    Debug.Log("武器強化");
			    StartCoroutine(effectExit);
			    break;
		    case 2:
			    Debug.Log("高速化");
			    StartCoroutine(effectExit);
			    break;
            case 3:
                Debug.Log("未定");
                StartCoroutine(effectExit);
                break;
            case 4:
                Debug.Log("未定");
                StartCoroutine(effectExit);
                break;
		    default:
			    break;
		}
	}

	void Attack() // 攻撃関係
    {
		if(otherPlayer != null){
			otherPlayer.HP = otherPlayer.HP - 1;
		}
		if(otherPlayer.HP == 0) Debug.Log("ゲーム終了");
		else {
			MeshRenderer otherMesh = otherPlayer.Mesh;
			otherMesh.material.color = alpha;
			otherPlayer.Mesh = otherMesh;
		}
	}

    void Respawn() // 関数Ver.
    {
        float x = Random.Range(0, 40f);
        float z = Random.Range(0, 40f);
        Vector3 newPos = new Vector3(x, transform.position.y, z);
        transform.position = newPos;
    }

	IEnumerator EffectExit(float delay) // 強化解除
	 {
        Debug.Log(delay);
		yield return new WaitForSeconds(delay);
		Debug.Log("強化解除");
	 }

    IEnumerator Respawn(float delay) // コルーチンVer.
    {
        yield return new WaitForSeconds(delay);
        float x = Random.Range(0, 40f);
        float z = Random.Range(0, 40f);
        Vector3 newPos = new Vector3(x, transform.position.y, z);
        transform.position = newPos;
    }

    public void EffectOut()
    {
        StartCoroutine(effectExit);
    }

    public void Resusitation() // リスポーン関係
    {
        Respawn();
        //StartCoroutine(respawn);
		mesh.material.color = defaultColor;
        Debug.Log("kita");
    }

    public int HP { 
		set { oldHp = hp; hp = value; }
		get { return this.hp; }
	 }

	public bool Safety{ 
		set { safety = value; }
		get { return this.safety; }
	 }

	public float ReleaseTime{
		set { releaseTime = value; }
	 }

    public float RespawnWait{
        set { respawnWait = value; }
    }

	public MeshRenderer Mesh{
		get { return this.mesh; }
		set { mesh = value; }
	}

	public float getAlpha(){
		return mesh.material.color.a;
	}
}
