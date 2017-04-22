using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange : MonoBehaviour {

    Vector3 vec;

	// Use this for initialization
	void Start () {
        //スケールを代入
        vec = this.gameObject.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    void OnCollisionEnter(Collision col)
    {
        //TagがBlockかつ投げたブロックなら処理
        if(col.gameObject.GetComponent<TestHantei>().hantei == true)
        {
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
            if (gameObject.tag == "Block")
            {              
                //スケールを2倍にする
                this.transform.localScale = new Vector3(vec.x * 2, vec.y * 2, vec.z * 2);
            }
            if(gameObject.tag == "Hakaishi")
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
                       
        }
    }
    */
}
