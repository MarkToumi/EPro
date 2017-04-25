using System.Collections;
using UnityEngine;

public class RaisePower : MonoBehaviour
{
    private PlayerController pc;
    private float plusPower;
    private IEnumerator effectExit;
    // Use this for initialization
    void Start()
    {
        pc = GetComponent<PlayerController>();
        effectExit = EffectExit(pc.ReleaseTime);
        plusPower = 0.5f;
        Raise();
    }

    void Raise()
    {
        pc.ThrowPower += plusPower;
        StartCoroutine(effectExit);
    }

    IEnumerator EffectExit(float delay)
    {
        yield return new WaitForSeconds(delay);
        pc.ThrowPower -= plusPower;
        // this.enabled = false; // 現状デストロイの方が分かりやすいが、軽いならこちらに切り替え予定
        Destroy(this);
    }
}
