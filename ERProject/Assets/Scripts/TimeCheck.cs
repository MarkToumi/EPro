using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCheck : MonoBehaviour 
{
	[SerializeField] float time = 60.0f;
	[SerializeField] Text timeTxt;

	// Use this for initialization
	void Start () 
	{
		//timeTxt = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		time -= Time.deltaTime;
		timeTxt.text = "残り時間：" + time.ToString ("f1");
	}
}
