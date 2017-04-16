/*
 *  InputManagerを書き換えたのでFire1とかが使えない上に
 *  一応ゲームパッド４機に対応するようにしたので
 *  それらをまとめたシングルトンっぽいのを作りました
 *  以後使うかわかりませんが、ButtonName を using してください
 *  GamePad[番号].[取りたいもの]()で取得できます
 *  クラス名はパッドの番号とデバッグ用にキーボード
 *  X()とY()は返り値がfloat、Fire()とJump()はbool
 *  もしかしたらプレイヤーに移すかも？
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePad
{
    public class GamePad01 : MonoBehaviour
    {
        private static string horizontal_L = "GamePad01_X_L";
        private static string vertical_L = "GamePad01_Y_L";
        private static string horizontal_R = "GamePad01_X_R";
        private static string vertical_R = "GamePad01_Y_R";
        private static string fire = "GamePad01_Fire";
        public static float LStick_X { get { return Input.GetAxis(horizontal_L); } }
        public static float LStick_Y { get { return Input.GetAxis(vertical_L); } }
        public static float RStick_X { get { return Input.GetAxis(horizontal_R); } }
        public static float RStick_Y { get { return Input.GetAxis(vertical_R); } }
        public static bool Fire { get { return Input.GetButtonDown(fire); } }
    }

    public class GamePad02 : MonoBehaviour
    {
        private static string horizontal_L = "GamePad02_X_L";
        private static string vertical_L = "GamePad02_Y_L";
        private static string horizontal_R = "GamePad02_X_R";
        private static string vertical_R = "GamePad02_Y_R";
        private static string fire = "GamePad02_Fire";
        public static float LStick_X { get { return Input.GetAxis(horizontal_L); } }
        public static float LStick_Y { get { return Input.GetAxis(vertical_L); } }
        public static float RStick_X { get{ return Input.GetAxis(horizontal_R); } }
        public static float RStick_Y { get { return Input.GetAxis(vertical_R); } }
        public static bool Fire { get { return Input.GetButtonDown(fire); } }
    }

    public class GamePad03 : MonoBehaviour
    {
        private static string horizontal_L = "GamePad03_X_L";
        private static string vertical_L = "GamePad03_Y_L";
        private static string horizontal_R = "GamePad03_X_R";
        private static string vertical_R = "GamePad03_Y_R";
        private static string fire = "GamePad03_Fire";
        public static float LStick_X { get { return Input.GetAxis(horizontal_L); } }
        public static float LStick_Y { get { return Input.GetAxis(vertical_L); } }
        public static float RStick_X { get{ return Input.GetAxis(horizontal_R); } }
        public static float RStick_Y { get { return Input.GetAxis(vertical_R); } }
        public static bool Fire { get { return Input.GetButtonDown(fire); } }
    }

    public class GamePad04 : MonoBehaviour
    {
        private static string horizontal_L = "GamePad04_X_L";
        private static string vertical_L = "GamePad04_Y_L";
        private static string horizontal_R = "GamePad04_X_R";
        private static string vertical_R = "GamePad04_Y_R";
        private static string fire = "GamePad04_Fire";
        public static float LStick_X { get { return Input.GetAxis(horizontal_L); } }
        public static float LStick_Y { get { return Input.GetAxis(vertical_L); } }
        public static float RStick_X { get{ return Input.GetAxis(horizontal_R); } }
        public static float RStick_Y { get { return Input.GetAxis(vertical_R); } }
        public static bool Fire { get { return Input.GetButtonDown(fire); } }
    }

    public class KeyBoard : MonoBehaviour
    {
        private static string horizontal = "Key_X";
        private static string vertical = "Key_Y";
        private static string fire = "Key_Fire";
        public static float X { get { return Input.GetAxis(horizontal); } }
        public static float Y { get { return Input.GetAxis(vertical); } }
        public static bool Fire { get { return Input.GetButtonDown(fire); } }
    }
}