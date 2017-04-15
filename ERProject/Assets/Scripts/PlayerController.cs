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
	private float waitTime;
	public PlayerController otherPlayer;
	// Use this for initialization
	void Start () {
		pNums = GameObject.FindGameObjectsWithTag("Player").Length;
        Players = new bool[pNums];
        for (int i = 0; i < pNums; i++)
        {
            if (this.gameObject.name == "Player0" + (i + 1).ToString()) Players[i] = true;
            else Players[i] = false;
        }
		effectExit = EffectExit(waitTime);
	}
	
	// Update is called once per frame
	void Update () {
		if(Players[0])
		{
			if(GamePad01.LStick_X <= 0.1f && GamePad01.LStick_X >= -0.1f){
				move_X = GamePad01.Key_X;
			}
			else
				move_X = GamePad01.LStick_X;
			if(GamePad01.LStick_Y <= 0.1f && GamePad01.LStick_Y >= -0.1f){
				move_Y = GamePad01.Key_Y;
			}
			else
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
			if(GamePad02.LStick_X <= 0.1f && GamePad02.LStick_X >= -0.1f){
				move_X = GamePad02.Key_X;
			}
			else
				move_X = GamePad02.LStick_X;
			if(GamePad02.LStick_Y <= 0.1f && GamePad02.LStick_Y >= -0.1f){
				move_Y = GamePad02.Key_Y;
			}
			else
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
			Debug.Log("アイテムゲット&使用");
			Item item = collision.gameObject.GetComponent<Item>();
			ItemUse(item.ItemNum);
			Destroy(collision.gameObject);
		}
	}

	void Move(float x, float y)
	{
		Debug.Log("x:" + x + " y" + y);
		transform.position += transform.forward * y;
		transform.Rotate(0, x, 0);
	}

	void ItemUse(int itemNum)
	{
		switch(itemNum){
		case 0:
			Debug.Log("回復");
			hp++;
			break;
		case 1:
			Debug.Log("アーム強化");
			StartCoroutine(effectExit);
			break;
		case 2:
			Debug.Log("高速化");
			StartCoroutine(effectExit);
			break;
		default:
			break;
		}
	}

	void Attack(){
		if(otherPlayer != null)
			otherPlayer.HP = otherPlayer.HP - 1;
	}

	IEnumerator EffectExit(float delay)
	 {
		 yield return new WaitForSeconds(delay);
		 Debug.Log("強化解除");
		 yield break;
	 }

	public int HP { 
		set { oldHp = hp; hp = value; }
		get { return this.hp; }
	 }

	public bool Safety{ 
		set { safety = value; }
		get { return this.safety; }
	 }

	 public float WaitTime{
		 set { waitTime = value; }
	 }
}
