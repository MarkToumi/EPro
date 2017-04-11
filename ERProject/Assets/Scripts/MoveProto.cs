using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ButtonName;

public class MoveProto : MonoBehaviour {
    private float dx;
	private float dy;
    private bool[] Players;
    private int pNums;
    private int gamePadNums;
    // Use this for initialization
	void Start () {
        pNums = GameObject.FindGameObjectsWithTag("Player").Length;
        Players = new bool[pNums];
        for (int i = 0; i < pNums; i++)
        {
            if (this.gameObject.name == "Player0" + (i + 1).ToString()) Players[i] = true;
            else Players[i] = false;
        }
        dx = 0;
        dy = 0;
        gamePadNums = Input.GetJoystickNames().Length;
        Debug.Log(gamePadNums);
	}
	
	// Update is called once per frame
	void Update () {
        if (Players[0])
        {
            if (gamePadNums > 0)
            {
                if (GamePad01.Fire()) Debug.Log("きたこれ");
                dx = GamePad01.XL();
                dy = GamePad01.YL();
                transform.position += transform.forward * dy;
                transform.Rotate(0, dx, 0);
            }
            else KeyboardInput();
        }
        else if (Players[1])
        {
            if (gamePadNums > 1)
            {
                if (GamePad02.Fire()) Debug.Log("キタコレ");
                dx = GamePad02.XL();
                dy = GamePad02.YL();
                transform.position += transform.forward * dy;
                transform.Rotate(0, dx, 0);
            }
            else KeyboardInput();
        }
	}

    void KeyboardInput()
    {
        if (KeyBoard.Fire()) Debug.Log("ktkr");
        dx = KeyBoard.X();
        dy = KeyBoard.Y();
        transform.position += transform.forward * dy;
        transform.Rotate(0, dx, 0);
    }
}
