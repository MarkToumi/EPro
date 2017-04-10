using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {
    private float pad_x;
    private float raw_x;
    private float pad_y;
    private float raw_y;
	// Use this for initialization
	void Start () {
        pad_x = 0;
        pad_y = 0;
        raw_x = 0;
        raw_y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("GamePad01_Fire")) Debug.Log("テスト射撃成功");
        if (Input.GetButtonDown("GamePad01_Jump")) Debug.Log("テスト跳躍成功");
        pad_x = Input.GetAxis("GamePad01_X");
        raw_x = Input.GetAxisRaw("GamePad01_X");
        pad_y = Input.GetAxis("GamePad01_Y");
        raw_y = Input.GetAxisRaw("GamePad01_Y");
        Debug.Log("横移動@Axis:" + pad_x + ",AxisRaw:" + raw_x);
        Debug.Log("縦移動@Axis:" + pad_y + ",AxisRaw:" + raw_y);
    }
}
