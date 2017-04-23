using System.Collections;
using UnityEngine;

public class Acceleration : MonoBehaviour {

	// Use this for initialization
	private PlayerController pc;
    private float accel;
	private IEnumerator effectExit;
	void Start () {
        accel = 1;
		pc = GetComponent<PlayerController>();
		effectExit = EffectExit(pc.ReleaseTime);
		Accel();
	}
	
	// Update is called once per frame
	void Accel()
	{
		pc.Accel += accel;
		StartCoroutine(effectExit);
	}

	IEnumerator EffectExit(float delay)
	{
		yield return new WaitForSeconds(delay);
        pc.Accel -= accel;
        // this.enabled = false; // 現状デストロイの方が分かりやすいが、軽いならこちらに切り替え予定
		Destroy(this);
	}
}
