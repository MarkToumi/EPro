using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePad;

public class PlayerController : MonoBehaviour {
	private int hp;
	private int oldHp;
	private bool safety;
	private float move_X;
	private float move_Y;
	private int pNums;
	private bool[] Players;
	private IEnumerator effectExit;
    private IEnumerator respawn;
    private float releaseTime;
    private float respawnWait;
	private MeshRenderer mesh;
	private Color defaultColor;
	private Color alpha;
	public PlayerController otherPlayer;
	public bool testFire;
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
			Move(move_X, move_Y);
			if(safety) {
				if(GamePad01.Fire){
					Debug.Log("FIre!");
					Attack();
				}
			}
		}
		else if(Players[1])
		{
            move_X = GamePad02.LStick_X;
            move_Y = GamePad02.LStick_Y;
            Move(move_X, move_Y);
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

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Item") {
			Debug.Log("アイテムゲット&使用 コリジョン");
			Item item = collision.gameObject.GetComponent<Item>();
			ItemUse(item.ItemNum);
			Destroy(collision.gameObject);
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Item"){
            Debug.Log("アイテムゲット&使用 コライダー");
            Item item = other.gameObject.GetComponent<Item>();
            ItemUse(item.ItemNum);
            Destroy(other.gameObject);
        }
    }

    void Move(float x, float y)
	{
        Vector3 newPos = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y);
        transform.position = newPos;
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

	void Attack(){
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

	IEnumerator EffectExit(float delay)
	 {
        Debug.Log(delay);
		yield return new WaitForSeconds(delay);
		Debug.Log("強化解除");
	 }

    IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        float x = Random.Range(0, 40f);
        float z = Random.Range(0, 40f);
        Vector3 newPos = new Vector3(x, transform.position.y, z);
        transform.position = newPos;
    }

    public void Resusitation(){
        //Respawn();
        StartCoroutine(respawn);
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
