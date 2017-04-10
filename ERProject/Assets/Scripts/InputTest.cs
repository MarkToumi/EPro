using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * InputManagerを書き換えたのでFire1とかが使えない上に
 * 一応ゲームパッド４機に対応するようにしたので
 * それらをまとめたシングルトンっぽいのを作りました
 * 以後使うかわかりませんが、ButtonName を using してください
*/
using ButtonName;

public class InputTest : MonoBehaviour {
    private float pad_x;
    private float pad_y;
	// Use this for initialization
	void Start () {
        pad_x = 0;
        pad_y = 0;
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * GamePad[番号].[取りたいもの]()で取得できます
         * 上から攻撃、ジャンプ（念のため）、横移動、縦移動です
        */ 
        if (GamePad01.Fire()) Debug.Log("エグゼイド");
        if (GamePad01.Jump()) Debug.Log("EXCITE");
        pad_x = GamePad01.X();
        pad_y = GamePad01.Y();
        Debug.Log("横移動@Axis:" + pad_x);
        Debug.Log("縦移動@Axis:" + pad_y);
    }
}
