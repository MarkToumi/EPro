using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour {
	[SerializeField] int time;
	[SerializeField] GameObject moveGrounds;
	[SerializeField] float coefficient;
	private float timeCount;
	private float maxHeight;
	private float minHeight;
	private int groundCount;
	private GameObject[] grounds;
	private bool dir;
	private int upInit;
	private int downInit;
	private int upNumber;
	private int downNumber;
	private GameController gc;
	// Use this for initialization
	void Start () {
		maxHeight = 5;
		minHeight = -10;
		groundCount = 0;
		dir = false;
		gc = GetComponent<GameController>();
		grounds = new GameObject[moveGrounds.transform.childCount];
		for(int i = 0; i < grounds.Length; i++)
		{
			grounds[i] = moveGrounds.transform.GetChild(i).gameObject;
		}
		timeCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(!gc.gameOver)
		{
			timeCount += Time.deltaTime;
			if((int)timeCount == time)
			{
				dir = true;
				switch(groundCount)
				{
					case 0:
						upNumber = grounds.Length / 3;
						downNumber = grounds.Length;
						upInit = 0;
						downInit = 8;
						break;
					case 1:
						upNumber = grounds.Length / 3 + 4;
						downNumber = grounds.Length / 3;
						upInit = 4;
						downInit = 0;
						break;
					case 2:
						upNumber = grounds.Length;
						downNumber = grounds.Length / 3 + 4;
						upInit = 8;
						downInit = 4;
						break;
					default:
						break;
				}
				timeCount = 0;
			}
			if(dir)
			{
				MoveGrounds();
			}
		}
	}

	void MoveGrounds()
	{
		for(int i = upInit; i < upNumber; i++)
		{
			grounds[i].transform.Translate(Vector3.up * Time.deltaTime * coefficient);
			if(grounds[i].transform.position.y >= maxHeight)
			{
				dir = false;
				groundCount++;
				groundCount %= 3;
			}
		}
		for(int i = downInit; i < downNumber; i++)
		{
			grounds[i].transform.Translate(Vector3.down * Time.deltaTime * coefficient);
		}
	}
}
