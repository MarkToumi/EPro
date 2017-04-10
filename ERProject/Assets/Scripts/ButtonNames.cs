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

namespace ButtonName
{
    public class GamePad01 : MonoBehaviour
    {
        private static string horizontal = "GamePad01_X";
        private static string vertical = "GamePad01_Y";
        private static string fire = "GamePad01_Fire";
        private static string jump = "GamePad01_Jump";
        public static float X() { return Input.GetAxis(horizontal); }
        public static float Y() { return Input.GetAxis(vertical); }
        public static bool Fire() { return Input.GetButtonDown(fire); }
        public static bool Jump() { return Input.GetButtonDown(jump); }
    }

    public class GamePad02 : MonoBehaviour
    {
        private static string horizontal = "GamePad02_X";
        private static string vertical = "GamePad02_Y";
        private static string fire = "GamePad02_Fire";
        private static string jump = "GamePad02_Jump";
        public static float X() { return Input.GetAxis(horizontal); }
        public static float Y() { return Input.GetAxis(vertical); }
        public static bool Fire() { return Input.GetButtonDown(fire); }
        public static bool Jump() { return Input.GetButtonDown(jump); }
    }

    public class GamePad03 : MonoBehaviour
    {
        private static string horizontal = "GamePad03_X";
        private static string vertical = "GamePad03_Y";
        private static string fire = "GamePad03_Fire";
        private static string jump = "GamePad03_Jump";
        public static float X() { return Input.GetAxis(horizontal); }
        public static float Y() { return Input.GetAxis(vertical); }
        public static bool Fire() { return Input.GetButtonDown(fire); }
        public static bool Jump() { return Input.GetButtonDown(jump); }
    }

    public class GamePad04 : MonoBehaviour
    {
        private static string horizontal = "GamePad04_X";
        private static string vertical = "GamePad04_Y";
        private static string fire = "GamePad04_Fire";
        private static string jump = "GamePad04_Jump";
        public static float X() { return Input.GetAxis(horizontal); }
        public static float Y() { return Input.GetAxis(vertical); }
        public static bool Fire() { return Input.GetButtonDown(fire); }
        public static bool Jump() { return Input.GetButtonDown(jump); }
    }

    public class KeyBord : MonoBehaviour
    {
        private static string horizontal = "Key_X";
        private static string vertical = "Key_Y";
        private static string fire = "Key_Fire";
        private static string jump = "Key_Jump";
        public static float X() { return Input.GetAxis(horizontal); }
        public static float Y() { return Input.GetAxis(vertical); }
        public static bool Fire() { return Input.GetButtonDown(fire); }
        public static bool Jump() { return Input.GetButtonDown(jump); }
    }
}