using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCheck : MonoBehaviour 
{
	[SerializeField] float time = 60.0f;
	[SerializeField] Text timeTxt;
    private GameController gc;

	// Use this for initialization
	void Start () 
	{
        //timeTxt = GetComponent<Text> ();
        gc = GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (!gc.gameOver) // ゲームオーバーしてなかったら
        {
            if (time <= 0) // タイムアップしたらGameControllerのフラグをtrueに
            {
                time = 0;
                gc.gameOver = true;
            }
            else time -= Time.deltaTime;
            timeTxt.text = "残り時間：" + time.ToString("f1");
        }
	}

	public float TimeCount {
		get { return this.time; }
	}
}
