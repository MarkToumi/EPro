using UnityEngine;

public class Item : MonoBehaviour {
	private int itemNum;
    private PlayerController player;
    private int heal;
	// Use this for initialization
	void Start () {
        heal = 1;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject.GetComponent<PlayerController>();
            ItemUse(itemNum);
            this.gameObject.SetActive(false);
        }
    }

    void ItemUse(int iNum)
    {
        switch(iNum)
        {
            case 0:
                Debug.Log("回復");
                Heal(player);
                break;
            case 1:
                Debug.Log("加速");
                player.gameObject.AddComponent<Acceleration>();
                break;
            case 2:
                Debug.Log("強化");
                player.gameObject.AddComponent<RaisePower>();
                break;
            default:
                break;
        }
    }

    void Heal(PlayerController pc)
    {
        if (pc.HP >= pc.MaxHP)
        {
            Debug.Log("回復失敗");
            return;
        }
        else 
        {
            pc.HP += heal;
            int remaining = pc.HP - 1;
            pc.life[remaining].SetActive(true);
        }
    }

    public int ItemNum { 
		get { return this.itemNum; }
		set { this.itemNum = value; }
	}
}
