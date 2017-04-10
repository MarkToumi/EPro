using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ButtonName;

public class InputTest : MonoBehaviour {
    private float pad_x;
    private float raw_x;
    private float pad_y;
    private float raw_y;
	// Use this for initialization
	void Start () {
        pad_x = 0;
        pad_y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GamePad01.Fire()) Debug.Log("エグゼイド");
        if (GamePad01.Jump()) Debug.Log("EXCITE");
        pad_x = GamePad01.X();
        pad_y = GamePad01.Y();
        Debug.Log("横移動@Axis:" + pad_x);
        Debug.Log("縦移動@Axis:" + pad_y);
    }
}
