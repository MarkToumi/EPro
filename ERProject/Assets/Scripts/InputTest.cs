using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("GamePad01_Fire")) Debug.Log("テスト射撃成功");
        if (Input.GetButtonDown("GamePad01_Jump")) Debug.Log("テスト跳躍成功");
        if (Input.GetAxis("GamePad01_X") >= 0.1) Debug.Log("横移動@Axis:" + Input.GetAxis("GamePad01_X") + ",AxisRaw:" + Input.GetAxisRaw("GamePad01_X"));
        if (Input.GetAxis("GamePad01_Y") >= 0.1) Debug.Log("縦移動@Axis:" + Input.GetAxis("GamePad01_Y") + ",AxisRaw:" + Input.GetAxisRaw("GamePad01_Y"));
    }
}
