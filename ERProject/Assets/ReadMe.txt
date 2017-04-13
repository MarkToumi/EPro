Houw to use

プログラマー向け

ButtonNames.cs
    インプット系をまとめたシングルトンみたいなやつ。using GamePad で使えるようになる
    （using しなくても使えるけど楽だからね）
    ゲームパッドの番号ごとにクラスを作ったので欲しいパラメータを指定すれば取れる
    例　ゲームパッド１の場合
    GamePad01.Fire ......攻撃ボタンが入力されたかを bool で取る
    GamePad01.LStick_X ......左スティックの横の値を float で取る
    （実際は Input.GetButton や Input.GetAxis をラッピングもどきしただけ）

